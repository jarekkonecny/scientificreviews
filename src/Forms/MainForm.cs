
using ScientificReviews.Bibtex;
using ScientificReviews.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientificReviews.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        List<BibtexEntry> entries = new List<BibtexEntry>();
        BibtexExporter bibtexExporter = new BibtexExporter();

        private void LoadData(BibtexEntry[] entries)
        {
            bibtexDataSet.BibtexEntry.Clear();
            bibtexDataSet.BibtexEntry.BeginLoadData();

            foreach (var entry in entries)
            {
                var row = bibtexDataSet.BibtexEntry.NewBibtexEntryRow();
                row.Key = entry.Key;
                row.Type = entry.Type;
                row.Year = entry.GetTagKey("year");
                row.Title = entry.GetTagKey("title");
                row.Entry = entry;
                bibtexDataSet.BibtexEntry.AddBibtexEntryRow(row);
            }
            bibtexDataSet.BibtexEntry.AcceptChanges();
            bibtexDataSet.BibtexEntry.EndLoadData();


        }
        private async void loadBibTexFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog()
                {
                    SelectedPath = @"C:\incom\Bib"
                })
                {
                    DialogResult result = folderDialog.ShowDialog(this);
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                    {
                        await Task.Run(() =>
                        {
                            entries = new List<BibtexEntry>();
                            string[] files = Directory.GetFiles(folderDialog.SelectedPath, "*.bib", SearchOption.AllDirectories);
                            BibtexParser parser = new BibtexParser();
                            foreach (string file in files)
                            {
                                entries.AddRange(parser.ParseFile(File.ReadAllText(file)));
                            }

                            entries =  BibtexUtils.RemoveDuplicateEntriesByTitle(entries);
                        });
                        LoadData(entries.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }


        }

        private void createEntryKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> keys = new List<string>();
            foreach (BibtexEntry entry in entries)
            {
                string key = entry.GetTagKey("author").Split(',')[0].Trim().Replace(" ", "") +
                    entry.GetTagKey("year");
                string myKey = key;
                int i = 1;
                while (keys.Contains(myKey))
                {
                    myKey = key + "_" + i.ToString();
                    i++;
                }
                entry.Key = myKey;
                keys.Add(myKey);
            }
            LoadData(entries.ToArray());

        }

        private void removeTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            List<string> tags = new List<string>();
            foreach (var entry in entries)
            {
                foreach (var tag in entry.Tags)
                {
                    if (tags.Contains(tag.Key) == false)
                    {
                        tags.Add(tag.Key);
                    }
                }
            }
            SelectForm frm = new SelectForm();
            frm.SetData(tags.ToArray());
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                var tagsToLeave = frm.GetSelected().ToList();
                foreach (var entry in entries)
                {
                    List<BibtexTag> list = new List<BibtexTag>();
                    foreach (var tag in entry.Tags)
                    {
                        if (tagsToLeave.Contains(tag.Key))
                            list.Add(tag);
                    }
                    entry.Tags = list.ToArray();
                }
            }
        }

        private void removeTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> types = new List<string>();
            foreach (var entry in entries)
            {
                if (types.Contains(entry.Type) == false)
                    types.Add(entry.Type);
            }
            SelectForm frm = new SelectForm();
            frm.SetData(types.ToArray());
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                var typesToLeave = frm.GetSelected().ToList();
                List<BibtexEntry> list = new List<BibtexEntry>();
                foreach (var entry in entries)
                {
                    if (typesToLeave.Contains(entry.Type))
                        list.Add(entry);
                }
                entries = list;
            }
            LoadData(entries.ToArray());

        }

        private void exportDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    CheckPathExists = true,
                    Filter = "Bibtex database *.bib|*.bib"
                };
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    BibtexExporter bibtexExporter = new BibtexExporter();
                    string content = bibtexExporter.EntriesToString(entries.ToArray());
                    File.WriteAllText(fileName, content);
                }
                lblStatus.Text = "Export done.";
            }
            catch (Exception ex)
            {

                lblStatus.Text = ex.Message;
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (bibtexEntryBindingSource.Current!= null)
                {
                    DataRowView drv = bibtexEntryBindingSource.Current as DataRowView;
                    var row = drv.Row as BibtexDataSet.BibtexEntryRow;
                    var entry = row.Entry as BibtexEntry;
                    entries.Remove(entry);
                    LoadData(entries.ToArray());
                }
            }
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (bibtexEntryBindingSource.Current is DataRowView == false)
                return;

            DataRowView drv = (DataRowView)bibtexEntryBindingSource.Current;
            if (drv.Row != null)
            {
                var entry = (BibtexEntry)((BibtexDataSet.BibtexEntryRow)drv.Row).Entry;
                textBox1.Text = bibtexExporter.EntryToString(entry);
            }
        }
    }
}
    

