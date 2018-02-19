namespace VoronoiLib.Structures
{
    internal class FortuneCircleEvent : FortuneEvent
    {
        internal VPoint Lowest { get; private set; }
        internal double YCenter { get; private set; }
        internal RBTreeNode<BeachSection> ToDelete { get; private set; }

        public void Initialize(VPoint lowest, double yCenter, RBTreeNode<BeachSection> toDelete)
        {
            Lowest = lowest;
            YCenter = yCenter;
            ToDelete = toDelete;
        }

        public int CompareTo(FortuneEvent other)
        {
            var c = Y.CompareTo(other.Y);
            return c == 0 ? X.CompareTo(other.X) : c;
        }

        public double X => Lowest.X;
        public double Y => Lowest.Y;
    }
}
