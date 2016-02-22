namespace RouteSupervisor
{
    partial class SplitRouteView
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
            this.webView = new EO.WebBrowser.WebView();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMapsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuAddNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveAsFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.blvStops = new ComponentOwl.BetterListView.BetterListView();
            this.bcolName = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.bcolNumberDrops = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.bcolStreet = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.bcolCity = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.bcolState = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.bcolPostalCode = new ComponentOwl.BetterListView.BetterListViewColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStopDuration = new System.Windows.Forms.TextBox();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRoute = new System.Windows.Forms.Button();
            this.chkboxRoundTrip = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnRouteAsIs = new System.Windows.Forms.RadioButton();
            this.radioBtnOptimizeRoute = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtDrivingDuration = new System.Windows.Forms.TextBox();
            this.webControl = new EO.WebBrowser.WinForm.WebControl();
            this.lvStopsOld = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumberDrops = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStreet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPostalCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blvStops)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowDropLoad = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // menuMapsConfig
            // 
            this.menuMapsConfig.Name = "menuMapsConfig";
            this.menuMapsConfig.Size = new System.Drawing.Size(32, 19);
            // 
            // contextMenuStop
            // 
            this.contextMenuStop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPaste,
            this.menuClearAll,
            this.toolStripMenuItem1,
            this.menuAddNew,
            this.menuEdit,
            this.menuDelete});
            this.contextMenuStop.Name = "contextMenuStop";
            this.contextMenuStop.Size = new System.Drawing.Size(133, 120);
            this.contextMenuStop.Opened += new System.EventHandler(this.contextMenuStop_Opened);
            // 
            // menuPaste
            // 
            this.menuPaste.Name = "menuPaste";
            this.menuPaste.Size = new System.Drawing.Size(132, 22);
            this.menuPaste.Text = "Paste";
            this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
            // 
            // menuClearAll
            // 
            this.menuClearAll.Name = "menuClearAll";
            this.menuClearAll.Size = new System.Drawing.Size(132, 22);
            this.menuClearAll.Text = "Clear All";
            this.menuClearAll.Click += new System.EventHandler(this.menuClearAll_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(129, 6);
            // 
            // menuAddNew
            // 
            this.menuAddNew.Name = "menuAddNew";
            this.menuAddNew.Size = new System.Drawing.Size(132, 22);
            this.menuAddNew.Text = "Add New...";
            this.menuAddNew.Click += new System.EventHandler(this.menuAddNew_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(132, 22);
            this.menuEdit.Text = "Edit...";
            this.menuEdit.Click += new System.EventHandler(this.menuEdit_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Size = new System.Drawing.Size(132, 22);
            this.menuDelete.Text = "Delete";
            this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Route files|*.route|Excel files|*.xls*|All Files|*.*";
            // 
            // saveAsFileDialog
            // 
            this.saveAsFileDialog.DefaultExt = "route";
            this.saveAsFileDialog.Filter = "Route Files|*.route";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webControl);
            this.splitContainer1.Panel2.Controls.Add(this.lvStopsOld);
            this.splitContainer1.Size = new System.Drawing.Size(1601, 852);
            this.splitContainer1.SplitterDistance = 454;
            this.splitContainer1.TabIndex = 2;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.blvStops);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(454, 852);
            this.splitContainer2.SplitterDistance = 546;
            this.splitContainer2.TabIndex = 1;
            // 
            // blvStops
            // 
            this.blvStops.Columns.Add(this.bcolName);
            this.blvStops.Columns.Add(this.bcolNumberDrops);
            this.blvStops.Columns.Add(this.bcolStreet);
            this.blvStops.Columns.Add(this.bcolCity);
            this.blvStops.Columns.Add(this.bcolState);
            this.blvStops.Columns.Add(this.bcolPostalCode);
            this.blvStops.ContextMenuStrip = this.contextMenuStop;
            this.blvStops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blvStops.HideSelectionMode = ComponentOwl.BetterListView.BetterListViewHideSelectionMode.KeepSelection;
            this.blvStops.Location = new System.Drawing.Point(0, 0);
            this.blvStops.Name = "blvStops";
            this.blvStops.Size = new System.Drawing.Size(454, 546);
            this.blvStops.TabIndex = 1;
            this.blvStops.SelectedIndexChanged += new System.EventHandler(this.blvStops_SelectedIndexChanged);
            this.blvStops.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.blvStops_MouseDoubleClick);
            // 
            // bcolName
            // 
            this.bcolName.Name = "bcolName";
            this.bcolName.Text = "Name";
            this.bcolName.Width = 45;
            // 
            // bcolNumberDrops
            // 
            this.bcolNumberDrops.Name = "bcolNumberDrops";
            this.bcolNumberDrops.Text = "# Drops";
            this.bcolNumberDrops.Width = 55;
            // 
            // bcolStreet
            // 
            this.bcolStreet.Name = "bcolStreet";
            this.bcolStreet.Text = "Street";
            this.bcolStreet.Width = 150;
            // 
            // bcolCity
            // 
            this.bcolCity.Name = "bcolCity";
            this.bcolCity.Text = "City";
            this.bcolCity.Width = 60;
            // 
            // bcolState
            // 
            this.bcolState.Name = "bcolState";
            this.bcolState.Text = "State";
            this.bcolState.Width = 40;
            // 
            // bcolPostalCode
            // 
            this.bcolPostalCode.Name = "bcolPostalCode";
            this.bcolPostalCode.Text = "Zip";
            this.bcolPostalCode.Width = 160;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtStopDuration);
            this.panel1.Controls.Add(this.btnMoveDown);
            this.panel1.Controls.Add(this.btnMoveUp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRoute);
            this.panel1.Controls.Add(this.chkboxRoundTrip);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDistance);
            this.panel1.Controls.Add(this.txtDrivingDuration);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(454, 302);
            this.panel1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Stop Time (hh:mm)";
            // 
            // txtStopDuration
            // 
            this.txtStopDuration.Location = new System.Drawing.Point(228, 88);
            this.txtStopDuration.Name = "txtStopDuration";
            this.txtStopDuration.ReadOnly = true;
            this.txtStopDuration.Size = new System.Drawing.Size(100, 20);
            this.txtStopDuration.TabIndex = 12;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Location = new System.Drawing.Point(239, 33);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 10;
            this.btnMoveDown.Text = "Move Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Location = new System.Drawing.Point(133, 33);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 9;
            this.btnMoveUp.Text = "Move Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Drive Time (hh:mm)";
            // 
            // btnRoute
            // 
            this.btnRoute.Enabled = false;
            this.btnRoute.Location = new System.Drawing.Point(238, 200);
            this.btnRoute.Name = "btnRoute";
            this.btnRoute.Size = new System.Drawing.Size(111, 69);
            this.btnRoute.TabIndex = 3;
            this.btnRoute.Text = "Route";
            this.btnRoute.UseVisualStyleBackColor = true;
            this.btnRoute.Click += new System.EventHandler(this.btnRoute_Click);
            // 
            // chkboxRoundTrip
            // 
            this.chkboxRoundTrip.AutoSize = true;
            this.chkboxRoundTrip.Checked = true;
            this.chkboxRoundTrip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkboxRoundTrip.Location = new System.Drawing.Point(132, 175);
            this.chkboxRoundTrip.Name = "chkboxRoundTrip";
            this.chkboxRoundTrip.Size = new System.Drawing.Size(79, 17);
            this.chkboxRoundTrip.TabIndex = 8;
            this.chkboxRoundTrip.Text = "Round Trip";
            this.chkboxRoundTrip.UseVisualStyleBackColor = true;
            this.chkboxRoundTrip.CheckedChanged += new System.EventHandler(this.chkboxRoundTrip_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnRouteAsIs);
            this.groupBox1.Controls.Add(this.radioBtnOptimizeRoute);
            this.groupBox1.Location = new System.Drawing.Point(103, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 71);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // radioBtnRouteAsIs
            // 
            this.radioBtnRouteAsIs.AutoSize = true;
            this.radioBtnRouteAsIs.Location = new System.Drawing.Point(15, 42);
            this.radioBtnRouteAsIs.Name = "radioBtnRouteAsIs";
            this.radioBtnRouteAsIs.Size = new System.Drawing.Size(80, 17);
            this.radioBtnRouteAsIs.TabIndex = 2;
            this.radioBtnRouteAsIs.Text = "Route As-Is";
            this.radioBtnRouteAsIs.UseVisualStyleBackColor = true;
            // 
            // radioBtnOptimizeRoute
            // 
            this.radioBtnOptimizeRoute.AutoSize = true;
            this.radioBtnOptimizeRoute.Checked = true;
            this.radioBtnOptimizeRoute.Location = new System.Drawing.Point(15, 19);
            this.radioBtnOptimizeRoute.Name = "radioBtnOptimizeRoute";
            this.radioBtnOptimizeRoute.Size = new System.Drawing.Size(97, 17);
            this.radioBtnOptimizeRoute.TabIndex = 1;
            this.radioBtnOptimizeRoute.TabStop = true;
            this.radioBtnOptimizeRoute.Text = "Optimize Route";
            this.radioBtnOptimizeRoute.UseVisualStyleBackColor = true;
            this.radioBtnOptimizeRoute.CheckedChanged += new System.EventHandler(this.radioBtnOptimizeRoute_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Distance (miles)";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(228, 140);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(100, 20);
            this.txtDistance.TabIndex = 6;
            // 
            // txtDrivingDuration
            // 
            this.txtDrivingDuration.Location = new System.Drawing.Point(228, 114);
            this.txtDrivingDuration.Name = "txtDrivingDuration";
            this.txtDrivingDuration.ReadOnly = true;
            this.txtDrivingDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDrivingDuration.TabIndex = 5;
            // 
            // webControl
            // 
            this.webControl.BackColor = System.Drawing.Color.Silver;
            this.webControl.Location = new System.Drawing.Point(0, 0);
            this.webControl.Name = "webControl";
            this.webControl.Size = new System.Drawing.Size(1099, 852);
            this.webControl.TabIndex = 0;
            this.webControl.Text = "webControl";
            this.webControl.WebView = this.webView;
            // 
            // lvStopsOld
            // 
            this.lvStopsOld.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colNumberDrops,
            this.colStreet,
            this.colCity,
            this.colState,
            this.colPostalCode});
            this.lvStopsOld.ContextMenuStrip = this.contextMenuStop;
            this.lvStopsOld.FullRowSelect = true;
            this.lvStopsOld.GridLines = true;
            this.lvStopsOld.HideSelection = false;
            this.lvStopsOld.Location = new System.Drawing.Point(220, 139);
            this.lvStopsOld.Name = "lvStopsOld";
            this.lvStopsOld.Size = new System.Drawing.Size(454, 546);
            this.lvStopsOld.TabIndex = 1;
            this.lvStopsOld.UseCompatibleStateImageBehavior = false;
            this.lvStopsOld.View = System.Windows.Forms.View.Details;
            this.lvStopsOld.Visible = false;
            this.lvStopsOld.SelectedIndexChanged += new System.EventHandler(this.blvStops_SelectedIndexChanged);
            this.lvStopsOld.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.blvStops_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 40;
            // 
            // colNumberDrops
            // 
            this.colNumberDrops.Text = "# Drops";
            this.colNumberDrops.Width = 50;
            // 
            // colStreet
            // 
            this.colStreet.Text = "Street";
            this.colStreet.Width = 150;
            // 
            // colCity
            // 
            this.colCity.Text = "City";
            // 
            // colState
            // 
            this.colState.Text = "State";
            this.colState.Width = 40;
            // 
            // colPostalCode
            // 
            this.colPostalCode.Text = "Zip";
            // 
            // SplitRouteView
            // 
            this.ClientSize = new System.Drawing.Size(1601, 852);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SplitRouteView";
            this.contextMenuStop.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.blvStops)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EO.WebBrowser.WebView webView;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStop;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuAddNew;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveAsFileDialog;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuMapsConfig;
        private System.Windows.Forms.ToolStripMenuItem menuPaste;
        private System.Windows.Forms.ToolStripMenuItem menuClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.CheckBox chkboxRoundTrip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnRouteAsIs;
        private System.Windows.Forms.RadioButton radioBtnOptimizeRoute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtDrivingDuration;
        private EO.WebBrowser.WinForm.WebControl webControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStopDuration;
        private ComponentOwl.BetterListView.BetterListView blvStops;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader bcolName;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader bcolNumberDrops;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader bcolStreet;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader bcolCity;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader bcolState;
        private ComponentOwl.BetterListView.BetterListViewColumnHeader bcolPostalCode;
        private System.Windows.Forms.ListView lvStopsOld;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colNumberDrops;
        private System.Windows.Forms.ColumnHeader colStreet;
        private System.Windows.Forms.ColumnHeader colCity;
        private System.Windows.Forms.ColumnHeader colState;
        private System.Windows.Forms.ColumnHeader colPostalCode;
    }
}

