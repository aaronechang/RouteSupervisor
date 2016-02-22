using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RouteSupervisor
{
    public partial class WinFormsStopView : Form, IStopView
    {
        bool _changed;

        public event EventHandler<AddStopsEventArgs> OnAddStop;
        public event EventHandler<GuidEventArgs> OnDeleteStop;
        public event EventHandler<AddEditStopEventArgs> OnEditStop;
        public event EventHandler<GeocodeStopEventArgs> OnGeocodeStop;

        public WinFormsStopView()
        {
            InitializeComponent();
        }

        private void btnGeocode_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OnGeocodeStop(sender, new GeocodeStopEventArgs(
                    this.txtStreet.Text.Trim()
                    , this.txtCity.Text.Trim()
                    , this.txtState.Text.Trim()
                    , this.txtPostalCode.Text.Trim()
                )
            );
            Cursor.Current = Cursors.Default;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblId.Tag != null)
            {
                OnEditStop(sender, new AddEditStopEventArgs(
                        (Guid)lblId.Tag
                        , this.Text.Trim()
                        , this.txtStreet.Text.Trim()
                        , this.txtCity.Text.Trim()
                        , this.txtState.Text.Trim()
                        , this.txtPostalCode.Text.Trim()
                        , (int)this.numNumberDrops.Value
                        , this.txtLatitude.Text.Trim().Length > 0 ? double.Parse(this.txtLatitude.Text.Trim()) : 0
                        , this.txtLongitude.Text.Trim().Length > 0 ? double.Parse(this.txtLongitude.Text.Trim()) : 0
                    )
                );
            }
            else
            {
                OnAddStop(sender, new AddStopsEventArgs(
                    new List<AddEditStopEventArgs>(1) { 
                        new AddEditStopEventArgs(
                            this.txtName.Text.Trim()
                            , this.txtStreet.Text.Trim()
                            , this.txtCity.Text.Trim()
                            , this.txtState.Text.Trim()
                            , this.txtPostalCode.Text.Trim()
                            , (int)this.numNumberDrops.Value
                            , this.txtLatitude.Text.Trim().Length > 0 ? double.Parse(this.txtLatitude.Text.Trim()) : 0
                            , this.txtLongitude.Text.Trim().Length > 0 ? double.Parse(this.txtLongitude.Text.Trim()) : 0
                            )
                        }
                        , false
                    )
                );
            }
            _changed = false;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Delete stop ({0})?", this.Text), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                OnDeleteStop(sender, new GuidEventArgs((Guid)lblId.Tag));
                this.Close();
            }
        }
        private void controlChanged(object sender, EventArgs e)
        {
            if (!_changed)
            {
                _changed = true;
            }
        }
        private void WinFormsStopView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_changed
                || MessageBox.Show("Cancel all changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                // cancel the FormClosing event so that we can open it again later
                e.Cancel = true;

                this.Text = "<New Stop>";
                this.Hide();
                foreach (Control control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        control.Text = "";
                        (control as TextBox).TextChanged -= controlChanged;
                    }
                }
            }
        }    

        public void Launch(bool showNameField)
        {
            this.Show();
            showHideNameField(showNameField);
        }
        public void PopulateStop(Guid id, string description, string street, string city, string state, string postalCode, double latitude, double longitude)
        {
            lblId.Tag = id;
            this.Text = description;
            txtStreet.Text = street;
            txtCity.Text = city;
            txtState.Text = state;
            txtPostalCode.Text = postalCode;

            this.PopulateGeocode(latitude, longitude);

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).TextChanged += controlChanged;
                }
                else if (control is NumericUpDown)
                {
                    (control as NumericUpDown).ValueChanged += controlChanged;
                }
            }
            _changed = false;
        }
        public void PopulateGeocode(double latitude, double longitude)
        {
            this.txtLatitude.Text = latitude.ToString();
            this.txtLongitude.Text = longitude.ToString();
        }
        public void showHideNameField(bool showNameField)
        {
            if (showNameField && !this.lblName.Visible && !this.txtName.Visible
                || !showNameField && this.lblName.Visible && this.txtName.Visible)
            {
                this.lblName.Visible = this.txtName.Visible
                    = showNameField;

                foreach (Control control in this.Controls)
                {
                    control.Location = new Point(control.Location.X, control.Location.Y + (showNameField ? 26 : -26));
                    if (control.TabIndex == 0)
                    {
                        control.Focus();
                    }
                }
                this.Size = new Size(this.Size.Width, this.Size.Height + (showNameField ? 26 : -26));
            }
        }
    }
}