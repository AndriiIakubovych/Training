using System;

namespace Figures
{
    class Ellipse : GeometricalFigure
    {
        private double semiMayorAxis;
        private double semiMinorAxis;

        public Ellipse(double semiMayorAxis, double semiMinorAxis)
        {
            try
            {
                if (semiMayorAxis <= 0 && semiMinorAxis <= 0)
                    throw new NegativeSemiaxisesException();
                if (semiMayorAxis <= semiMinorAxis)
                    throw new WrongSemiaxisesException();
                this.semiMayorAxis = semiMayorAxis;
                this.semiMinorAxis = semiMinorAxis;
                figureSquare = Math.PI * semiMayorAxis * semiMinorAxis;
                figurePerimeter = 4 * (Math.PI * semiMayorAxis * semiMinorAxis + Math.Pow(semiMayorAxis - semiMinorAxis, 2)) / (semiMayorAxis + semiMinorAxis);
            }
            catch (NegativeSemiaxisesException)
            {
                Console.WriteLine("\nВведены отрицательные или нулевые значения полуосей эллипса!");
            }
            catch (WrongSemiaxisesException)
            {
                Console.WriteLine("\nБольшая полуось эллипса меньше или равна малой!");
            }
        }

        public double SemiMayorAxis
        {
            get { return semiMayorAxis; }
        }

        public double SemiMinorAxis
        {
            get { return semiMinorAxis; }
        }
    }
}