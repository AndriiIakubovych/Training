using System;

namespace Figures
{
    class Rectangle : GeometricalFigure
    {
        private double firstSideLength;
        private double secondSideLength;

        public Rectangle(double firstSideLength, double secondSideLength)
        {
            try
            {
                if (firstSideLength <= 0 || secondSideLength <= 0)
                    throw new NegativeSidesException();
                this.firstSideLength = firstSideLength;
                this.secondSideLength = secondSideLength;
                figureSquare = firstSideLength * secondSideLength;
                figurePerimeter = (firstSideLength + secondSideLength) * 2;
            }
            catch (NegativeSidesException)
            {
                Console.WriteLine("\nВведены отрицательные или нулевые длины сторон!");
            }
        }

        public double FirstSideLenght
        {
            get { return firstSideLength; }
        }

        public double SecondSideLenght
        {
            get { return secondSideLength; }
        }
    }
}