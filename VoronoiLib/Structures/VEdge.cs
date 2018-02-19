namespace VoronoiLib.Structures
{
    public class VEdge
    {
        public VPoint Start { get; internal set; }
        public VPoint End { get; internal set; }
        public bool IsClipped { get; internal set; }
        public FortuneSite Left { get; private set; }
        public FortuneSite Right { get; private set; }
        internal double SlopeRise { get; private set; }
        internal double SlopeRun { get; private set; }
        internal double? Slope { get; private set; }
        internal double? Intercept { get; private set; }

        public VEdge Neighbor { get; internal set; }

        public void Initialize(VPoint start, FortuneSite left, FortuneSite right)
        {
            Start = start;
            End = VPoint.Default;
            Left = left;
            Right = right;
            IsClipped = false;
            Neighbor = null;
            
            //for bounding box edges
            if (left == null || right == null)
                return;

            //from negative reciprocal of slope of line from left to right
            //ala m = (left.y -right.y / left.x - right.x)
            SlopeRise = left.X - right.X;
            SlopeRun = -(left.Y - right.Y);
            Intercept = null;

            if (SlopeRise.ApproxEqual(0) || SlopeRun.ApproxEqual(0)) return;
            Slope = SlopeRise/SlopeRun;
            Intercept = start.Y - Slope*start.X;
        }
    }
}
