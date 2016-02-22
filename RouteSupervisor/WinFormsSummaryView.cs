using SS2.Extensions.Services.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RouteSupervisor
{
    public partial class WinFormsSummaryView : Form, ISummaryView
    {
        public event EventHandler<StringEventArgs> OnViewRoute;

        private void lvRoutes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lvRoutes.SelectedIndices.Count > 0)
            {
                OnViewRoute(sender, new StringEventArgs(this.lvRoutes.Items[lvRoutes.SelectedIndices[0]].SubItems[0].Text));
            }
        }

        public void Launch()
        {
            this.Show();
        }
        public void PopulateRoutes(List<AllMedRoute> routes)
        {
            lvRoutes.Items.Clear();
            if (routes != null && routes.Count > 0)
            {
                Color bgColor = Color.Gainsboro;
                foreach (AllMedRoute route in routes)
                {
                    if (route.Stops.Count > 0)
                    {
                        ListViewItem lvi = new ListViewItem(route.Description);
                        lvi.SubItems.Add((route.Stops.Count + (route.IsRoundTrip ? 1 : 0)).ToString());
                        lvi.SubItems.Add(route.FormattedTime);
                        lvi.SubItems.Add(route.Distance.ToString("N2"));
                        lvi.SubItems.Add(route.RoutingMethod == RoutingMethod.AsIs ? "As Is" : "Optimize");
                        lvi.SubItems.Add(route.IsRoundTrip ? "Yes" : "No");
                        lvi.BackColor = bgColor;

                        // alternate background colors (white, light blue)
                        bgColor = bgColor == Color.White ? Color.Gainsboro : Color.White;

                        this.lvRoutes.Items.Add(lvi);
                    }
                }
            }
        }
        public WinFormsSummaryView()
        {
            InitializeComponent();
        }

        private void WinFormsSummaryView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
