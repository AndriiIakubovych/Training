using System;
using System.Text;
using System.Collections.Generic;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstSideLength, secondSideLength, thirdSideLength, height, radius, semiMayorAxis, semiMinorAxis, x, y;
            int polygonsCount, sidesCount;
            List<Point> coordinates = new List<Point>();
            Polygon[] polygon;
            Console.Title = "Геометрические фигуры";
            ConsoleFont.SetConsoleFont();
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.Write("Введите длину первой стороны треугольника (см): ");
                firstSideLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину второй стороны треугольника (cм): ");
                secondSideLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину третей стороны треугольника (cм): ");
                thirdSideLength = Convert.ToDouble(Console.ReadLine());
                Triangle triangle = new Triangle(firstSideLength, secondSideLength, thirdSideLength);
                if (triangle.FigureSquare > 0 && triangle.FigurePerimeter > 0)
                {
                    Console.WriteLine("\nПлощадь треугольника: " + triangle.FigureSquare + " см\u00B2");
                    Console.WriteLine("Периметр треугольника: " + triangle.FigurePerimeter + " см");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            try
            {
                Console.Write("\nВведите длину стороны квадрата (см): ");
                firstSideLength = Convert.ToDouble(Console.ReadLine());
                Square square = new Square(firstSideLength);
                if (square.FigureSquare > 0 && square.FigurePerimeter > 0)
                {
                    Console.WriteLine("\nПлощадь квадрата: " + square.FigureSquare + " см\u00B2");
                    Console.WriteLine("Периметр квадрата: " + square.FigurePerimeter + " см");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            try
            {
                Console.Write("\nВведите высоту ромба (см): ");
                height = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину стороны ромба (cм): ");
                firstSideLength = Convert.ToDouble(Console.ReadLine());
                Rhombus rhombus = new Rhombus(height, firstSideLength);
                if (rhombus.FigureSquare > 0 && rhombus.FigurePerimeter > 0)
                {
                    Console.WriteLine("\nПлощадь ромба: " + rhombus.FigureSquare + " см\u00B2");
                    Console.WriteLine("Периметр ромба: " + rhombus.FigurePerimeter + " см");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            try
            {
                Console.Write("\nВведите длину первой стороны прямоугольника (см): ");
                firstSideLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину второй стороны прямоугольника (cм): ");
                secondSideLength = Convert.ToDouble(Console.ReadLine());
                Rectangle rectangle = new Rectangle(firstSideLength, secondSideLength);
                if (rectangle.FigureSquare > 0 && rectangle.FigurePerimeter > 0)
                {
                    Console.WriteLine("\nПлощадь прямоугольника: " + rectangle.FigureSquare + " см\u00B2");
                    Console.WriteLine("Периметр прямоугольника: " + rectangle.FigurePerimeter + " см");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            try
            {
                Console.Write("\nВведите высоту параллелограмма (см): ");
                height = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину первой стороны параллелограмма (cм): ");
                firstSideLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину второй стороны параллелограмма (cм): ");
                secondSideLength = Convert.ToDouble(Console.ReadLine());
                Parallelogram parallelogram = new Parallelogram(height, firstSideLength, secondSideLength);
                if (parallelogram.FigureSquare > 0 && parallelogram.FigurePerimeter > 0)
                {
                    Console.WriteLine("\nПлощадь параллелограмма: " + parallelogram.FigureSquare + " см\u00B2");
                    Console.WriteLine("Периметр параллелограмма: " + parallelogram.FigurePerimeter + " см");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            try
            {
                Console.Write("\nВведите высоту трапеции (см): ");
                height = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину первой боковой стороны трапеции (см): ");
                firstSideLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину верхнего основания трапеции (см): ");
                secondSideLength = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите длину нижнего основания трапеции (см): ");
                thirdSideLength = Convert.ToDouble(Console.ReadLine());
                Trapezium trapezium = new Trapezium(height, firstSideLength, secondSideLength, thirdSideLength);
                if (trapezium.FigureSquare > 0 && trapezium.FigurePerimeter > 0)
                {
                    Console.WriteLine("\nПлощадь трапеции: " + trapezium.FigureSquare + " см\u00B2");
                    Console.WriteLine("Периметр трапеции: " + trapezium.FigurePerimeter + " см");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            try
            {
                Console.Write("\nВведите радиус круга (см): ");
                radius = Convert.ToDouble(Console.ReadLine());
                Circle circle = new Circle(radius);
                if (circle.FigureSquare > 0 && circle.FigurePerimeter > 0)
                {
                    Console.WriteLine("\nПлощадь круга: " + circle.FigureSquare + " см\u00B2");
                    Console.WriteLine("Периметр круга: " + circle.FigurePerimeter + " см");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            try
            {
                Console.Write("\nВведите большую полуось эллипса (см): ");
                semiMayorAxis = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите малую полуось эллипса (см): ");
                semiMinorAxis = Convert.ToDouble(Console.ReadLine());
                Ellipse ellipse = new Ellipse(semiMayorAxis, semiMinorAxis);
                if (ellipse.FigureSquare > 0 && ellipse.FigurePerimeter > 0)
                {
                    Console.WriteLine("\nПлощадь эллипса: " + ellipse.FigureSquare + " см\u00B2");
                    Console.WriteLine("Периметр эллипса: " + ellipse.FigurePerimeter + " см");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            try
            {
                Console.Write("\nВведите количесто n-угольников, из которых состоит фигура: ");
                polygonsCount = Convert.ToInt32(Console.ReadLine());
                if (polygonsCount <= 0)
                    throw new WrongCountException();
                polygon = new Polygon[polygonsCount];
                CompoundFigure compoundFigure = new CompoundFigure();
                for (int i = 0; i < polygonsCount; i++)
                {
                    try
                    {
                        coordinates.Clear();
                        Console.Write("\nВведите количесто сторон " + (i + 1) + "-го n-угольника: ");
                        sidesCount = Convert.ToInt32(Console.ReadLine());
                        if (sidesCount <= 2)
                            throw new WrongCountException();
                        Console.Write("Введите координаты вершин n-угольника (x; y) начиная с основания, основание\nдолжно быть параллельно оси x, n-угольник должен быть простым:\n");
                        for (int j = 0; j < sidesCount; j++)
                        {
                            Console.Write("x[" + (j + 1) + "] = ");
                            x = Convert.ToDouble(Console.ReadLine());
                            if (j == 1)
                            {
                                y = coordinates[0].Y;
                                Console.WriteLine("y[" + (j + 1) + "] = " + y);
                            }
                            else
                            {
                                Console.Write("y[" + (j + 1) + "] = ");
                                y = Convert.ToDouble(Console.ReadLine());
                            }
                            coordinates.Add(new Point(x, y));
                        }
                        polygon[i] = new Polygon(coordinates, sidesCount);
                        if (polygon[i].Height > 0 && polygon[i].Base > 0 && polygon[i].AngleBetweenBasisAndAdjacentSide > 0 && polygon[i].SidesCount > 2 && polygon[i].Square > 0 && polygon[i].Perimeter > 0)
                        {
                            Console.WriteLine("\nВысота n-угольника: " + polygon[i].Height + " см");
                            Console.WriteLine("Основание n-угольника: " + polygon[i].Base + " см");
                            Console.WriteLine("Угол между основанием и смежной стороной: " + polygon[i].AngleBetweenBasisAndAdjacentSide + "\u00B0");
                            Console.Write("Длины сторон n-угольника: ");
                            for (int j = 0; j < polygon[i].SidesLengths.Count; j++)
                            {
                                Console.Write(Math.Round(polygon[i].SidesLengths[j], 2) + " см");
                                if (j < polygon[i].SidesLengths.Count - 1)
                                    Console.Write(", ");
                                else
                                    Console.WriteLine();
                            }
                            Console.WriteLine("Площадь n-угольника: " + polygon[i].Square + " см\u00B2");
                            Console.WriteLine("Периметр n-угольника: " + polygon[i].Perimeter + " см");
                            compoundFigure.Polygons.Add(polygon[i]);
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nЗначение введено неверно!");
                    }
                    catch (WrongCountException)
                    {
                        Console.WriteLine("\nКоличество сторон n-угольника введено неверно!");
                    }
                }
                Console.WriteLine("\nПлощадь составной фигуры: " + compoundFigure.GetFigureArea() + " см\u00B2");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            catch (WrongCountException)
            {
                Console.WriteLine("\nКоличество n-угольников введено неверно!");
            }
            Console.ReadKey();
        }
    }
}