using System;
using System.Windows.Forms;

namespace CarShowroom
{
    public partial class AddCarForm : Form
    {
        public AddCarForm()
        {
            InitializeComponent();
            engineType.SelectedIndex = transmission.SelectedIndex = drive.SelectedIndex = 0;
        }

        private void carName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = carName.Text.Length > 0 && carPhoto.Text.Length > 0;
        }

        private void carPhoto_TextChanged(object sender, EventArgs e)
        {
            carName_TextChanged(sender, e);
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                carPhoto.Text = openFileDialog.FileName;
        }

        public string CarName
        {
            get { return carName.Text; }
        }

        public string CarPhoto
        {
            get { return carPhoto.Text; }
        }

        public string EngineType
        {
            get { return engineType.Text; }
        }

        public string EngineVolume
        {
            get { return engineVolume.Text; }
        }

        public string Power
        {
            get { return power.Text; }
        }

        public string Acceleration
        {
            get { return acceleration.Text; }
        }

        public string MaxSpeed
        {
            get { return maxSpeed.Text; }
        }

        public string FuelTankCapacity
        {
            get { return fuelTankCapacity.Text; }
        }

        public string Transmission
        {
            get { return transmission.Text; }
        }

        public string Drive
        {
            get { return drive.Text; }
        }

        public string Weight
        {
            get { return weight.Text; }
        }

        public string Price
        {
            get { return price.Text; }
        }
    }
}