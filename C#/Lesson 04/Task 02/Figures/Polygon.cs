using System;
using System.Collections.Generic;

namespace Figures
{
    class Polygon : ISimplePolygon
    {
        private List<Point> coordinates;
        private double height;
        private double figureBase;
        private double angleBetweenBasisAndAdjacentSide;
        private int sidesCount;
        private List<double> sidesLengths;
        private double square;
        private double perimeter;

        public Polygon(List<Point> coordinates, int sidesCount)
        {
            try
            {
                double topY = coordinates[0].Y, diagonal;
                int k;
                for (int i = 2; i < coordinates.Count; i++)
                    if (coordinates[i].Y < coordinates[0].Y)
                        throw new WrongCoordinatesException();
                if (FindCrossing(coordinates))
                    throw new NotSimplePolygonException();
                this.coordinates = coordinates;
                this.sidesCount = sidesCount;
                for (int i = 0; i < coordinates.Count; i++)
                    if (coordinates[i].Y > topY)
                        topY = coordinates[i].Y;
                height = topY - coordinates[0].Y;
                figureBase = Math.Abs(coordinates[1].X - coordinates[0].X);
                sidesLengths = new List<double>();
                sidesLengths.Add(figureBase);
                for (int i = 1; i < coordinates.Count; i++)
                {
                    k = i < coordinates.Count - 1 ? i + 1 : 0;
                    sidesLengths.Add(Math.Sqrt(Math.Pow(coordinates[k].X - coordinates[i].X, 2) + Math.Pow(coordinates[k].Y - coordinates[i].Y, 2)));
                }
                diagonal = Math.Sqrt(Math.Pow(coordinates[2].X - coordinates[0].X, 2) + Math.Pow(coordinates[2].Y - coordinates[0].Y, 2));
                angleBetweenBasisAndAdjacentSide = Math.Round((Math.Acos((Math.Pow(figureBase, 2) + Math.Pow(sidesLengths[1], 2) - Math.Pow(diagonal, 2)) / (2 * figureBase * sidesLengths[1]))) * 180 / Math.PI);
                square = 0;
                for (int i = 0; i < coordinates.Count; i++)
                {
                    k = i < coordinates.Count - 1 ? i + 1 : 0;
                    square += (coordinates[i].X + coordinates[k].X) * (coordinates[i].Y - coordinates[k].Y);
                }
                square = Math.Abs(square) / 2;
                perimeter = 0;
                for (int i = 0; i < sidesLengths.Count; i++)
                    perimeter += sidesLengths[i];
            }
            catch (WrongCoordinatesException)
            {
                Console.WriteLine("\nОснование должно располагаться ниже остальных сторон!");
            }
            catch (NotSimplePolygonException)
            {
                Console.WriteLine("\nПолученный n-угольник не является простым!");
            }
        }

        private bool FindCrossing(List<Point> c)
        {
            bool hasCrossing = false;
            Point crossingPoint = new Point();
            int k;
            for (int i = 0; i < c.Count - 1; i++)
                for (int j = i + 2; j < c.Count; j++)
                    if (i == 0 && j == c.Count - 1)
                        continue;
                    else
                    {
                        k = j < c.Count - 1 ? j + 1 : 0;
                        if ((((c[k].X - c[j].X) * (c[i].Y - c[j].Y) - (c[k].Y - c[j].Y) * (c[i].X - c[j].X)) * ((c[k].X - c[j].X) * (c[i + 1].Y - c[j].Y) - (c[k].Y - c[j].Y) * (c[i + 1].X - c[j].X)) < 0) && (((c[i + 1].X - c[i].X) * (c[j].Y - c[i].Y) - (c[i + 1].Y - c[i].Y) * (c[j].X - c[i].X)) * ((c[i + 1].X - c[i].X) * (c[k].Y - c[i].Y) - (c[i + 1].Y - c[i].Y) * (c[k].X - c[i].X)) < 0))
                        {
                            hasCrossing = true;
                            break;
                        }
                    }
            return hasCrossing;
        }

        public List<Point> Coordinates
        {
            get { return coordinates; }
        }

        public double Height
        {
            get { return height; }
        }

        public double Base
        {
            get { return figureBase; }
        }

        public double AngleBetweenBasisAndAdjacentSide
        {
            get { return angleBetweenBasisAndAdjacentSide; }
        }

        public int SidesCount
        {
            get { return sidesCount; }
        }

        public List<double> SidesLengths
        {
            get { return sidesLengths; }
        }

        public double Square
        {
            get { return square; }
        }

        public double Perimeter
        {
            get { return perimeter; }
        }
    }
}