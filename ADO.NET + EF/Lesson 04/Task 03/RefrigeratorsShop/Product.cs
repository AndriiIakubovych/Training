using System.Drawing;

namespace RefrigeratorsShop
{
    public class Product
    {
        private int id;
        private string name;
        private Image photo;
        private string type;
        private string category;
        private string control;
        private string consumption;
        private int cameras;
        private string carrangement;
        private double width;
        private double height;
        private double depth;
        private int rvolume;
        private int fvolume;
        private string rdefrosting;
        private string fdefrosting;
        private double power;
        private double noise;
        private double price;
        private int count;

        public Product() { }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Image Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Control
        {
            get { return control; }
            set { control = value; }
        }

        public string Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }

        public int Cameras
        {
            get { return cameras; }
            set { cameras = value; }
        }

        public string CArrangement
        {
            get { return carrangement; }
            set { carrangement = value; }
        }

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double Depth
        {
            get { return depth; }
            set { depth = value; }
        }

        public int RVolume
        {
            get { return rvolume; }
            set { rvolume = value; }
        }

        public int FVolume
        {
            get { return fvolume; }
            set { fvolume = value; }
        }

        public string RDefrosting
        {
            get { return rdefrosting; }
            set { rdefrosting = value; }
        }

        public string FDefrosting
        {
            get { return fdefrosting; }
            set { fdefrosting = value; }
        }

        public double Power
        {
            get { return power; }
            set { power = value; }
        }

        public double Noise
        {
            get { return noise; }
            set { noise = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}