using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientificReviews.Forms
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        public void SetData(string[] tags)
        {
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(tags);
            //for (int i = 0; i < tags.Length; i++) {
            //    checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            //}            
        }
        public string[] GetSelected()
        {
            List<string> tags = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                tags.Add(item.ToString());                
            }
            return tags.ToArray();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
