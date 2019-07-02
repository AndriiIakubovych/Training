using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarShowroom
{
    public partial class MainForm : Form
    {
        private ICarsInfo carsInfo = new ShowroomProxy();
        private Image noImage;

        public MainForm()
        {
            string[] files;
            string file;
            InitializeComponent();
            noImage = carImage.Image;
            foreach (Car c in carsInfo.GetCars())
                carsNamesList.Items.Add(c.CarName);
            if (carsNamesList.Items.Count > 0)
                carsNamesList.SelectedIndex = 0;
            editToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = editToolStripButton.Enabled = deleteToolStripButton.Enabled = carsNamesList.Items.Count > 0;
            files = Directory.GetFiles("images");
            for (int i = 0; i < files.Length; i++)
            {
                file = Path.GetFileName(files[i]);
                if (!carsInfo.HasCarWithPhoto(file))
                    File.Delete(files[i]);
            }
        }

        private void carsNamesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FileStream fs;
            Car car;
            if (carsNamesList.SelectedIndex >= 0)
            {
                car = carsInfo.GetCar(carsNamesList.SelectedItem.ToString());
                carId.Text = car.CarId.ToString();
                carName.Text = car.CarName.ToUpper();
                if (File.Exists("images\\" + car.CarPhoto))
                {
                    fs = new FileStream("images\\" + car.CarPhoto, FileMode.Open, FileAccess.Read);
                    carImage.Image = Image.FromStream(fs);
                }
                else
                    carImage.Image = noImage;
                engineType.Text = car.EngineType;
                engineVolume.Text = car.EngineVolume.ToString();
                power.Text = car.Power.ToString() + " л. с.";
                acceleration.Text = car.Acceleration.ToString() + " с";
                maxSpeed.Text = car.MaxSpeed.ToString() + " км/ч";
                fuelTankCapacity.Text = car.FuelTankCapacity.ToString() + " л";
                transmission.Text = car.Transmission;
                drive.Text = car.Drive;
                weight.Text = car.Weight + " кг";
                price.Text = car.Price + " грн.";
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCarForm addCarForm = new AddCarForm();
            Car car = new Car();
            bool isFileExists = true;
            string fileName;
            if (addCarForm.ShowDialog() == DialogResult.OK)
            {
                car.CarId = carsInfo.GetMaxCarId();
                car.CarName = addCarForm.CarName;
                if (Path.GetDirectoryName(addCarForm.CarPhoto) != Environment.CurrentDirectory + "\\images")
                {
                    if (!Directory.Exists("images"))
                        Directory.CreateDirectory("images");
                    fileName = Path.GetFileNameWithoutExtension(addCarForm.CarPhoto);
                    while (isFileExists)
                    {
                        isFileExists = File.Exists("images\\" + fileName + Path.GetExtension(addCarForm.CarPhoto));
                        if (!isFileExists)
                            break;
                        fileName += "-1";
                    }
                    File.Copy(addCarForm.CarPhoto, "images\\" + fileName + Path.GetExtension(addCarForm.CarPhoto));
                    car.CarPhoto = fileName + Path.GetExtension(addCarForm.CarPhoto);
                }
                else
                    car.CarPhoto = Path.GetFileName(addCarForm.CarPhoto);
                car.EngineType = addCarForm.EngineType;
                car.EngineVolume = addCarForm.EngineVolume.Length > 0 ? Convert.ToInt32(addCarForm.EngineVolume) : 0;
                car.Power = addCarForm.Power.Length > 0 ? Convert.ToInt32(addCarForm.Power) : 0;
                car.Acceleration = addCarForm.Acceleration.Length > 0 ? Convert.ToInt32(addCarForm.Acceleration) : 0;
                car.MaxSpeed = addCarForm.MaxSpeed.Length > 0 ? Convert.ToInt32(addCarForm.MaxSpeed) : 0;
                car.FuelTankCapacity = addCarForm.FuelTankCapacity.Length > 0 ? Convert.ToInt32(addCarForm.FuelTankCapacity) : 0;
                car.Transmission = addCarForm.Transmission;
                car.Drive = addCarForm.Drive;
                car.Weight = addCarForm.Weight.Length > 0 ? Convert.ToDouble(addCarForm.Weight) : 0;
                car.Price = addCarForm.Price.Length > 0 ? Convert.ToInt32(addCarForm.Price) : 0;
                carsInfo.AddCar(car);
                carsNamesList.Items.Add(addCarForm.CarName);
                for (int i = 0; i < carsNamesList.Items.Count; i++)
                    if (carsNamesList.Items[i].ToString() == addCarForm.CarName)
                    {
                        carsNamesList.SelectedIndex = i;
                        break;
                    }
                editToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = editToolStripButton.Enabled = deleteToolStripButton.Enabled = carsNamesList.Items.Count > 0;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCarForm editCarForm = new EditCarForm();
            Car car = carsInfo.GetCar((string)carsNamesList.SelectedItem);
            bool isFileExists = true;
            string oldCarName, fileName;
            try
            {
                oldCarName = car.CarName;
                editCarForm.CarName = car.CarName;
                editCarForm.CarPhoto = Environment.CurrentDirectory + "\\images\\" + car.CarPhoto;
                editCarForm.EngineType = car.EngineType;
                editCarForm.EngineVolume = car.EngineVolume.ToString();
                editCarForm.Power = car.Power.ToString();
                editCarForm.Acceleration = car.Acceleration.ToString();
                editCarForm.MaxSpeed = car.MaxSpeed.ToString();
                editCarForm.FuelTankCapacity = car.FuelTankCapacity.ToString();
                editCarForm.Transmission = car.Transmission;
                editCarForm.Drive = car.Drive;
                editCarForm.Weight = car.Weight.ToString();
                editCarForm.Price = car.Price.ToString();
                if (editCarForm.ShowDialog() == DialogResult.OK)
                {
                    car.CarName = editCarForm.CarName;
                    if (Path.GetDirectoryName(editCarForm.CarPhoto) != Environment.CurrentDirectory + "\\images")
                    {
                        if (!Directory.Exists("images"))
                            Directory.CreateDirectory("images");
                        fileName = Path.GetFileNameWithoutExtension(editCarForm.CarPhoto);
                        while (isFileExists)
                        {
                            isFileExists = File.Exists("images\\" + fileName + Path.GetExtension(editCarForm.CarPhoto));
                            if (!isFileExists)
                                break;
                            fileName += "-1";
                        }
                        File.Copy(editCarForm.CarPhoto, "images\\" + fileName + Path.GetExtension(editCarForm.CarPhoto));
                        car.CarPhoto = fileName + Path.GetExtension(editCarForm.CarPhoto);
                    }
                    else
                        car.CarPhoto = Path.GetFileName(editCarForm.CarPhoto);
                    car.EngineType = editCarForm.EngineType;
                    car.EngineVolume = editCarForm.EngineVolume.Length > 0 ? Convert.ToInt32(editCarForm.EngineVolume) : 0;
                    car.Power = editCarForm.Power.Length > 0 ? Convert.ToInt32(editCarForm.Power) : 0;
                    car.Acceleration = editCarForm.Acceleration.Length > 0 ? Convert.ToInt32(editCarForm.Acceleration) : 0;
                    car.MaxSpeed = editCarForm.MaxSpeed.Length > 0 ? Convert.ToInt32(editCarForm.MaxSpeed) : 0;
                    car.FuelTankCapacity = editCarForm.FuelTankCapacity.Length > 0 ? Convert.ToInt32(editCarForm.FuelTankCapacity) : 0;
                    car.Transmission = editCarForm.Transmission;
                    car.Drive = editCarForm.Drive;
                    car.Weight = editCarForm.Weight.Length > 0 ? Convert.ToDouble(editCarForm.Weight) : 0;
                    car.Price = editCarForm.Price.Length > 0 ? Convert.ToInt32(editCarForm.Price) : 0;
                    carsInfo.EditCar(car);
                    for (int i = 0; i < carsNamesList.Items.Count; i++)
                        if (carsNamesList.Items[i].ToString() == oldCarName)
                        {
                            carsNamesList.Items[i] = car.CarName;
                            carsNamesList.SelectedIndex = 0;
                            break;
                        }
                }
            }
            catch (Exception) { }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = carsNamesList.SelectedIndex;
            if (MessageBox.Show("Вы действительно хотите удалить данные об автомобиле?", "Удаление данных", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                carsInfo.DeleteCar(carsInfo.GetCar((string)carsNamesList.SelectedItem));
                carsNamesList.Items.RemoveAt(index);
                carsNamesList.SelectedIndex = index > 0 ? index - 1 : 0;
                editToolStripMenuItem.Enabled = deleteToolStripMenuItem.Enabled = editToolStripButton.Enabled = deleteToolStripButton.Enabled = carsNamesList.Items.Count > 0;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addToolStripButton_Click(object sender, EventArgs e)
        {
            addToolStripMenuItem_Click(sender, e);
        }

        private void editToolStripButton_Click(object sender, EventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }

        private void deleteToolStripButton_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem_Click(sender, e);
        }

        private void exitToolStripButton_Click(object sender, EventArgs e)
        {
            exitToolStripMenuItem_Click(sender, e);
        }

        private void carsNamesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (carsNamesList.Items.Count > 0 && carsNamesList.IndexFromPoint(e.Location) != ListBox.NoMatches)
                editToolStripMenuItem_Click(sender, e);
        }
    }
}