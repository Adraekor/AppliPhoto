namespace AppliPhoto
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.importerStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.importerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dossierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitScreen = new System.Windows.Forms.TableLayoutPanel();
            this.mosaicLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.soloImageLayout = new System.Windows.Forms.Panel();
            this.tagPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.toolbar.SuspendLayout();
            this.SplitScreen.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importerStripDropDownButton1});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1362, 25);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // importerStripDropDownButton1
            // 
            this.importerStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.importerStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importerToolStripMenuItem});
            this.importerStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("importerStripDropDownButton1.Image")));
            this.importerStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importerStripDropDownButton1.Name = "importerStripDropDownButton1";
            this.importerStripDropDownButton1.Size = new System.Drawing.Size(55, 22);
            this.importerStripDropDownButton1.Text = "Fichier";
            // 
            // importerToolStripMenuItem
            // 
            this.importerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.dossierToolStripMenuItem});
            this.importerToolStripMenuItem.Name = "importerToolStripMenuItem";
            this.importerToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importerToolStripMenuItem.Text = "Importer";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.fichierToolStripMenuItem.Text = "Image";
            this.fichierToolStripMenuItem.Click += new System.EventHandler(this.ImageImport);
            // 
            // dossierToolStripMenuItem
            // 
            this.dossierToolStripMenuItem.Name = "dossierToolStripMenuItem";
            this.dossierToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.dossierToolStripMenuItem.Text = "Dossier";
            this.dossierToolStripMenuItem.Click += new System.EventHandler(this.DirectoryImport);
            // 
            // SplitScreen
            // 
            this.SplitScreen.ColumnCount = 2;
            this.SplitScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SplitScreen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SplitScreen.Controls.Add(this.mosaicLayout, 0, 0);
            this.SplitScreen.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.SplitScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitScreen.Location = new System.Drawing.Point(0, 25);
            this.SplitScreen.Name = "SplitScreen";
            this.SplitScreen.RowCount = 1;
            this.SplitScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SplitScreen.Size = new System.Drawing.Size(1362, 716);
            this.SplitScreen.TabIndex = 1;
            // 
            // mosaicLayout
            // 
            this.mosaicLayout.AutoScroll = true;
            this.mosaicLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mosaicLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mosaicLayout.Location = new System.Drawing.Point(3, 3);
            this.mosaicLayout.Name = "mosaicLayout";
            this.mosaicLayout.Size = new System.Drawing.Size(675, 710);
            this.mosaicLayout.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.soloImageLayout, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tagPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(684, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(675, 710);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // soloImageLayout
            // 
            this.soloImageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soloImageLayout.Location = new System.Drawing.Point(3, 3);
            this.soloImageLayout.Name = "soloImageLayout";
            this.soloImageLayout.Size = new System.Drawing.Size(669, 349);
            this.soloImageLayout.TabIndex = 0;
            // 
            // tagPanel
            // 
            this.tagPanel.AutoScroll = true;
            this.tagPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagPanel.Location = new System.Drawing.Point(3, 358);
            this.tagPanel.Name = "tagPanel";
            this.tagPanel.Size = new System.Drawing.Size(669, 349);
            this.tagPanel.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.SplitScreen);
            this.Controls.Add(this.toolbar);
            this.MinimumSize = new System.Drawing.Size(825, 500);
            this.Name = "Main";
            this.Text = "Gestion de photos";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.SplitScreen.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripDropDownButton importerStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem importerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dossierToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel SplitScreen;
        private System.Windows.Forms.FlowLayoutPanel mosaicLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel soloImageLayout;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FlowLayoutPanel tagPanel;
    }
}