namespace ScientificReviews.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBibTexFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createEntryKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDuplicitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDuplicitiesByDOIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeWithoutDOIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePageTagFormatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDOIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalCitationReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateJournalsDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createExtraJCRTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bibtexEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bibtexDataSet = new ScientificReviews.DataSets.BibtexDataSet();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibtexEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibtexDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.journalCitationReportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1164, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBibTexFolderToolStripMenuItem});
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.projectToolStripMenuItem.Text = "Project";
            // 
            // loadBibTexFolderToolStripMenuItem
            // 
            this.loadBibTexFolderToolStripMenuItem.Name = "loadBibTexFolderToolStripMenuItem";
            this.loadBibTexFolderToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.loadBibTexFolderToolStripMenuItem.Text = "Load BibTex folder";
            this.loadBibTexFolderToolStripMenuItem.Click += new System.EventHandler(this.loadBibTexFolderToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createEntryKeysToolStripMenuItem,
            this.removeDuplicitiesToolStripMenuItem,
            this.removeDuplicitiesByDOIToolStripMenuItem,
            this.removeTagsToolStripMenuItem,
            this.removeTypesToolStripMenuItem,
            this.removeWithoutDOIToolStripMenuItem,
            this.updatePageTagFormatToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exportDatabaseToolStripMenuItem,
            this.exportDOIsToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // createEntryKeysToolStripMenuItem
            // 
            this.createEntryKeysToolStripMenuItem.Name = "createEntryKeysToolStripMenuItem";
            this.createEntryKeysToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.createEntryKeysToolStripMenuItem.Text = "Create entry keys";
            this.createEntryKeysToolStripMenuItem.Click += new System.EventHandler(this.createEntryKeysToolStripMenuItem_Click);
            // 
            // removeDuplicitiesToolStripMenuItem
            // 
            this.removeDuplicitiesToolStripMenuItem.Name = "removeDuplicitiesToolStripMenuItem";
            this.removeDuplicitiesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.removeDuplicitiesToolStripMenuItem.Text = "Remove duplicities by title";
            this.removeDuplicitiesToolStripMenuItem.Click += new System.EventHandler(this.removeDuplicitiesToolStripMenuItem_Click);
            // 
            // removeDuplicitiesByDOIToolStripMenuItem
            // 
            this.removeDuplicitiesByDOIToolStripMenuItem.Name = "removeDuplicitiesByDOIToolStripMenuItem";
            this.removeDuplicitiesByDOIToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.removeDuplicitiesByDOIToolStripMenuItem.Text = "Remove duplicities by DOI";
            this.removeDuplicitiesByDOIToolStripMenuItem.Click += new System.EventHandler(this.removeDuplicitiesByDOIToolStripMenuItem_Click);
            // 
            // removeTagsToolStripMenuItem
            // 
            this.removeTagsToolStripMenuItem.Name = "removeTagsToolStripMenuItem";
            this.removeTagsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.removeTagsToolStripMenuItem.Text = "Remove tags";
            this.removeTagsToolStripMenuItem.Click += new System.EventHandler(this.removeTagsToolStripMenuItem_Click);
            // 
            // removeTypesToolStripMenuItem
            // 
            this.removeTypesToolStripMenuItem.Name = "removeTypesToolStripMenuItem";
            this.removeTypesToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.removeTypesToolStripMenuItem.Text = "Remove types";
            this.removeTypesToolStripMenuItem.Click += new System.EventHandler(this.removeTypesToolStripMenuItem_Click);
            // 
            // removeWithoutDOIToolStripMenuItem
            // 
            this.removeWithoutDOIToolStripMenuItem.Name = "removeWithoutDOIToolStripMenuItem";
            this.removeWithoutDOIToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.removeWithoutDOIToolStripMenuItem.Text = "Remove without DOI";
            this.removeWithoutDOIToolStripMenuItem.Click += new System.EventHandler(this.removeWithoutDOIToolStripMenuItem_Click);
            // 
            // updatePageTagFormatToolStripMenuItem
            // 
            this.updatePageTagFormatToolStripMenuItem.Name = "updatePageTagFormatToolStripMenuItem";
            this.updatePageTagFormatToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.updatePageTagFormatToolStripMenuItem.Text = "Update page tag format";
            this.updatePageTagFormatToolStripMenuItem.Click += new System.EventHandler(this.updatePageTagFormatToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(210, 6);
            // 
            // exportDatabaseToolStripMenuItem
            // 
            this.exportDatabaseToolStripMenuItem.Name = "exportDatabaseToolStripMenuItem";
            this.exportDatabaseToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exportDatabaseToolStripMenuItem.Text = "Export database";
            this.exportDatabaseToolStripMenuItem.Click += new System.EventHandler(this.exportDatabaseToolStripMenuItem_Click);
            // 
            // exportDOIsToolStripMenuItem
            // 
            this.exportDOIsToolStripMenuItem.Name = "exportDOIsToolStripMenuItem";
            this.exportDOIsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exportDOIsToolStripMenuItem.Text = "Export DOIs";
            this.exportDOIsToolStripMenuItem.Click += new System.EventHandler(this.exportDOIsToolStripMenuItem_Click);
            // 
            // journalCitationReportsToolStripMenuItem
            // 
            this.journalCitationReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateJournalsDatabaseToolStripMenuItem,
            this.createExtraJCRTagsToolStripMenuItem});
            this.journalCitationReportsToolStripMenuItem.Name = "journalCitationReportsToolStripMenuItem";
            this.journalCitationReportsToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.journalCitationReportsToolStripMenuItem.Text = "Journal Citation Reports";
            // 
            // updateJournalsDatabaseToolStripMenuItem
            // 
            this.updateJournalsDatabaseToolStripMenuItem.Name = "updateJournalsDatabaseToolStripMenuItem";
            this.updateJournalsDatabaseToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.updateJournalsDatabaseToolStripMenuItem.Text = "Update Journals Database";
            this.updateJournalsDatabaseToolStripMenuItem.Click += new System.EventHandler(this.updateJournalsDatabaseToolStripMenuItem_Click);
            // 
            // createExtraJCRTagsToolStripMenuItem
            // 
            this.createExtraJCRTagsToolStripMenuItem.Name = "createExtraJCRTagsToolStripMenuItem";
            this.createExtraJCRTagsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.createExtraJCRTagsToolStripMenuItem.Text = "Create extra JCR tags";
            this.createExtraJCRTagsToolStripMenuItem.Click += new System.EventHandler(this.createExtraJCRTagsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.toolStripStatusLabel1,
            this.lblInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 909);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1164, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(22, 17);
            this.lblStatus.Text = "---";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1115, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(12, 17);
            this.lblInfo.Text = "-";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.yearDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bibtexEntryBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(889, 885);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.Width = 200;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            // 
            // yearDataGridViewTextBoxColumn
            // 
            this.yearDataGridViewTextBoxColumn.DataPropertyName = "Year";
            this.yearDataGridViewTextBoxColumn.HeaderText = "Year";
            this.yearDataGridViewTextBoxColumn.Name = "yearDataGridViewTextBoxColumn";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 700;
            // 
            // bibtexEntryBindingSource
            // 
            this.bibtexEntryBindingSource.DataMember = "BibtexEntry";
            this.bibtexEntryBindingSource.DataSource = this.bibtexDataSet;
            // 
            // bibtexDataSet
            // 
            this.bibtexDataSet.DataSetName = "BibtexDataSet";
            this.bibtexDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 511);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 374);
            this.textBox1.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(889, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 885);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(265, 501);
            this.propertyGrid1.TabIndex = 6;
            this.propertyGrid1.ToolbarVisible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.splitter2);
            this.panel1.Controls.Add(this.propertyGrid1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(899, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 885);
            this.panel1.TabIndex = 7;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 501);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(265, 10);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 931);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Scientific Reviews";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibtexEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bibtexDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBibTexFolderToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bibtexEntryBindingSource;
        private DataSets.BibtexDataSet bibtexDataSet;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createEntryKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yearDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem exportDOIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
        private System.Windows.Forms.ToolStripMenuItem removeDuplicitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeWithoutDOIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeDuplicitiesByDOIToolStripMenuItem;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripMenuItem updatePageTagFormatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalCitationReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateJournalsDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createExtraJCRTagsToolStripMenuItem;
    }
}