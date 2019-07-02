using System;

namespace Figures
{
    class Square : GeometricalFigure
    {
        private double sideLength;

        public Square(double sideLength)
        {
            try
            {
                if (sideLength < 0)
                    throw new NegativeSidesException();
                this.sideLength = sideLength;
                figureSquare = Math.Pow(sideLength, 2);
                figurePerimeter = sideLength * 4;
            }
            catch (NegativeSidesException)
            {
                Console.WriteLine("\nВведены отрицательные или нулевые длины сторон!");
            }
        }

        public double SideLenght
        {
            get { return sideLength; }
        }
    }
}