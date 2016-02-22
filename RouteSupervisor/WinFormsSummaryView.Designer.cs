namespace RouteSupervisor
{
    partial class WinFormsSummaryView
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
            this.lvRoutes = new System.Windows.Forms.ListView();
            this.colRouteId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumberStops = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDuration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRoutingMethod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRoundTrip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvRoutes
            // 
            this.lvRoutes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRouteId,
            this.colNumberStops,
            this.colDuration,
            this.colDistance,
            this.colRoutingMethod,
            this.colRoundTrip});
            this.lvRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRoutes.Location = new System.Drawing.Point(0, 0);
            this.lvRoutes.Name = "lvRoutes";
            this.lvRoutes.Size = new System.Drawing.Size(513, 425);
            this.lvRoutes.TabIndex = 0;
            this.lvRoutes.UseCompatibleStateImageBehavior = false;
            this.lvRoutes.View = System.Windows.Forms.View.Details;
            this.lvRoutes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvRoutes_MouseDoubleClick);
            // 
            // colRouteId
            // 
            this.colRouteId.Text = "Route ID";
            this.colRouteId.Width = 70;
            // 
            // colNumberStops
            // 
            this.colNumberStops.Text = "# Stops";
            this.colNumberStops.Width = 50;
            // 
            // colDuration
            // 
            this.colDuration.Text = "Duration (hh:mm)";
            this.colDuration.Width = 100;
            // 
            // colDistance
            // 
            this.colDistance.Text = "Distance (miles)";
            this.colDistance.Width = 100;
            // 
            // colRoutingMethod
            // 
            this.colRoutingMethod.Text = "Routing Method";
            this.colRoutingMethod.Width = 100;
            // 
            // colRoundTrip
            // 
            this.colRoundTrip.Text = "Round Trip?";
            this.colRoundTrip.Width = 75;
            // 
            // WinFormsSummaryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 425);
            this.Controls.Add(this.lvRoutes);
            this.Name = "WinFormsSummaryView";
            this.ShowIcon = false;
            this.Text = "Routes Summary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinFormsSummaryView_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvRoutes;
        private System.Windows.Forms.ColumnHeader colRouteId;
        private System.Windows.Forms.ColumnHeader colNumberStops;
        private System.Windows.Forms.ColumnHeader colDuration;
        private System.Windows.Forms.ColumnHeader colDistance;
        private System.Windows.Forms.ColumnHeader colRoutingMethod;
        private System.Windows.Forms.ColumnHeader colRoundTrip;
    }
}