
using ScientificReviews.Bibtex;
using ScientificReviews.DataSets;
using ScientificReviews.Helpers;
using ScientificReviews.JCR;
using ScientificReviews.JCR.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
                row.Year = entry.GetTagValue("year");
                row.Title = entry.GetTagValue("title");
                row.Entry = entry;
                bibtexDataSet.BibtexEntry.AddBibtexEntryRow(row);
            }
            bibtexDataSet.BibtexEntry.AcceptChanges();
            bibtexDataSet.BibtexEntry.EndLoadData();
            lblInfo.Text = $"{entries.Length} entries";

        }
        private async void loadBibTexFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog folderDialog = new FolderBrowserDialog()
                {
                    SelectedPath = Program.AppSettings.Data.LastDirectory
                })
                {
                    DialogResult result = folderDialog.ShowDialog(this);
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                    {
                        Program.AppSettings.Data.LastDirectory = folderDialog.SelectedPath; 
                        await Task.Run(() =>
                        {
                            entries = new List<BibtexEntry>();
                            string[] files = Directory.GetFiles(folderDialog.SelectedPath, "*.bib", SearchOption.AllDirectories);
                            BibtexParser parser = new BibtexParser();
                            foreach (string file in files)
                            {
                                entries.AddRange(parser.ParseFile(File.ReadAllText(file)));
                            }                            
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
                string key = entry.GetTagValue("author").Split(',')[0].Trim().Replace(" ", "") +
                    entry.GetTagValue("year");
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
            frm.SetSelection(Program.AppSettings.Data.SelectedTags);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                var tagsToLeave = frm.GetSelected().ToList();
                Program.AppSettings.Data.SelectedTags = tagsToLeave.ToArray();
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
            frm.SetSelection(Program.AppSettings.Data.SelectedTypes);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                var typesToLeave = frm.GetSelected().ToList();
                Program.AppSettings.Data.SelectedTypes = typesToLeave.ToArray();
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

                CustomClass customClass = new CustomClass();
                customClass.Add(new CustomProperty("entryKey", "Key", entry.Key, "Bibitem", true, true));
                customClass.Add(new CustomProperty("entryType", "Type", entry.Type, "Bibitem", true, true));
                foreach (var tag in entry.Tags)
                {
                    CustomProperty item = new CustomProperty(tag.Key, tag.Key, tag.Value, "Parameters", true, true);                                            
                    customClass.Add(item);
                }
                propertyGrid1.SelectedObject = customClass;
            }
        }

        private void exportDOIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    CheckPathExists = true,
                    Filter = "CSV files *.csv|*.csv"
                };
                if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    BibtexExporter bibtexExporter = new BibtexExporter();
                    string[] content = bibtexExporter.GetDois(entries.ToArray());
                    File.WriteAllLines(fileName, content);
                }
                lblStatus.Text = "Export done.";
            }
            catch (Exception ex)
            {

                lblStatus.Text = ex.Message;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.AppSettings.SaveSettings();            
        }

        private void removeDuplicitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entries = BibtexUtils.RemoveDuplicateEntriesByTag(entries, "title");
            LoadData(entries.ToArray());
        }

        private void removeWithoutDOIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<BibtexEntry> list = new List<BibtexEntry>();
            foreach (var entry in entries)
            {
                if (entry.GetTagValue("doi") != null)
                {
                    list.Add(entry);
                }
            }
            entries = list;
            LoadData(entries.ToArray());
        }

        private void removeDuplicitiesByDOIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            entries = BibtexUtils.RemoveDuplicateEntriesByTag(entries, "doi");
            LoadData(entries.ToArray());
        }
       

        private void updatePageTagFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BibtexUtils.UpdatePages(entries);
        }

        private async void updateJournalsDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int year = 2023; // TODO Set year

                lblStatus.Text = "Updating database...";

                // Find journals, that missing information about quartiles
                JcrApiClient jcrApiClient = new JcrApiClient(Program.AppSettings.Data.JcrApiKey);
                List<string> missingJournals = new List<string>();
                var journalReports = Program.JournalsDatabase.Data.JournalReports;
                Dictionary<string, JournalReportsDto> dic = journalReports.ToDictionary(rep => rep.Journal.Name.ToLower());
                foreach (var entry in entries)
                {
                    if (entry.Type == "article")
                    {
                        string journalName = BibtexUtils.RemoveLatex(entry.GetTagValue("journal")).ToLower();

                        if (dic.Keys.Contains(journalName) == false)
                        {
                            missingJournals.Add(journalName);
                        }
                    }
                }
                missingJournals.Sort();

                foreach (string missingJournal in missingJournals)
                {
                    lblStatus.Text = $"Updating database... ({missingJournal})";
                    // Get journals by name
                    var resp =  await jcrApiClient.GetJournalsAsync(missingJournal);
                    foreach (var hit in resp.Hits)
                    {
                        // Get journal reports
                        var report = await jcrApiClient.GetJournalReportsAsync(hit.Id, year);
                        journalReports.Add(report);
                    } 

                }
                Program.JournalsDatabase.Save();
                lblStatus.Text = "Journal database updated.";
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
            }

        }

        private void createExtraJCRTagsToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            var journalReports = Program.JournalsDatabase.Data.JournalReports;
            Dictionary<string, JournalReportsDto> dic = journalReports.ToDictionary(rep => rep.Journal.Name.ToLower());
            foreach (var entry in entries)
            {
                if (entry.Type == "article")
                {
                    string journalName = BibtexUtils.RemoveLatex(entry.GetTagValue("journal")).ToLower();

                    if (dic.ContainsKey(journalName))
                    {
                        var report = dic[journalName];
                        var list = entry.Tags.ToList();

                        // Calc average percentile JIF
                        int percentile = 0;
                        foreach (var jif in report.Ranks.Jif) {
                            percentile += jif.JifPercentile;
                        }
                        percentile = percentile / report.Ranks.Jif.Count;

                        list.Add(new BibtexTag("jif", percentile.ToString()));
                        list.Add(new BibtexTag("jif_" + report.Year.ToString(), percentile.ToString()));
                        entry.Tags = list.ToArray();
                    }
                }
            }
        }
    }
}


