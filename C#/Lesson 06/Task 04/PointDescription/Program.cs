using System;

namespace PointDescription
{
    class Program
    {
        static void Main(string[] args)
        {
            int iX, iY;
            double dX, dY, dZ;
            Console.Title = "Описание точки в пространстве";
            try
            {
                Console.WriteLine("Введите координаты целого типа точки в 2-х мерном пространстве:");
                Console.Write("x = ");
                iX = Convert.ToInt32(Console.ReadLine());
                Console.Write("y = ");
                iY = Convert.ToInt32(Console.ReadLine());
                Point2D<int> iP = new Point2D<int>(iX, iY);
                Console.WriteLine("\nТочка с координатами ({0}; {1}) в 2-х мерном пространстве успешно создана!", iP.X, iP.Y);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            try
            {
                Console.WriteLine("\nВведите координаты вещественного типа точки в 2-х мерном пространстве:");
                Console.Write("x = ");
                dX = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Console.Write("y = ");
                dY = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Point2D<double> dP = new Point2D<double>(dX, dY);
                Console.WriteLine("\nТочка с координатами ({0}; {1}) в 2-х мерном пространстве успешно создана!", dP.X, dP.Y);
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            try
            {
                Console.WriteLine("\nВведите координаты вещественного типа точки в 3-х мерном пространстве:");
                Console.Write("x = ");
                dX = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Console.Write("y = ");
                dY = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Console.Write("z = ");
                dZ = Math.Round(Convert.ToDouble(Console.ReadLine()), 1);
                Point3D P = new Point3D(dX, dY, dZ);
                Console.WriteLine("\nТочка с координатами " + P.ToString() + " в 3-х мерном пространстве успешно создана!");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка ввода!");
            }
            Console.ReadKey();
        }
    }
}