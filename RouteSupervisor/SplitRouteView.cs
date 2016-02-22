using ComponentOwl.BetterListView;
using EO.WebBrowser;
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
    public partial class SplitRouteView : Panel, IRouteView
    {
        #region Event Handlers
        private void blvStops_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.menuEdit_Click(sender, EventArgs.Empty);
        }
        private void blvStops_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMoveUp.Enabled = this.blvStops.Items.Count > 0 && this.blvStops.SelectedIndices.Count > 0 && this.blvStops.SelectedIndices[0] > 0;
            btnMoveDown.Enabled = this.blvStops.Items.Count > 0 && this.blvStops.SelectedIndices.Count > 0 && this.blvStops.SelectedIndices[0] < blvStops.Items.Count - 1;

            if (this.blvStops.SelectedIndices.Count > 0)
            {
                JSFunction isBouncing = (JSFunction)this.webView.EvalScript("isBouncing");
                if (isBouncing != null)
                {
                    if ((bool)isBouncing.Invoke(this.webView.GetDOMWindow(), new object[] { this.blvStops.SelectedIndices[0] }) == false)
                    {
                        JSFunction bounceMarker = (JSFunction)this.webView.EvalScript("bounceMarker");
                        bounceMarker.Invoke(this.webView.GetDOMWindow(), new object[] { this.blvStops.SelectedIndices[0] });
                    }
                }
            }
        }
        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            this.reorderSelectedStop(this.blvStops.SelectedIndices[0] - 1);
        }
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            this.reorderSelectedStop(this.blvStops.SelectedIndices[0] + 1);
        }
        private void btnRoute_Click(object sender, EventArgs e)
        {
            this.Route();
        }
        private void chkboxRoundTrip_CheckedChanged(object sender, EventArgs e)
        {
            OnIsRoundTripChanged(sender, new BoolEventArgs(this.chkboxRoundTrip.Checked));
        }
        private void contextMenuStop_Opened(object sender, EventArgs e)
        {
            menuPaste.Enabled = Clipboard.ContainsData(DataFormats.CommaSeparatedValue);
            menuDelete.Enabled
                = menuClearAll.Enabled
                = blvStops.Items.Count > 0;
        }
        private void menuAddNew_Click(object sender, EventArgs e)
        {
            OnAddStop(sender, EventArgs.Empty);
        }
        private void menuClearAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear all stops?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                OnDeleteAllStops(sender, EventArgs.Empty);
                this.btnMoveUp.Enabled
                    = this.btnMoveDown.Enabled
                    = false;
            }
        }
        private void menuDelete_Click(object sender, EventArgs e)
        {
            if (blvStops.SelectedIndices.Count > 0
                && MessageBox.Show(string.Format("Delete stop ({0})?", blvStops.SelectedItems[0].Text), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                OnDeleteStop(sender, new GuidEventArgs((Guid)blvStops.SelectedItems[0].Tag));
            }
        }
        private void menuEdit_Click(object sender, EventArgs e)
        {
            if (blvStops.SelectedIndices.Count > 0)
            {
                OnEditStop(sender, new GuidEventArgs((Guid)blvStops.SelectedItems[0].Tag));
            }
        }
        private void menuPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsData(DataFormats.CommaSeparatedValue))
            {
                if (blvStops.Items.Count == 0
                    || MessageBox.Show("Replace existing stops?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    List<AddEditStopEventArgs> stopsEventArgs = new List<AddEditStopEventArgs>();

                    try
                    {
                        using (TextFieldParser parser = new TextFieldParser(new MemoryStream(Encoding.UTF8.GetBytes(Clipboard.GetText()))))
                        {
                            parser.SetDelimiters(new string[] { "\t" });
                            while (!parser.EndOfData)
                            {
                                string[] fields = parser.ReadFields();
                                stopsEventArgs.Add(new AddEditStopEventArgs(fields[0], fields[1], fields[2], fields[3], fields[4], int.Parse(fields[5]), 0, 0));
                            }
                        }
                        OnPasteStops(sender, new AddStopsEventArgs(stopsEventArgs, true));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Pasted stops are in the wrong format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        private void radioBtnOptimizeRoute_CheckedChanged(object sender, EventArgs e)
        {
            OnRoutingMethodChanged(sender, new RoutingMethodEventArgs(this.radioBtnOptimizeRoute.Checked ? RoutingMethod.Optimize : RoutingMethod.AsIs));
        }
        #endregion

        #region Events
        public event EventHandler OnAddStop;
        public event EventHandler<CalculateRouteEventArgs> OnCalculateRoute;
        public event EventHandler OnDeleteAllStops;
        public event EventHandler<GuidEventArgs> OnDeleteStop;
        public event EventHandler<GuidEventArgs> OnEditStop;
        public event EventHandler<BoolEventArgs> OnIsRoundTripChanged;
        public event EventHandler<AddStopsEventArgs> OnPasteStops;
        public event EventHandler<MoveStopEventArgs> OnMoveStop;
        public event EventHandler<RoutingMethodEventArgs> OnRoutingMethodChanged;
        #endregion

        private void reorderSelectedStop(int destinationIndex)
        {
            this.blvStops.SelectedIndexChanged -= blvStops_SelectedIndexChanged;
            int selectedIndex = this.blvStops.SelectedIndices[0];
            BetterListViewItem blvi = this.blvStops.Items[selectedIndex];
            this.blvStops.Items.RemoveAt(selectedIndex);
            this.blvStops.Items.Insert(destinationIndex, blvi);
            this.blvStops.SelectedIndexChanged += blvStops_SelectedIndexChanged;

            blvi.Selected = true;
            this.blvStops.Select();
            this.blvStops_SelectedIndexChanged(null, EventArgs.Empty);

            highlightStopBackgrounds();

            OnMoveStop(this, new MoveStopEventArgs(selectedIndex, destinationIndex));
        }
        private void highlightStopBackgrounds()
        {
            Color bgColor = Color.Gainsboro;
            foreach (BetterListViewItem blvi in this.blvStops.Items)
            {
                blvi.BackColor = bgColor;

                // alternate background colors (white, light blue)
                bgColor = bgColor == Color.White ? Color.Gainsboro : Color.White;
            }
        }

        public void ClearAll()
        {
            this.blvStops.Items.Clear();
            this.txtStopDuration.Text
                = this.txtDrivingDuration.Text
                = this.txtDistance.Text
                = "";
        }
        public void PopulateRoute(List<AllMedStop> stops)
        {
            this.blvStops.SelectedIndexChanged -= this.blvStops_SelectedIndexChanged;
            this.blvStops.Items.Clear();

            if (stops != null && stops.Count > 0)
            {
                foreach (AllMedStop stop in stops)
                {
                    BetterListViewItem blvi = new BetterListViewItem(stop.Description);
                    blvi.SubItems.Add(stop.NumberDrops.ToString());
                    blvi.SubItems.Add(stop.Street);
                    blvi.SubItems.Add(stop.City);
                    blvi.SubItems.Add(stop.State);
                    blvi.SubItems.Add(stop.PostalCode);
                    blvi.Tag = stop.Id;

                    this.blvStops.Items.Add(blvi);
                }
                // auto-size column widths
                foreach (BetterListViewColumnHeader header in this.blvStops.Columns)
                {
                    header.AutoResize(BetterListViewColumnHeaderAutoResizeStyle.ColumnContent);
                }
                bcolState.AutoResize(BetterListViewColumnHeaderAutoResizeStyle.HeaderSize);
                bcolNumberDrops.AutoResize(BetterListViewColumnHeaderAutoResizeStyle.HeaderSize);
                colPostalCode.Width = 75;

                this.btnRoute.Enabled = true;
                this.blvStops.Items[0].Selected = true;
            }
            highlightStopBackgrounds();
            this.blvStops.SelectedIndexChanged += this.blvStops_SelectedIndexChanged;
        }
        public void Route()
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            OnCalculateRoute(this, new CalculateRouteEventArgs(this.radioBtnOptimizeRoute.Checked ? RoutingMethod.Optimize : RoutingMethod.AsIs, this.chkboxRoundTrip.Checked, this.webControl));
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }
        public void SelectStop(int index)
        {
            if (index != -1)
            {
                this.blvStops.SelectedIndexChanged -= this.blvStops_SelectedIndexChanged;
                foreach (int i in blvStops.SelectedIndices)
                {
                    this.blvStops.Items[i].Selected = false;
                }
                this.blvStops.SelectedIndexChanged += this.blvStops_SelectedIndexChanged;
                this.blvStops.Items[index].Selected = true;
                this.blvStops.Select();
            }
            else
            {
                this.blvStops.SelectedIndices.Clear();
            }
        }
        public void SetDefaults()
        {
            this.radioBtnOptimizeRoute.Checked
                = this.chkboxRoundTrip.Checked
                = true;
        }
        public void SetRoutingMethod(RoutingMethod routingMethod)
        {
            this.radioBtnRouteAsIs.Checked = routingMethod == RoutingMethod.AsIs;
        }
        public void UpdateRouteStatistics(string formattedDuration, string formattedStopDuration, double distance)
        {
            this.txtDrivingDuration.Text = formattedDuration;
            this.txtStopDuration.Text = formattedStopDuration;
            this.txtDistance.Text = distance.ToString("N2");
        }

        public SplitRouteView()
        {
            BetterListView.Unlock("CDD9355E-A18C-46d0-B5B8-B1086C2D75B6");
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }
    }
}