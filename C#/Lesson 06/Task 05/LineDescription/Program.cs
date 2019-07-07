using System;

namespace LineDescription
{
    class Line<T>
    {
        public class Point
        {
            private T x;
            private T y;

            public Point() { }

            public Point(T x, T y)
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

        private Point a;
        private Point b;

        public Line(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }

        public Line(T aX, T aY, T bX, T bY)
        {
            a = new Point(aX, aY);
            b = new Point(bX, bY);
        }

        public Point A
        {
            get { return a; }
            set { a = value; }
        }

        public Point B
        {
            get { return b; }
            set { b = value; }
        }

        public override string ToString()
        {
            return string.Format("({0}; {1}), ({2}; {3})", A.X, A.Y, B.X, B.Y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Line<int>.Point pA = new Line<int>.Point(), pB = new Line<int>.Point();
            double dAX, dAY, dBX, dBY;
            Console.Title = "Описание прямой на плоскости";
            try
            {
                Console.WriteLine("Введите координаты целого типа первой точки прямой на плоскости:");
                Console.Write("x = ");
                pA.X = Convert.ToInt32(Console.ReadLine());
                Console.Write("y = ");
                pA.Y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nВведите координаты целого типа второй точки прямой на плоскости:");
                Console.Write("x = ");
                pB.X = Convert.ToInt32(Console.ReadLine());
                Console.Write("y = ");
                pB.Y = Convert.ToInt32(Console.ReadLine());
                Line<int> iL = new Line<int>(pA, pB);
                Console.WriteLine("\nПрямая, заданная точками " + iL.ToString() + ", успешно создана!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            try
            {
                Console.WriteLine("\nВведите координаты вещественного типа первой точки прямой на плоскости:");
                Console.Write("x = ");
                dAX = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Console.Write("y = ");
                dAY = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Console.WriteLine("\nВведите координаты целого типа второй точки прямой на плоскости:");
                Console.Write("x = ");
                dBX = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Console.Write("y = ");
                dBY = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Line<double> dL = new Line<double>(dAX, dAY, dBX, dBY);
                Console.WriteLine("\nПрямая, заданная точками " + dL.ToString() + ", успешно создана!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            Console.ReadKey();
        }
    }
}