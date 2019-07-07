using System.Collections.Generic;

namespace Figures
{
    interface ISimplePolygon
    {
        double Height { get; }
        double Base { get; }
        double AngleBetweenBasisAndAdjacentSide { get; }
        int SidesCount { get; }
        List<double> SidesLengths { get; }
        double Square { get; }
        double Perimeter { get; }
    }
}