using Microsoft.VisualBasic.FileIO;
using SS2.Extensions.Services.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RouteSupervisor
{
    public partial class SplitRouteView : Form, IRouteView
    {
        #region Event Handlers
        private void btnRoute_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OnCalculateRoute(sender, new CalculateRouteEventArgs(this.radioBtnUseBestRoute.Checked ? RoutingMethod.BestRoute : RoutingMethod.AsIs, this.chkboxRoundTrip.Checked, this.webControl1));
            Cursor.Current = Cursors.Default;
        }
        private void lvStops_DoubleClick(object sender, EventArgs e)
        {
            menuEdit_Click(sender, EventArgs.Empty);
        }
        private void lvStops_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.menuEdit_Click(sender, EventArgs.Empty);
        }
        private void menuAddNew_Click(object sender, EventArgs e)
        {
            OnAddStop(sender, EventArgs.Empty);
        }
        private void menuDelete_Click(object sender, EventArgs e)
        {
            if (lvStops.SelectedIndices.Count > 0
                && MessageBox.Show(string.Format("Delete stop ({0})?", lvStops.Items[lvStops.SelectedIndices[0]].Text), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                OnDeleteStop(sender, new GuidEventArgs((Guid)lvStops.Items[lvStops.SelectedIndices[0]].Tag));
            }
        }
        private void menuEdit_Click(object sender, EventArgs e)
        {
            if (lvStops.SelectedIndices.Count > 0)
            {
                OnEditStop(sender, new GuidEventArgs((Guid)lvStops.Items[lvStops.SelectedIndices[0]].Tag));
            }
        }
        #endregion

        #region Events
        public event EventHandler OnAddStop;
        public event EventHandler<CalculateRouteEventArgs> OnCalculateRoute;
        public event EventHandler OnDeleteAllStops;
        public event EventHandler<GuidEventArgs> OnDeleteStop;
        public event EventHandler<GuidEventArgs> OnEditStop;
        public event EventHandler<AddStopsEventArgs> OnPasteStops;
        public event EventHandler<ReorderStopsEventArgs> OnReorderStops;
        #endregion

        public void ClearAll()
        {
            this.lvStops.Items.Clear();
            this.txtDuration.Text
                = this.txtDistance.Text
                = "";
        }
        public void PopulateRoute(List<SS2MapDeliveryPoint> stops, string fullPath)
        {
            this.Text = string.Format("RouteSupervisor{0}", fullPath != null ? string.Format(" [{0}]", fullPath) : "");

            this.lvStops.Items.Clear();

            if (stops != null && stops.Count > 0)
            {
                Color bgColor = Color.White;
                foreach (SS2MapDeliveryPoint stop in stops)
                {
                    ListViewItem lvi = new ListViewItem(stop.Description);
                    lvi.SubItems.Add(stop.Street);
                    lvi.SubItems.Add(stop.City);
                    lvi.SubItems.Add(stop.State);
                    lvi.SubItems.Add(stop.PostalCode);
                    lvi.Tag = stop.Id;
                    lvi.BackColor = bgColor;

                    // alternate background colors (white, light blue)
                    bgColor = bgColor == Color.White ? Color.Gainsboro : Color.White;

                    this.lvStops.Items.Add(lvi);
                }
                // auto-size column widths
                foreach (ColumnHeader header in this.lvStops.Columns)
                {
                    header.Width = -1;
                }
                colState.Width = -2;
                colPostalCode.Width = 75;

                this.btnRoute.Enabled = true;
                this.lvStops.Items[0].Selected = true;
            }
        }
        public void SelectStop(int index)
        {
            this.lvStops.SelectedIndexChanged -= this.lvStops_SelectedIndexChanged;
            foreach (int i in lvStops.SelectedIndices)
            {
                this.lvStops.Items[i].Selected = false;
            }
            this.lvStops.SelectedIndexChanged += this.lvStops_SelectedIndexChanged;
            this.lvStops.Items[index].Selected = true;
            this.lvStops.Select();
        }
        public void SetDefaults()
        {
            this.radioBtnUseBestRoute.Checked
                = this.chkboxRoundTrip.Checked
                = true;
        }
        public void UpdateRouteStatistics(string formattedDuration, double distance)
        {
            this.txtDuration.Text = formattedDuration;
            this.txtDistance.Text = distance.ToString("N2");
        }

        public SplitRouteView()
        {
            InitializeComponent();
        }

        private void lvStops_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMoveUp.Enabled = this.lvStops.Items.Count > 0 && this.lvStops.SelectedIndices.Count > 0 && this.lvStops.SelectedIndices[0] > 0;
            btnMoveDown.Enabled = this.lvStops.Items.Count > 0 && this.lvStops.SelectedIndices.Count > 0 && this.lvStops.SelectedIndices[0] < lvStops.Items.Count - 1;
        }

        private void reorderSelectedStop(int destinationIndex)
        {
            this.lvStops.SelectedIndexChanged -= lvStops_SelectedIndexChanged;
            int selectedIndex = this.lvStops.SelectedIndices[0];
            ListViewItem lvi = this.lvStops.Items[selectedIndex];
            this.lvStops.Items.RemoveAt(selectedIndex);
            this.lvStops.Items.Insert(destinationIndex, lvi);
            this.lvStops.SelectedIndexChanged += lvStops_SelectedIndexChanged;

            lvi.Selected = true;
            this.lvStops.Select();
            this.lvStops_SelectedIndexChanged(null, EventArgs.Empty);

            OnReorderStops(this, new ReorderStopsEventArgs(selectedIndex, destinationIndex));
        }
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            this.reorderSelectedStop(this.lvStops.SelectedIndices[0] - 1);
        }
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            this.reorderSelectedStop(this.lvStops.SelectedIndices[0] + 1);
        }
        private void menuPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsData(DataFormats.CommaSeparatedValue))
            {
                if (lvStops.Items.Count == 0
                    || MessageBox.Show("Replace existing stops?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {                    
                    List<AddEditStopEventArgs> stopsEventArgs = new List<AddEditStopEventArgs>();

                    using (TextFieldParser parser = new TextFieldParser(new MemoryStream(Encoding.UTF8.GetBytes(Clipboard.GetText()))))
                    {
                        parser.SetDelimiters(new string[] { "\t" });
                        while (!parser.EndOfData)
                        {
                            string[] fields = parser.ReadFields();
                            stopsEventArgs.Add(new AddEditStopEventArgs(fields[0], fields[1], fields[2], fields[3], fields[4], 0, 0));
                        }
                    }
                    OnPasteStops(sender, new AddStopsEventArgs(stopsEventArgs, true));
                }
            }
        }

        private void contextMenuStop_Opened(object sender, EventArgs e)
        {
            menuPaste.Enabled = Clipboard.ContainsData(DataFormats.CommaSeparatedValue);
            menuDelete.Enabled
                = menuClearAll.Enabled
                = lvStops.Items.Count > 0;
        }

        private void menuClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all stops?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                OnDeleteAllStops(sender, EventArgs.Empty);
            }
        }
    }
}