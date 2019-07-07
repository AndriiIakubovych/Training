using System;
using System.IO;
using System.Windows.Forms;

namespace CarShowroom
{
    public partial class EditCarForm : Form
    {
        public EditCarForm()
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
            openFileDialog.InitialDirectory = Path.GetDirectoryName(CarPhoto);
            openFileDialog.FileName = Path.GetFileName(CarPhoto);
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                carPhoto.Text = openFileDialog.FileName;
        }

        public string CarName
        {
            get { return carName.Text; }
            set { carName.Text = value; }
        }

        public string CarPhoto
        {
            get { return carPhoto.Text; }
            set { carPhoto.Text = value; }
        }

        public string EngineType
        {
            get { return engineType.Text; }
            set { engineType.Text = value; }
        }

        public string EngineVolume
        {
            get { return engineVolume.Text; }
            set { engineVolume.Text = value; }
        }

        public string Power
        {
            get { return power.Text; }
            set { power.Text = value; }
        }

        public string Acceleration
        {
            get { return acceleration.Text; }
            set { acceleration.Text = value; }
        }

        public string MaxSpeed
        {
            get { return maxSpeed.Text; }
            set { maxSpeed.Text = value; }
        }

        public string FuelTankCapacity
        {
            get { return fuelTankCapacity.Text; }
            set { fuelTankCapacity.Text = value; }
        }

        public string Transmission
        {
            get { return transmission.Text; }
            set { transmission.Text = value; }
        }

        public string Drive
        {
            get { return drive.Text; }
            set { drive.Text = value; }
        }

        public string Weight
        {
            get { return weight.Text; }
            set { weight.Text = value; }
        }

        public string Price
        {
            get { return price.Text; }
            set { price.Text = value; }
        }
    }
}