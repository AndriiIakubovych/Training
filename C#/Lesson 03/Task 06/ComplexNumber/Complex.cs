using System;

namespace ComplexNumber
{
    class Complex
    {
        private double x;
        private double y;

        public Complex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.x + b.x, a.y + b.y);
        }

        public static Complex operator +(Complex a, double b)
        {
            return new Complex(a.x + b, a.y);
        }

        public static Complex operator +(double a, Complex b)
        {
            return new Complex(a + b.x, b.y);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.x - b.x, a.y - b.y);
        }

        public static Complex operator -(Complex a, double b)
        {
            return new Complex(a.x - b, a.y);
        }

        public static Complex operator -(double a, Complex b)
        {
            return new Complex(a - b.x, -b.y);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.x * b.x - a.y * b.y, a.y * b.x + a.x * b.y);
        }

        public static Complex operator *(Complex a, double b)
        {
            return new Complex(a.x * b, a.y * b);
        }

        public static Complex operator *(double a, Complex b)
        {
            return new Complex(a * b.x, a * b.y);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex((a.x * b.x + a.y * b.y) / (Math.Pow(b.x, 2) + Math.Pow(b.y, 2)), (a.y * b.x - a.x * b.y) / (Math.Pow(b.x, 2) + Math.Pow(b.y, 2)));
        }

        public static Complex operator /(Complex a, double b)
        {
            return new Complex(a.x / b, a.y / b);
        }

        public static Complex operator /(double a, Complex b)
        {
            return new Complex(a * b.x / (Math.Pow(b.x, 2) + Math.Pow(b.y, 2)), -a * b.y / (Math.Pow(b.x, 2) + Math.Pow(b.y, 2)));
        }

        public override string ToString()
        {
            if (y > 0)
                return string.Format(x + " + " + y + "i");
            else
                return string.Format(x + " - " + (-y) + "i");
        }
    }
}