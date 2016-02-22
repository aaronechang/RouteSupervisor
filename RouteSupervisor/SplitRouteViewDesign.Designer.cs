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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
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
            this.lvStops = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStreet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPostalCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRoute = new System.Windows.Forms.Button();
            this.chkboxRoundTrip = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnRouteAsIs = new System.Windows.Forms.RadioButton();
            this.radioBtnUseBestRoute = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.webControl1 = new EO.WebBrowser.WinForm.WebControl();
            this.contextMenuStop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1335, 24);
            this.menuStrip1.TabIndex = 4;
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1551, 865);
            this.splitContainer1.SplitterDistance = 420;
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
            this.splitContainer2.Panel1.Controls.Add(this.lvStops);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(420, 865);
            this.splitContainer2.SplitterDistance = 556;
            this.splitContainer2.TabIndex = 1;
            // 
            // lvStops
            // 
            this.lvStops.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colStreet,
            this.colCity,
            this.colState,
            this.colPostalCode});
            this.lvStops.ContextMenuStrip = this.contextMenuStop;
            this.lvStops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStops.FullRowSelect = true;
            this.lvStops.GridLines = true;
            this.lvStops.HideSelection = false;
            this.lvStops.Location = new System.Drawing.Point(0, 0);
            this.lvStops.Name = "lvStops";
            this.lvStops.Size = new System.Drawing.Size(420, 556);
            this.lvStops.TabIndex = 1;
            this.lvStops.UseCompatibleStateImageBehavior = false;
            this.lvStops.View = System.Windows.Forms.View.Details;
            this.lvStops.SelectedIndexChanged += new System.EventHandler(this.lvStops_SelectedIndexChanged);
            this.lvStops.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvStops_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 40;
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMoveDown);
            this.panel1.Controls.Add(this.btnMoveUp);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRoute);
            this.panel1.Controls.Add(this.chkboxRoundTrip);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDistance);
            this.panel1.Controls.Add(this.txtDuration);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(420, 305);
            this.panel1.TabIndex = 11;
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Location = new System.Drawing.Point(221, 26);
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
            this.btnMoveUp.Location = new System.Drawing.Point(115, 26);
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
            this.label1.Location = new System.Drawing.Point(113, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Duration (hh:mm)";
            // 
            // btnRoute
            // 
            this.btnRoute.Enabled = false;
            this.btnRoute.Location = new System.Drawing.Point(221, 164);
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
            this.chkboxRoundTrip.Location = new System.Drawing.Point(115, 139);
            this.chkboxRoundTrip.Name = "chkboxRoundTrip";
            this.chkboxRoundTrip.Size = new System.Drawing.Size(79, 17);
            this.chkboxRoundTrip.TabIndex = 8;
            this.chkboxRoundTrip.Text = "Round Trip";
            this.chkboxRoundTrip.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnRouteAsIs);
            this.groupBox1.Controls.Add(this.radioBtnUseBestRoute);
            this.groupBox1.Location = new System.Drawing.Point(86, 162);
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
            // radioBtnUseBestRoute
            // 
            this.radioBtnUseBestRoute.AutoSize = true;
            this.radioBtnUseBestRoute.Checked = true;
            this.radioBtnUseBestRoute.Location = new System.Drawing.Point(15, 19);
            this.radioBtnUseBestRoute.Name = "radioBtnUseBestRoute";
            this.radioBtnUseBestRoute.Size = new System.Drawing.Size(97, 17);
            this.radioBtnUseBestRoute.TabIndex = 1;
            this.radioBtnUseBestRoute.TabStop = true;
            this.radioBtnUseBestRoute.Text = "Optimize Route";
            this.radioBtnUseBestRoute.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Distance (miles)";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(206, 104);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.ReadOnly = true;
            this.txtDistance.Size = new System.Drawing.Size(100, 20);
            this.txtDistance.TabIndex = 6;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(206, 78);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.ReadOnly = true;
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 5;
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.Silver;
            this.webControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webControl1.Location = new System.Drawing.Point(0, 0);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(1127, 865);
            this.webControl1.TabIndex = 0;
            this.webControl1.Text = "webControl";
            this.webControl1.WebView = this.webView;
            // 
            // SplitRouteView
            // 
            this.ClientSize = new System.Drawing.Size(1335, 705);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EO.WebBrowser.WebView webView;
        private System.Windows.Forms.MenuStrip menuStrip1;
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
        private System.Windows.Forms.ListView lvStops;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colStreet;
        private System.Windows.Forms.ColumnHeader colCity;
        private System.Windows.Forms.ColumnHeader colState;
        private System.Windows.Forms.ColumnHeader colPostalCode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRoute;
        private System.Windows.Forms.CheckBox chkboxRoundTrip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnRouteAsIs;
        private System.Windows.Forms.RadioButton radioBtnUseBestRoute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.TextBox txtDuration;
        private EO.WebBrowser.WinForm.WebControl webControl1;
    }
}

