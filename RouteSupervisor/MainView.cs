using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RouteSupervisor
{
    public partial class MainView : Form, IMainView
    {
        #region Events
        public event EventHandler<StringEventArgs> OnAddBlankRoute;
        public event EventHandler<StringEventArgs> OnLoadRoutes;
        public event EventHandler OnRecalculateAllRoutes;
        public event EventHandler<StringEventArgs> OnRouteViewChanged;
        public event EventHandler<StringEventArgs> OnSaveAsRoutes;
        public event EventHandler OnSaveRoutes;
        public event EventHandler OnViewSummary;
        #endregion
        
        #region Event Handlers
        private void menuRecalculateAllRoutes_Click(object sender, EventArgs e)
        {
            OnRecalculateAllRoutes(sender, EventArgs.Empty);
        }
        private void menuOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                OnLoadRoutes(sender, new StringEventArgs(this.openFileDialog.FileName));
                this.openToolStripMenuItem.Enabled
                    = this.saveAsToolStripMenuItem.Enabled
                    = this.saveToolStripMenuItem.Enabled
                    = true;
            }
        }
        private void menuSave_Click(object sender, EventArgs e)
        {
            OnSaveRoutes(sender, EventArgs.Empty);
        }
        private void menuSaveAs_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveAsFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                OnSaveAsRoutes(sender, new StringEventArgs(this.saveAsFileDialog.FileName));
            }
        }
        private void menuViewSummary_Click(object sender, EventArgs e)
        {
            OnViewSummary(sender, EventArgs.Empty);
        }
        private void addNewRouteViewTabPage(string routeId)
        {
            TabPage newTabPage = new TabPage(routeId);
            newTabPage.Text 
                = newTabPage.Name
                = routeId;
            this.tabControl.TabPages.Add(newTabPage);

            this.tabControl.SelectedIndexChanged -= this.tabControl_SelectedIndexChanged;
            this.tabControl.SelectedIndex = this.tabControl.TabPages.Count - 1;
            this.tabControl.SelectedIndexChanged += this.tabControl_SelectedIndexChanged;
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                OnAddBlankRoute(sender, new StringEventArgs(string.Format("Route {0}", this.tabControl.TabPages.Count)));
            }
            OnRouteViewChanged(sender, new StringEventArgs(tabControl.TabPages[tabControl.SelectedIndex].Name));
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // Ctrl-O (Open a Saved File)
                case Keys.Control | Keys.O:
                    this.menuOpen_Click(this, EventArgs.Empty);
                    return true;

                // Ctrl-Shift-A (Save As)
                case Keys.Control | Keys.Shift | Keys.S:
                    this.menuSaveAs_Click(this, EventArgs.Empty);
                    return true;

                // Ctrl-S (Save)
                case Keys.Control | Keys.S:
                    this.menuSave_Click(this, EventArgs.Empty);
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        public MainView()
        {
            InitializeComponent();
        }
        public void AddRouteView(string routeId, IRouteView routeView)
        {
            this.addNewRouteViewTabPage(routeId);
            this.tabControl.TabPages[routeId].Controls.Add(routeView as Panel);
        }
        public void ClearAll()
        {
            this.tabControl.SelectedIndexChanged -= this.tabControl_SelectedIndexChanged;
            if (this.tabControl.TabPages.Count > 1)
            {
                do { this.tabControl.TabPages.RemoveAt(1); } 
                while (this.tabControl.TabPages.Count > 1);
            }
            this.tabControl.SelectedIndexChanged += this.tabControl_SelectedIndexChanged;
        }
        public void EnableDisableSave(bool isEnabled)
        {
            this.saveAsToolStripMenuItem.Enabled
                = this.saveToolStripMenuItem.Enabled
                = true;
        }
        public void Launch()
        {
            this.tabControl.SelectedIndex = 0;
            this.tabControl_SelectedIndexChanged(this, EventArgs.Empty);

            this.tabControl.SelectedIndex = 1;
            this.tabControl_SelectedIndexChanged(this, EventArgs.Empty);

            Application.Run(this);
        }
        public void SelectRoute(string routeId)
        {
            this.tabControl.SelectedTab = this.tabControl.TabPages[routeId];
        }
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point location = e.Location;
                location.Offset(this.Location);
                location.Offset(0, this.contextMenuTabPage.Height);
                this.contextMenuTabPage.Show(location);
            }
        }
    }
}