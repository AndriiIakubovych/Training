namespace PointDescription
{
    class Point3D : Point2D<double>
    {
        private double z;

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double Z
        {
            get { return z; }
            set { z = value; }
        }

        public override string ToString()
        {
            return string.Format("({0}; {1}; {2})", x, y, z);
        }
    }
}