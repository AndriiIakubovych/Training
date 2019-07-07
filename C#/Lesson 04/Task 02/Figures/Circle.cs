using System;

namespace Figures
{
    class Circle : GeometricalFigure
    {
        private double radius;

        public Circle(double radius)
        {
            try
            {
                if (radius <= 0)
                    throw new NegativeRadiusException();
                this.radius = radius;
                figureSquare = Math.Pow(Math.PI * radius, 2);
                figurePerimeter = 2 * Math.PI * radius;
            }
            catch (NegativeRadiusException)
            {
                Console.WriteLine("\nВведено отрицательное или нулевое значение радиуса!");
            }
        }

        public double Radius
        {
            get { return radius; }
        }
    }
}