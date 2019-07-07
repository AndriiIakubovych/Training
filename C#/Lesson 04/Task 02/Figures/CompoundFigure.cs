using System.Collections.Generic;

namespace Figures
{
    class CompoundFigure
    {
        private List<ISimplePolygon> polygons;

        public CompoundFigure()
        {
            polygons = new List<ISimplePolygon>();
        }

        public double GetFigureArea()
        {
            double area = 0;
            foreach (Polygon p in Polygons)
                area += p.Square;
            return area;
        }

        public List<ISimplePolygon> Polygons
        {
            get { return polygons; }
            set { polygons = value; }
        }
    }
}