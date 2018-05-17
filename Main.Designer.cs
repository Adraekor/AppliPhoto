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
            this.TagSoloImageSplit = new System.Windows.Forms.TableLayoutPanel();
            this.soloImageLayout = new System.Windows.Forms.Panel();
            this.tagPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayout_mosaic = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel_mosaic_recherche = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel_recherche = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel_retirer = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel_recherche = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox_recherche = new System.Windows.Forms.TextBox();
            this.button_Recherche = new System.Windows.Forms.Button();
            this.button_vider_recherche = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBox_retirer = new System.Windows.Forms.TextBox();
            this.button_retirer = new System.Windows.Forms.Button();
            this.button_vider_retirer = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.effacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TagListImagesSplit = new System.Windows.Forms.TableLayoutPanel();
            this.TagListSplit = new System.Windows.Forms.TableLayoutPanel();
            this.AddSuperTag = new System.Windows.Forms.Button();
            this.AddSubTag = new System.Windows.Forms.Button();
            this.TreeViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.effacerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MosaicPageSplit = new System.Windows.Forms.TableLayoutPanel();
            this.mosaicLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.PagePanel = new System.Windows.Forms.Panel();
            this.LeftArrowPage = new System.Windows.Forms.PictureBox();
            this.RightArrowPage = new System.Windows.Forms.PictureBox();
            this.PageLabel = new System.Windows.Forms.Label();
            this.toolbar.SuspendLayout();
            this.SplitScreen.SuspendLayout();
            this.TagSoloImageSplit.SuspendLayout();
            this.tableLayout_mosaic.SuspendLayout();
            this.tableLayoutPanel_recherche.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.TagListImagesSplit.SuspendLayout();
            this.TagListSplit.SuspendLayout();
            this.TreeViewMenu.SuspendLayout();
            this.MosaicPageSplit.SuspendLayout();
            this.PagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftArrowPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightArrowPage)).BeginInit();
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
            this.SplitScreen.Controls.Add(this.TagSoloImageSplit, 1, 0);
            this.SplitScreen.Controls.Add(this.tableLayout_mosaic, 0, 0);
            this.SplitScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitScreen.Location = new System.Drawing.Point(207, 3);
            this.SplitScreen.Name = "SplitScreen";
            this.SplitScreen.RowCount = 1;
            this.SplitScreen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SplitScreen.Size = new System.Drawing.Size(1152, 710);
            this.SplitScreen.TabIndex = 1;
            // 
            // TagSoloImageSplit
            // 
            this.TagSoloImageSplit.ColumnCount = 1;
            this.TagSoloImageSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TagSoloImageSplit.Controls.Add(this.soloImageLayout, 0, 0);
            this.TagSoloImageSplit.Controls.Add(this.tagPanel, 0, 1);
            this.TagSoloImageSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagSoloImageSplit.Location = new System.Drawing.Point(579, 3);
            this.TagSoloImageSplit.Name = "TagSoloImageSplit";
            this.TagSoloImageSplit.RowCount = 2;
            this.TagSoloImageSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TagSoloImageSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TagSoloImageSplit.Size = new System.Drawing.Size(570, 704);
            this.TagSoloImageSplit.TabIndex = 1;
            // 
            // soloImageLayout
            // 
            this.soloImageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soloImageLayout.Location = new System.Drawing.Point(3, 3);
            this.soloImageLayout.Name = "soloImageLayout";
            this.soloImageLayout.Size = new System.Drawing.Size(564, 346);
            this.soloImageLayout.TabIndex = 0;
            // 
            // tagPanel
            // 
            this.tagPanel.AutoScroll = true;
            this.tagPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagPanel.Location = new System.Drawing.Point(3, 355);
            this.tagPanel.Name = "tagPanel";
            this.tagPanel.Size = new System.Drawing.Size(564, 346);
            this.tagPanel.TabIndex = 1;
            // 
            // tableLayout_mosaic
            // 
            this.tableLayout_mosaic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayout_mosaic.AutoSize = true;
            this.tableLayout_mosaic.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayout_mosaic.ColumnCount = 1;
            this.tableLayout_mosaic.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayout_mosaic.Controls.Add(this.flowLayoutPanel_mosaic_recherche, 0, 2);
            this.tableLayout_mosaic.Controls.Add(this.tableLayoutPanel_recherche, 0, 0);
            this.tableLayout_mosaic.Controls.Add(this.MosaicPageSplit, 0, 1);
            this.tableLayout_mosaic.Location = new System.Drawing.Point(3, 3);
            this.tableLayout_mosaic.Name = "tableLayout_mosaic";
            this.tableLayout_mosaic.RowCount = 3;
            this.tableLayout_mosaic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31.25F));
            this.tableLayout_mosaic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.75F));
            this.tableLayout_mosaic.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 312F));
            this.tableLayout_mosaic.Size = new System.Drawing.Size(570, 704);
            this.tableLayout_mosaic.TabIndex = 2;
            // 
            // flowLayoutPanel_mosaic_recherche
            // 
            this.flowLayoutPanel_mosaic_recherche.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanel_mosaic_recherche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_mosaic_recherche.Location = new System.Drawing.Point(3, 394);
            this.flowLayoutPanel_mosaic_recherche.Name = "flowLayoutPanel_mosaic_recherche";
            this.flowLayoutPanel_mosaic_recherche.Size = new System.Drawing.Size(564, 307);
            this.flowLayoutPanel_mosaic_recherche.TabIndex = 6;
            // 
            // tableLayoutPanel_recherche
            // 
            this.tableLayoutPanel_recherche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel_recherche.AutoSize = true;
            this.tableLayoutPanel_recherche.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_recherche.ColumnCount = 2;
            this.tableLayoutPanel_recherche.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.20635F));
            this.tableLayoutPanel_recherche.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.79365F));
            this.tableLayoutPanel_recherche.Controls.Add(this.flowLayoutPanel_retirer, 1, 1);
            this.tableLayoutPanel_recherche.Controls.Add(this.flowLayoutPanel_recherche, 0, 1);
            this.tableLayoutPanel_recherche.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel_recherche.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel_recherche.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_recherche.Name = "tableLayoutPanel_recherche";
            this.tableLayoutPanel_recherche.RowCount = 2;
            this.tableLayoutPanel_recherche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.97297F));
            this.tableLayoutPanel_recherche.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.02702F));
            this.tableLayoutPanel_recherche.Size = new System.Drawing.Size(564, 116);
            this.tableLayoutPanel_recherche.TabIndex = 5;
            // 
            // flowLayoutPanel_retirer
            // 
            this.flowLayoutPanel_retirer.AutoScroll = true;
            this.flowLayoutPanel_retirer.AutoSize = true;
            this.flowLayoutPanel_retirer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flowLayoutPanel_retirer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_retirer.Location = new System.Drawing.Point(280, 41);
            this.flowLayoutPanel_retirer.Name = "flowLayoutPanel_retirer";
            this.flowLayoutPanel_retirer.Size = new System.Drawing.Size(281, 72);
            this.flowLayoutPanel_retirer.TabIndex = 4;
            // 
            // flowLayoutPanel_recherche
            // 
            this.flowLayoutPanel_recherche.AutoScroll = true;
            this.flowLayoutPanel_recherche.AutoSize = true;
            this.flowLayoutPanel_recherche.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flowLayoutPanel_recherche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_recherche.Location = new System.Drawing.Point(3, 41);
            this.flowLayoutPanel_recherche.Name = "flowLayoutPanel_recherche";
            this.flowLayoutPanel_recherche.Size = new System.Drawing.Size(271, 72);
            this.flowLayoutPanel_recherche.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flowLayoutPanel1.Controls.Add(this.textBox_recherche);
            this.flowLayoutPanel1.Controls.Add(this.button_Recherche);
            this.flowLayoutPanel1.Controls.Add(this.button_vider_recherche);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(271, 32);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // textBox_recherche
            // 
            this.textBox_recherche.Location = new System.Drawing.Point(3, 3);
            this.textBox_recherche.Name = "textBox_recherche";
            this.textBox_recherche.Size = new System.Drawing.Size(105, 20);
            this.textBox_recherche.TabIndex = 0;
            // 
            // button_Recherche
            // 
            this.button_Recherche.AutoSize = true;
            this.button_Recherche.Location = new System.Drawing.Point(114, 3);
            this.button_Recherche.Name = "button_Recherche";
            this.button_Recherche.Size = new System.Drawing.Size(92, 23);
            this.button_Recherche.TabIndex = 1;
            this.button_Recherche.Text = "Recherche Tag";
            this.button_Recherche.UseVisualStyleBackColor = true;
            this.button_Recherche.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // button_vider_recherche
            // 
            this.button_vider_recherche.AutoSize = true;
            this.button_vider_recherche.Location = new System.Drawing.Point(212, 3);
            this.button_vider_recherche.Name = "button_vider_recherche";
            this.button_vider_recherche.Size = new System.Drawing.Size(41, 23);
            this.button_vider_recherche.TabIndex = 2;
            this.button_vider_recherche.Text = "Vider";
            this.button_vider_recherche.UseVisualStyleBackColor = true;
            this.button_vider_recherche.Click += new System.EventHandler(this.button_vider_recherche_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flowLayoutPanel2.Controls.Add(this.textBox_retirer);
            this.flowLayoutPanel2.Controls.Add(this.button_retirer);
            this.flowLayoutPanel2.Controls.Add(this.button_vider_retirer);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(280, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(281, 32);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // textBox_retirer
            // 
            this.textBox_retirer.Location = new System.Drawing.Point(3, 3);
            this.textBox_retirer.Name = "textBox_retirer";
            this.textBox_retirer.Size = new System.Drawing.Size(105, 20);
            this.textBox_retirer.TabIndex = 2;
            // 
            // button_retirer
            // 
            this.button_retirer.AutoSize = true;
            this.button_retirer.Location = new System.Drawing.Point(114, 3);
            this.button_retirer.Name = "button_retirer";
            this.button_retirer.Size = new System.Drawing.Size(92, 23);
            this.button_retirer.TabIndex = 3;
            this.button_retirer.Text = "Retirer Tag";
            this.button_retirer.UseVisualStyleBackColor = true;
            this.button_retirer.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // button_vider_retirer
            // 
            this.button_vider_retirer.AutoSize = true;
            this.button_vider_retirer.Location = new System.Drawing.Point(212, 3);
            this.button_vider_retirer.Name = "button_vider_retirer";
            this.button_vider_retirer.Size = new System.Drawing.Size(41, 23);
            this.button_vider_retirer.TabIndex = 4;
            this.button_vider_retirer.Text = "Vider";
            this.button_vider_retirer.UseVisualStyleBackColor = true;
            this.button_vider_retirer.Click += new System.EventHandler(this.button_vider_retirer_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effacerToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 26);
            // 
            // effacerToolStripMenuItem
            // 
            this.effacerToolStripMenuItem.Name = "effacerToolStripMenuItem";
            this.effacerToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.effacerToolStripMenuItem.Text = "Effacer";
            this.effacerToolStripMenuItem.Click += new System.EventHandler(this.EraseToolStripMenuItem_Click);
            // 
            // TagListImagesSplit
            // 
            this.TagListImagesSplit.ColumnCount = 2;
            this.TagListImagesSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TagListImagesSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.TagListImagesSplit.Controls.Add(this.SplitScreen, 1, 0);
            this.TagListImagesSplit.Controls.Add(this.TagListSplit, 0, 0);
            this.TagListImagesSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagListImagesSplit.Location = new System.Drawing.Point(0, 25);
            this.TagListImagesSplit.Name = "TagListImagesSplit";
            this.TagListImagesSplit.RowCount = 1;
            this.TagListImagesSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TagListImagesSplit.Size = new System.Drawing.Size(1362, 716);
            this.TagListImagesSplit.TabIndex = 5;
            // 
            // TagListSplit
            // 
            this.TagListSplit.ColumnCount = 1;
            this.TagListSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TagListSplit.Controls.Add(this.AddSuperTag, 0, 0);
            this.TagListSplit.Controls.Add(this.AddSubTag, 0, 1);
            this.TagListSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TagListSplit.Location = new System.Drawing.Point(3, 3);
            this.TagListSplit.Name = "TagListSplit";
            this.TagListSplit.RowCount = 3;
            this.TagListSplit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TagListSplit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TagListSplit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TagListSplit.Size = new System.Drawing.Size(198, 710);
            this.TagListSplit.TabIndex = 2;
            // 
            // AddSuperTag
            // 
            this.AddSuperTag.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddSuperTag.Location = new System.Drawing.Point(3, 3);
            this.AddSuperTag.Name = "AddSuperTag";
            this.AddSuperTag.Size = new System.Drawing.Size(192, 26);
            this.AddSuperTag.TabIndex = 4;
            this.AddSuperTag.Text = "Ajouter un super tag";
            this.AddSuperTag.UseVisualStyleBackColor = true;
            this.AddSuperTag.Click += new System.EventHandler(this.AddSuperTag_Click);
            // 
            // AddSubTag
            // 
            this.AddSubTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddSubTag.Location = new System.Drawing.Point(3, 35);
            this.AddSubTag.Name = "AddSubTag";
            this.AddSubTag.Size = new System.Drawing.Size(192, 23);
            this.AddSubTag.TabIndex = 5;
            this.AddSubTag.Text = "Ajouter un sous tag";
            this.AddSubTag.UseVisualStyleBackColor = true;
            this.AddSubTag.Click += new System.EventHandler(this.AddSubtag_Click);
            // 
            // TreeViewMenu
            // 
            this.TreeViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effacerToolStripMenuItem1});
            this.TreeViewMenu.Name = "TreeViewMenu";
            this.TreeViewMenu.Size = new System.Drawing.Size(111, 26);
            // 
            // effacerToolStripMenuItem1
            // 
            this.effacerToolStripMenuItem1.Name = "effacerToolStripMenuItem1";
            this.effacerToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.effacerToolStripMenuItem1.Text = "Effacer";
            this.effacerToolStripMenuItem1.Click += new System.EventHandler(this.DeleteTagFromTreeView_Click);
            // 
            // MosaicPageSplit
            // 
            this.MosaicPageSplit.ColumnCount = 1;
            this.MosaicPageSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MosaicPageSplit.Controls.Add(this.mosaicLayout, 0, 0);
            this.MosaicPageSplit.Controls.Add(this.PagePanel, 0, 1);
            this.MosaicPageSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MosaicPageSplit.Location = new System.Drawing.Point(3, 125);
            this.MosaicPageSplit.Name = "MosaicPageSplit";
            this.MosaicPageSplit.RowCount = 2;
            this.MosaicPageSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MosaicPageSplit.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MosaicPageSplit.Size = new System.Drawing.Size(564, 263);
            this.MosaicPageSplit.TabIndex = 7;
            // 
            // mosaicLayout
            // 
            this.mosaicLayout.AutoScroll = true;
            this.mosaicLayout.AutoSize = true;
            this.mosaicLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mosaicLayout.BackColor = System.Drawing.SystemColors.Control;
            this.mosaicLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mosaicLayout.Location = new System.Drawing.Point(3, 3);
            this.mosaicLayout.Name = "mosaicLayout";
            this.mosaicLayout.Size = new System.Drawing.Size(558, 221);
            this.mosaicLayout.TabIndex = 1;
            // 
            // PagePanel
            // 
            this.PagePanel.AutoSize = true;
            this.PagePanel.Controls.Add(this.PageLabel);
            this.PagePanel.Controls.Add(this.RightArrowPage);
            this.PagePanel.Controls.Add(this.LeftArrowPage);
            this.PagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagePanel.Location = new System.Drawing.Point(3, 230);
            this.PagePanel.Name = "PagePanel";
            this.PagePanel.Size = new System.Drawing.Size(558, 30);
            this.PagePanel.TabIndex = 2;
            // 
            // LeftArrowPage
            // 
            this.LeftArrowPage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LeftArrowPage.ImageLocation = "asset/left_arrow.png";
            this.LeftArrowPage.Location = new System.Drawing.Point(253, 0);
            this.LeftArrowPage.Name = "LeftArrowPage";
            this.LeftArrowPage.Size = new System.Drawing.Size(15, 27);
            this.LeftArrowPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LeftArrowPage.TabIndex = 0;
            this.LeftArrowPage.TabStop = false;
            this.LeftArrowPage.Click += new System.EventHandler(this.LeftArrowPage_Click);
            // 
            // RightArrowPage
            // 
            this.RightArrowPage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.RightArrowPage.ImageLocation = "asset/right_arrow.png";
            this.RightArrowPage.Location = new System.Drawing.Point(300, 0);
            this.RightArrowPage.Name = "RightArrowPage";
            this.RightArrowPage.Size = new System.Drawing.Size(13, 27);
            this.RightArrowPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RightArrowPage.TabIndex = 1;
            this.RightArrowPage.TabStop = false;
            this.RightArrowPage.Click += new System.EventHandler(this.RightArrowPage_Click);
            // 
            // PageLabel
            // 
            this.PageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PageLabel.AutoSize = true;
            this.PageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PageLabel.Location = new System.Drawing.Point(274, 0);
            this.PageLabel.Name = "PageLabel";
            this.PageLabel.Size = new System.Drawing.Size(0, 25);
            this.PageLabel.TabIndex = 2;
            this.PageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.TagListImagesSplit);
            this.Controls.Add(this.toolbar);
            this.MinimumSize = new System.Drawing.Size(825, 500);
            this.Name = "Main";
            this.Text = "Gestion de photos";
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.SplitScreen.ResumeLayout(false);
            this.SplitScreen.PerformLayout();
            this.TagSoloImageSplit.ResumeLayout(false);
            this.tableLayout_mosaic.ResumeLayout(false);
            this.tableLayout_mosaic.PerformLayout();
            this.tableLayoutPanel_recherche.ResumeLayout(false);
            this.tableLayoutPanel_recherche.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.TagListImagesSplit.ResumeLayout(false);
            this.TagListSplit.ResumeLayout(false);
            this.TreeViewMenu.ResumeLayout(false);
            this.MosaicPageSplit.ResumeLayout(false);
            this.MosaicPageSplit.PerformLayout();
            this.PagePanel.ResumeLayout(false);
            this.PagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftArrowPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightArrowPage)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel TagSoloImageSplit;
        private System.Windows.Forms.Panel soloImageLayout;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FlowLayoutPanel tagPanel;
        private System.Windows.Forms.Button button_Recherche;
        private System.Windows.Forms.TextBox textBox_recherche;
        private System.Windows.Forms.ToolStripMenuItem effacerToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel TagListImagesSplit;
        private System.Windows.Forms.ContextMenuStrip TreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem effacerToolStripMenuItem1;
        private System.Windows.Forms.TableLayoutPanel TagListSplit;
        private System.Windows.Forms.Button AddSuperTag;
        private System.Windows.Forms.Button AddSubTag;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_recherche;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_recherche;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayout_mosaic;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_retirer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox textBox_retirer;
        private System.Windows.Forms.Button button_retirer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_mosaic_recherche;
        private System.Windows.Forms.Button button_vider_recherche;
        private System.Windows.Forms.Button button_vider_retirer;
        private System.Windows.Forms.TableLayoutPanel MosaicPageSplit;
        private System.Windows.Forms.FlowLayoutPanel mosaicLayout;
        private System.Windows.Forms.Panel PagePanel;
        private System.Windows.Forms.Label PageLabel;
        private System.Windows.Forms.PictureBox RightArrowPage;
        private System.Windows.Forms.PictureBox LeftArrowPage;
    }
}