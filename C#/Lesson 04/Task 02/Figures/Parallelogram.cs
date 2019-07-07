using System;

namespace Figures
{
    class Parallelogram : GeometricalFigure
    {
        private double height;
        private double firstSideLength;
        private double secondSideLength;

        public Parallelogram(double height, double firstSideLength, double secondSideLength)
        {
            try
            {
                if (height <= 0)
                    throw new NegativeHeightException();
                if (firstSideLength <= 0 || secondSideLength <= 0)
                    throw new NegativeSidesException();
                if (height >= secondSideLength)
                    throw new SideLessThanHeightException();
                this.height = height;
                this.firstSideLength = firstSideLength;
                this.secondSideLength = secondSideLength;
                figureSquare = firstSideLength * height;
                figurePerimeter = (firstSideLength + secondSideLength) * 2;
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

        public double FirstSideLength
        {
            get { return firstSideLength; }
        }

        public double SecondSideLength
        {
            get { return secondSideLength; }
        }
    }
}