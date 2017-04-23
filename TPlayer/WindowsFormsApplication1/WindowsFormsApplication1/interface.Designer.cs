namespace TPlayer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.YTplayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.playlistsTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.searchResults = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channel = new System.Windows.Forms.DataGridViewLinkColumn();
            this.button3 = new System.Windows.Forms.Button();
            this.searchLocation = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.playlistControl = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toBeAddedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.recentPlaylistTab = new System.Windows.Forms.TabPage();
            this.programControl = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadPlaylistMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlaylistMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inserUrlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadInserUrlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addInserUrlMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playlist1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.playlist2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.recentPlayedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.video1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.video2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToYoutubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentPlaylistToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.globalHotKeys = new MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.YTplayer)).BeginInit();
            this.playlistsTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchResults)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.playlistControl.SuspendLayout();
            this.programControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(13, 27);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.YTplayer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.playlistsTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(931, 453);
            this.splitContainer1.SplitterDistance = 644;
            this.splitContainer1.TabIndex = 0;
            // 
            // YTplayer
            // 
            this.YTplayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YTplayer.Enabled = true;
            this.YTplayer.Location = new System.Drawing.Point(0, 0);
            this.YTplayer.Name = "YTplayer";
            this.YTplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("YTplayer.OcxState")));
            this.YTplayer.Size = new System.Drawing.Size(644, 453);
            this.YTplayer.TabIndex = 0;
            this.YTplayer.FSCommand += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEventHandler(this.YTplayer_FSCommand);
            this.YTplayer.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(this.YTplayer_FlashCall);
            this.YTplayer.Enter += new System.EventHandler(this.YTplayer_Enter);
            this.YTplayer.Leave += new System.EventHandler(this.YTplayer_Leave);
            // 
            // playlistsTabControl
            // 
            this.playlistsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistsTabControl.Controls.Add(this.tabPage1);
            this.playlistsTabControl.Controls.Add(this.tabPage2);
            this.playlistsTabControl.Controls.Add(this.recentPlaylistTab);
            this.playlistsTabControl.Location = new System.Drawing.Point(3, 4);
            this.playlistsTabControl.Name = "playlistsTabControl";
            this.playlistsTabControl.SelectedIndex = 0;
            this.playlistsTabControl.Size = new System.Drawing.Size(277, 446);
            this.playlistsTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.searchResults);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.searchLocation);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(269, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox1.Location = new System.Drawing.Point(108, 397);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Shuffle";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // searchResults
            // 
            this.searchResults.AllowUserToAddRows = false;
            this.searchResults.AllowUserToDeleteRows = false;
            this.searchResults.AllowUserToResizeRows = false;
            this.searchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.searchResults.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.searchResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.searchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.channel});
            this.searchResults.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.searchResults.Location = new System.Drawing.Point(7, 31);
            this.searchResults.Name = "searchResults";
            this.searchResults.ReadOnly = true;
            this.searchResults.RowHeadersVisible = false;
            this.searchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchResults.ShowEditingIcon = false;
            this.searchResults.Size = new System.Drawing.Size(256, 356);
            this.searchResults.TabIndex = 4;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.FillWeight = 70F;
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.name.ToolTipText = "duble click to play track";
            // 
            // channel
            // 
            this.channel.ActiveLinkColor = System.Drawing.Color.SpringGreen;
            this.channel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.channel.FillWeight = 30F;
            this.channel.HeaderText = "channel";
            this.channel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.channel.LinkColor = System.Drawing.Color.RoyalBlue;
            this.channel.Name = "channel";
            this.channel.ReadOnly = true;
            this.channel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.channel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.channel.ToolTipText = "view channel results";
            this.channel.VisitedLinkColor = System.Drawing.Color.Teal;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Image = global::TPlayer.Properties.Resources.playbutton_50;
            this.button3.Location = new System.Drawing.Point(208, 393);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 23);
            this.button3.TabIndex = 1;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // searchLocation
            // 
            this.searchLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchLocation.FormattingEnabled = true;
            this.searchLocation.ItemHeight = 13;
            this.searchLocation.Items.AddRange(new object[] {
            "all",
            "channel"});
            this.searchLocation.Location = new System.Drawing.Point(184, 4);
            this.searchLocation.Name = "searchLocation";
            this.searchLocation.Size = new System.Drawing.Size(79, 21);
            this.searchLocation.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(179, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "<";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(237, 393);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = ">";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(7, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add to playlist";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.playlistControl);
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(269, 420);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "playlist";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // playlistControl
            // 
            this.playlistControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playlistControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.delToolStripMenuItem,
            this.miscToolStripMenuItem});
            this.playlistControl.Location = new System.Drawing.Point(3, 393);
            this.playlistControl.Name = "playlistControl";
            this.playlistControl.Size = new System.Drawing.Size(263, 24);
            this.playlistControl.TabIndex = 2;
            this.playlistControl.Text = "playlistControl";
            this.playlistControl.Visible = false;
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.urlToolStripMenuItem,
            this.playlistToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.addToolStripMenuItem.Text = "add";
            // 
            // urlToolStripMenuItem
            // 
            this.urlToolStripMenuItem.Name = "urlToolStripMenuItem";
            this.urlToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.urlToolStripMenuItem.Text = "url";
            // 
            // playlistToolStripMenuItem
            // 
            this.playlistToolStripMenuItem.Name = "playlistToolStripMenuItem";
            this.playlistToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.playlistToolStripMenuItem.Text = "playlist";
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedToolStripMenuItem,
            this.allToolStripMenuItem});
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.delToolStripMenuItem.Text = "del";
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.selectedToolStripMenuItem.Text = "selected";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.allToolStripMenuItem.Text = "all";
            // 
            // miscToolStripMenuItem
            // 
            this.miscToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toBeAddedToolStripMenuItem});
            this.miscToolStripMenuItem.Name = "miscToolStripMenuItem";
            this.miscToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.miscToolStripMenuItem.Text = "misc";
            // 
            // toBeAddedToolStripMenuItem
            // 
            this.toBeAddedToolStripMenuItem.Name = "toBeAddedToolStripMenuItem";
            this.toBeAddedToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.toBeAddedToolStripMenuItem.Text = "to be added";
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(4, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(262, 381);
            this.listBox2.TabIndex = 1;
            // 
            // recentPlaylistTab
            // 
            this.recentPlaylistTab.Location = new System.Drawing.Point(4, 22);
            this.recentPlaylistTab.Name = "recentPlaylistTab";
            this.recentPlaylistTab.Padding = new System.Windows.Forms.Padding(3);
            this.recentPlaylistTab.Size = new System.Drawing.Size(269, 420);
            this.recentPlaylistTab.TabIndex = 2;
            this.recentPlaylistTab.Text = "recent";
            this.recentPlaylistTab.UseVisualStyleBackColor = true;
            // 
            // programControl
            // 
            this.programControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.controlToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.programControl.Location = new System.Drawing.Point(0, 0);
            this.programControl.Name = "programControl";
            this.programControl.Size = new System.Drawing.Size(956, 24);
            this.programControl.TabIndex = 1;
            this.programControl.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadPlaylistMenuItem,
            this.newPlaylistMenuItem,
            this.inserUrlMenuItem,
            this.recentPlaylistToolStripMenuItem,
            this.recentPlayedToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItem1.Text = "Playlist";
            // 
            // loadPlaylistMenuItem
            // 
            this.loadPlaylistMenuItem.Name = "loadPlaylistMenuItem";
            this.loadPlaylistMenuItem.Size = new System.Drawing.Size(155, 22);
            this.loadPlaylistMenuItem.Text = "load palylist";
            this.loadPlaylistMenuItem.Click += new System.EventHandler(this.loadPlaylistMenuItem_Click);
            // 
            // newPlaylistMenuItem
            // 
            this.newPlaylistMenuItem.Name = "newPlaylistMenuItem";
            this.newPlaylistMenuItem.Size = new System.Drawing.Size(155, 22);
            this.newPlaylistMenuItem.Text = "new playlist";
            this.newPlaylistMenuItem.Click += new System.EventHandler(this.newPlaylistMenuItem_Click);
            // 
            // inserUrlMenuItem
            // 
            this.inserUrlMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadInserUrlMenuItem,
            this.addInserUrlMenuItem});
            this.inserUrlMenuItem.Name = "inserUrlMenuItem";
            this.inserUrlMenuItem.Size = new System.Drawing.Size(155, 22);
            this.inserUrlMenuItem.Text = "insert url";
            this.inserUrlMenuItem.Click += new System.EventHandler(this.inserUrlMenuItem_Click);
            // 
            // loadInserUrlMenuItem
            // 
            this.loadInserUrlMenuItem.Name = "loadInserUrlMenuItem";
            this.loadInserUrlMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadInserUrlMenuItem.Text = "load";
            this.loadInserUrlMenuItem.Click += new System.EventHandler(this.inserUrlMenuItem_Click);
            // 
            // addInserUrlMenuItem
            // 
            this.addInserUrlMenuItem.Name = "addInserUrlMenuItem";
            this.addInserUrlMenuItem.Size = new System.Drawing.Size(97, 22);
            this.addInserUrlMenuItem.Text = "add";
            this.addInserUrlMenuItem.Click += new System.EventHandler(this.addInserUrlMenuItem_Click);
            // 
            // recentPlaylistToolStripMenuItem
            // 
            this.recentPlaylistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playlist1ToolStripMenuItem,
            this.playlist2ToolStripMenuItem});
            this.recentPlaylistToolStripMenuItem.Name = "recentPlaylistToolStripMenuItem";
            this.recentPlaylistToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.recentPlaylistToolStripMenuItem.Text = "Recent playlists";
            // 
            // playlist1ToolStripMenuItem
            // 
            this.playlist1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.addToolStripMenuItem1});
            this.playlist1ToolStripMenuItem.Name = "playlist1ToolStripMenuItem";
            this.playlist1ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.playlist1ToolStripMenuItem.Text = "playlist1";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.loadToolStripMenuItem.Text = "load";
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(97, 22);
            this.addToolStripMenuItem1.Text = "add";
            // 
            // playlist2ToolStripMenuItem
            // 
            this.playlist2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.addToolStripMenuItem2});
            this.playlist2ToolStripMenuItem.Name = "playlist2ToolStripMenuItem";
            this.playlist2ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.playlist2ToolStripMenuItem.Text = "playlist2";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(97, 22);
            this.loadToolStripMenuItem1.Text = "load";
            // 
            // addToolStripMenuItem2
            // 
            this.addToolStripMenuItem2.Name = "addToolStripMenuItem2";
            this.addToolStripMenuItem2.Size = new System.Drawing.Size(97, 22);
            this.addToolStripMenuItem2.Text = "add";
            // 
            // recentPlayedToolStripMenuItem
            // 
            this.recentPlayedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.video1ToolStripMenuItem,
            this.video2ToolStripMenuItem});
            this.recentPlayedToolStripMenuItem.Name = "recentPlayedToolStripMenuItem";
            this.recentPlayedToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.recentPlayedToolStripMenuItem.Text = "Recent played";
            // 
            // video1ToolStripMenuItem
            // 
            this.video1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem1,
            this.addToolStripMenuItem4});
            this.video1ToolStripMenuItem.Name = "video1ToolStripMenuItem";
            this.video1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.video1ToolStripMenuItem.Text = "video1";
            // 
            // playToolStripMenuItem1
            // 
            this.playToolStripMenuItem1.Name = "playToolStripMenuItem1";
            this.playToolStripMenuItem1.Size = new System.Drawing.Size(96, 22);
            this.playToolStripMenuItem1.Text = "play";
            // 
            // addToolStripMenuItem4
            // 
            this.addToolStripMenuItem4.Name = "addToolStripMenuItem4";
            this.addToolStripMenuItem4.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem4.Text = "add";
            // 
            // video2ToolStripMenuItem
            // 
            this.video2ToolStripMenuItem.Name = "video2ToolStripMenuItem";
            this.video2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.video2ToolStripMenuItem.Text = "video2";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.saveAsToolStripMenuItem,
            this.saveToYoutubeToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.saveToolStripMenuItem.Text = "save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(156, 22);
            this.saveToolStripMenuItem1.Text = "save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveAsToolStripMenuItem.Text = "save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // saveToYoutubeToolStripMenuItem
            // 
            this.saveToYoutubeToolStripMenuItem.Name = "saveToYoutubeToolStripMenuItem";
            this.saveToYoutubeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveToYoutubeToolStripMenuItem.Text = "saveToYoutube";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.nextToolStripMenuItem,
            this.previousToolStripMenuItem,
            this.addToPlaylistToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.playToolStripMenuItem.Text = "play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.pauseToolStripMenuItem.Text = "pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.stopToolStripMenuItem.Text = "stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopMenuItem_Click);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.nextToolStripMenuItem.Text = "next";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.nextMenuItem_Click);
            // 
            // previousToolStripMenuItem
            // 
            this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
            this.previousToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.previousToolStripMenuItem.Text = "previous";
            this.previousToolStripMenuItem.Click += new System.EventHandler(this.previousMenuItem_Click);
            // 
            // addToPlaylistToolStripMenuItem
            // 
            this.addToPlaylistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recentPlaylistToolStripMenuItem1});
            this.addToPlaylistToolStripMenuItem.Name = "addToPlaylistToolStripMenuItem";
            this.addToPlaylistToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addToPlaylistToolStripMenuItem.Text = "add to playlist";
            this.addToPlaylistToolStripMenuItem.Click += new System.EventHandler(this.addToPlaylistMenuItem_Click);
            // 
            // recentPlaylistToolStripMenuItem1
            // 
            this.recentPlaylistToolStripMenuItem1.Name = "recentPlaylistToolStripMenuItem1";
            this.recentPlaylistToolStripMenuItem1.Size = new System.Drawing.Size(144, 22);
            this.recentPlaylistToolStripMenuItem1.Text = "recentPlaylist";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.globalHotkeysToolStripMenuItem,
            this.loopToolStripMenuItem,
            this.shuffleToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // globalHotkeysToolStripMenuItem
            // 
            this.globalHotkeysToolStripMenuItem.Checked = true;
            this.globalHotkeysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.globalHotkeysToolStripMenuItem.Name = "globalHotkeysToolStripMenuItem";
            this.globalHotkeysToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.globalHotkeysToolStripMenuItem.Text = "Global Hotkeys";
            this.globalHotkeysToolStripMenuItem.Click += new System.EventHandler(this.globalHotkeysToolStripMenuItem_Click);
            // 
            // loopToolStripMenuItem
            // 
            this.loopToolStripMenuItem.Name = "loopToolStripMenuItem";
            this.loopToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.loopToolStripMenuItem.Text = "Loop";
            this.loopToolStripMenuItem.Click += new System.EventHandler(this.loopToolStripMenuItem_Click);
            // 
            // shuffleToolStripMenuItem
            // 
            this.shuffleToolStripMenuItem.Name = "shuffleToolStripMenuItem";
            this.shuffleToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.shuffleToolStripMenuItem.Text = "Shuffle";
            this.shuffleToolStripMenuItem.Click += new System.EventHandler(this.shuffleToolStripMenuItem_Click);
            // 
            // globalHotKeys
            // 
            this.globalHotKeys.Enabled = true;
            this.globalHotKeys.HookType = MouseKeyboardActivityMonitor.Controls.HookType.Global;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 492);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.programControl);
            this.Name = "Form1";
            this.Text = "TPlayer";
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.YTplayer)).EndInit();
            this.playlistsTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchResults)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.playlistControl.ResumeLayout(false);
            this.playlistControl.PerformLayout();
            this.programControl.ResumeLayout(false);
            this.programControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip programControl;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loadPlaylistMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPlaylistMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inserUrlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.TabControl playlistsTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView searchResults;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.MenuStrip playlistControl;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miscToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toBeAddedToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewLinkColumn channel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox searchLocation;
        private MouseKeyboardActivityMonitor.Controls.MouseKeyEventProvider globalHotKeys;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem globalHotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playlist1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playlist2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem recentPlayedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem video1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem video2ToolStripMenuItem;
        private AxShockwaveFlashObjects.AxShockwaveFlash YTplayer;
        private System.Windows.Forms.TabPage recentPlaylistTab;
        private System.Windows.Forms.ToolStripMenuItem loadInserUrlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addInserUrlMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recentPlaylistToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToYoutubeToolStripMenuItem;
    }
}

