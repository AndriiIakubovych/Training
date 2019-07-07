using System;

namespace Figures
{
    class Rhombus : GeometricalFigure
    {
        private double height;
        private double sideLength;

        public Rhombus(double height, double sideLength)
        {
            try
            {
                if (height <= 0)
                    throw new NegativeHeightException();
                if (sideLength <= 0)
                    throw new NegativeSidesException();
                if (height >= sideLength)
                    throw new SideLessThanHeightException();
                this.height = height;
                this.sideLength = sideLength;
                figureSquare = sideLength * height;
                figurePerimeter = sideLength * 4;
            }
            catch (NegativeHeightException)
            {
                Console.WriteLine("\nВведено отрицательное или нулевое значение высоты!");
            }
            catch (NegativeSidesException)
            {
                Console.WriteLine("\nВведены отрицательные или нулевые длины сторон!");
            }
            catch (SideLessThanHeightException)
            {
                Console.WriteLine("\nДлина боковой стороны меньше или равна высоте!");
            }
        }

        public double Height
        {
            get { return height; }
        }

        public double SideLength
        {
            get { return sideLength; }
        }
    }
}