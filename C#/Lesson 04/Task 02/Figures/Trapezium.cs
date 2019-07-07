using System;

namespace Figures
{
    class Trapezium : GeometricalFigure
    {
        private double height;
        private double firstSideLength;
        private double secondSideLength;
        private double topBaseLength;
        private double bottomBaseLength;

        public Trapezium(double height, double firstSideLength, double topBasisLength, double bottomBasisLength)
        {
            try
            {
                if (height <= 0)
                    throw new NegativeHeightException();
                if (firstSideLength <= 0 || topBasisLength <= 0 || bottomBasisLength <= 0)
                    throw new NegativeSidesException();
                if (height >= firstSideLength)
                    throw new SideLessThanHeightException();
                if (topBasisLength == bottomBasisLength)
                    throw new EqualBasesException();
                this.height = height;
                this.firstSideLength = firstSideLength;
                this.topBaseLength = topBasisLength;
                this.bottomBaseLength = bottomBasisLength;
                if (topBasisLength < bottomBasisLength)
                    secondSideLength = Math.Sqrt(Math.Pow(height, 2) + Math.Pow((bottomBasisLength - Math.Sqrt(Math.Pow(firstSideLength, 2) - Math.Pow(height, 2)) - topBasisLength), 2));
                else
                    secondSideLength = Math.Sqrt(Math.Pow(height, 2) + Math.Pow((topBasisLength - Math.Sqrt(Math.Pow(firstSideLength, 2) - Math.Pow(height, 2)) - bottomBasisLength), 2));
                figureSquare = (topBasisLength + bottomBasisLength) / 2 * height;
                figurePerimeter = topBasisLength + bottomBasisLength + firstSideLength + secondSideLength;
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
            catch (EqualBasesException)
            {
                Console.WriteLine("\nДлины оснований трапеции равны!");
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

        public double TopBaseLength
        {
            get { return topBaseLength; }
        }

        public double BottomBaseLength
        {
            get { return bottomBaseLength; }
        }
    }
}