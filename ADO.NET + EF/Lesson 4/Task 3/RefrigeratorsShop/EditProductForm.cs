using System;
using System.Windows.Forms;

namespace RefrigeratorsShop
{
    public partial class EditProductForm : Form
    {
        public EditProductForm()
        {
            InitializeComponent();
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

        private void changePhoto_CheckedChanged(object sender, EventArgs e)
        {
            photoFileName.Clear();
            photoFileName.Enabled = openFile.Enabled = changePhoto.Checked;
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
                if (Convert.ToDouble(ProductWidth) > 0 && Convert.ToDouble(ProductHeight) > 0 && Convert.ToDouble(ProductDepth) > 0 && (RVolume.Length == 0 || Convert.ToDouble(RVolume) > 0) && (FVolume.Length == 0 || Convert.ToDouble(FVolume) > 0) && Convert.ToDouble(Power) > 0 && Convert.ToDouble(Noise) > 0 && Convert.ToDouble(Price) > 0 && Convert.ToInt32(Count) > 0)
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
            set { productName.Text = value; }
        }

        public bool ChangePhoto
        {
            get { return changePhoto.Checked; }
        }

        public string PhotoFileName
        {
            get { return photoFileName.Text; }
            set { photoFileName.Text = value; }
        }

        public string Type
        {
            get { return typeChoice.Text; }
            set { typeChoice.Text = value; }
        }

        public string Category
        {
            get { return categoryChoice.Text; }
            set { categoryChoice.Text = value; }
        }

        public string Control
        {
            get { return controlChoice.Text; }
            set { controlChoice.Text = value; }
        }

        public string Consumption
        {
            get { return consumptionChoice.Text; }
            set { consumptionChoice.Text = value; }
        }

        public string Cameras
        {
            get { return camerasChoice.Text; }
            set { camerasChoice.Text = value; }
        }

        public string CArrangement
        {
            get { return carrangementChoice.Text; }
            set { carrangementChoice.Text = value; }
        }

        public string ProductWidth
        {
            get { return width.Text; }
            set { width.Text = value; }
        }

        public string ProductHeight
        {
            get { return height.Text; }
            set { height.Text = value; }
        }

        public string ProductDepth
        {
            get { return depth.Text; }
            set { depth.Text = value; }
        }

        public string RVolume
        {
            get { return rvolume.Text; }
            set { rvolume.Text = value; }
        }

        public string FVolume
        {
            get { return fvolume.Text; }
            set { fvolume.Text = value; }
        }

        public string RDefrosting
        {
            get { return rdefrosting.Text; }
            set { rdefrosting.Text = value; }
        }

        public string FDefrosting
        {
            get { return fdefrosting.Text; }
            set { fdefrosting.Text = value; }
        }

        public string Power
        {
            get { return power.Text; }
            set { power.Text = value; }
        }

        public string Noise
        {
            get { return noise.Text; }
            set { noise.Text = value; }
        }

        public string Price
        {
            get { return price.Text; }
            set { price.Text = value; }
        }

        public string Count
        {
            get { return count.Text; }
            set { count.Text = value; }
        }
    }
}