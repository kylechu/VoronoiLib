using System.Collections.Generic;

namespace VoronoiLib.Structures
{
    public class FortuneSite
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public int Id { get; private set; }

        public List<VEdge> Cell { get; } = new List<VEdge>();

        public List<FortuneSite> Neighbors { get; } = new List<FortuneSite>();

        public void Initialize(double x, double y, int id = -1)
        {
            Id = id;
            X = x;
            Y = y;
            Cell.Clear();
            Neighbors.Clear();
        }
    }
}
