using System;

namespace Figures
{
    class Triangle : GeometricalFigure
    {
        private double firstSideLength;
        private double secondSideLength;
        private double thirdSideLength;

        public Triangle(double firstSideLength, double secondSideLength, double thirdSideLength)
        {
            try
            {
                if (firstSideLength <= 0 || secondSideLength <= 0 || thirdSideLength <= 0)
                    throw new NegativeSidesException();
                if (firstSideLength + secondSideLength <= thirdSideLength || secondSideLength + thirdSideLength <= firstSideLength || firstSideLength + thirdSideLength <= secondSideLength)
                    throw new WrongSidesException();
                this.firstSideLength = firstSideLength;
                this.secondSideLength = secondSideLength;
                this.thirdSideLength = thirdSideLength;
                figurePerimeter = firstSideLength + secondSideLength + thirdSideLength;
                figureSquare = Math.Sqrt(figurePerimeter / 2 * (figurePerimeter / 2 - firstSideLength) * (figurePerimeter / 2 - secondSideLength) * (figurePerimeter / 2 - thirdSideLength));
            }
            catch (FormatException)
            {
                Console.WriteLine("\nЗначение введено неверно!");
            }
            catch (NegativeSidesException)
            {
                Console.WriteLine("\nВведены отрицательные или нулевые длины сторон!");
            }
            catch (WrongSidesException)
            {
                Console.WriteLine("\nСуществует пара сторон, сумма длин которых не больше длины третьей стороны!");
            }
        }

        public double FirstSideLength
        {
            get { return firstSideLength; }
        }

        public double SecondSideLength
        {
            get { return secondSideLength; }
        }

        public double ThirdSideLength
        {
            get { return thirdSideLength; }
        }
    }
}