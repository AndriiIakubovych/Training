using System;
using System.Windows.Forms;

namespace RefrigeratorsShop
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            typeChoice.SelectedIndex = categoryChoice.SelectedIndex = controlChoice.SelectedIndex = consumptionChoice.SelectedIndex = camerasChoice.SelectedIndex = carrangementChoice.SelectedIndex = rdefrosting.SelectedIndex = fdefrosting.SelectedIndex = 0;
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                photoFileName.Text = openFileDialog.FileName;
        }

        private void productName_TextChanged(object sender, EventArgs e)
        {
            ok.Enabled = productName.Text.Length > 0 && width.Text.Length > 0 && height.Text.Length > 0 && depth.Text.Length > 0 && power.Text.Length > 0 && noise.Text.Length > 0 && price.Text.Length > 0 && count.Text.Length > 0;
        }

        private void width_TextChanged(object sender, EventArgs e)
        {
            productName_TextChanged(sender, e);
        }

        private void height_TextChanged(object sender, EventArgs e)
        {
            productName_TextChanged(sender, e);
        }

        private void depth_TextChanged(object sender, EventArgs e)
        {
            productName_TextChanged(sender, e);
        }

        private void power_TextChanged(object sender, EventArgs e)
        {
            productName_TextChanged(sender, e);
        }

        private void noise_TextChanged(object sender, EventArgs e)
        {
            productName_TextChanged(sender, e);
        }

        private void price_TextChanged(object sender, EventArgs e)
        {
            productName_TextChanged(sender, e);
        }

        private void count_TextChanged(object sender, EventArgs e)
        {
            productName_TextChanged(sender, e);
        }

        private void ok_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(ProductWidth) > 0 && Convert.ToDouble(ProductHeight) > 0 && Convert.ToDouble(ProductDepth) > 0 && (RVolume.Length == 0 || Convert.ToInt32(RVolume) > 0) && (FVolume.Length == 0 || Convert.ToInt32(FVolume) > 0) && Convert.ToDouble(Power) > 0 && Convert.ToDouble(Noise) > 0 && Convert.ToDouble(Price) > 0 && Convert.ToInt32(Count) > 0)
                    ok.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Некоторые значения введены неверно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string ProductNameData
        {
            get { return productName.Text; }
        }

        public string PhotoFileName
        {
            get { return photoFileName.Text; }
        }

        public string Type
        {
            get { return typeChoice.Text; }
        }

        public string Category
        {
            get { return categoryChoice.Text; }
        }

        public string Control
        {
            get { return controlChoice.Text; }
        }

        public string Consumption
        {
            get { return consumptionChoice.Text; }
        }

        public string Cameras
        {
            get { return camerasChoice.Text; }
        }

        public string CArrangement
        {
            get { return carrangementChoice.Text; }
        }

        public string ProductWidth
        {
            get { return width.Text; }
        }

        public string ProductHeight
        {
            get { return height.Text; }
        }

        public string ProductDepth
        {
            get { return depth.Text; }
        }

        public string RVolume
        {
            get { return rvolume.Text; }
        }

        public string FVolume
        {
            get { return fvolume.Text; }
        }

        public string RDefrosting
        {
            get { return rdefrosting.Text; }
        }

        public string FDefrosting
        {
            get { return fdefrosting.Text; }
        }

        public string Power
        {
            get { return power.Text; }
        }

        public string Noise
        {
            get { return noise.Text; }
        }

        public string Price
        {
            get { return price.Text; }
        }

        public string Count
        {
            get { return count.Text; }
        }
    }
}