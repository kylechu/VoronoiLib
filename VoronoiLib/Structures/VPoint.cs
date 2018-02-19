using System;

namespace VoronoiLib.Structures
{
    public struct VPoint : IEquatable<VPoint>
    {
        public static VPoint Default = new VPoint(double.NaN, double.NaN);

        public double X { get; }
        public double Y { get; }

        internal VPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(VPoint other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
    }
}
