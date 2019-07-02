namespace PointDescription
{
    class Point2D<T>
    {
        protected T x;
        protected T y;

        public Point2D()
        {
            x = default(T);
            y = default(T);
        }

        public Point2D(T x, T y)
        {
            this.x = x;
            this.y = y;
        }

        public T X
        {
            get { return x; }
            set { x = value; }
        }

        public T Y
        {
            get { return y; }
            set { y = value; }
        }
    }
}