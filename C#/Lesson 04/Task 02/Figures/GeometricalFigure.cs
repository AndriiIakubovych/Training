namespace Figures
{
    abstract class GeometricalFigure
    {
        protected double figureSquare;
        protected double figurePerimeter;

        public double FigureSquare
        {
            get { return figureSquare; }
        }

        public double FigurePerimeter
        {
            get { return figurePerimeter; }
        }
    }
}