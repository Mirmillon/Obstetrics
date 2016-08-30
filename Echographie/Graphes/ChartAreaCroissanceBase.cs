namespace Echographie.Graphes
{
    public class ChartAreaCroissanceBase : ChartAeraBase
    {
        private SerieCroissance p1 = null;
        private SerieCroissance p3 = null;
        private SerieCroissance p5 = null;
        private SerieCroissance p10 = null;
        private SerieCroissance p25 = null;
        private SerieCroissance p50 = null;
        private SerieCroissance p75 = null;
        private SerieCroissance p90 = null;
        private SerieCroissance p95 = null;
        private SerieCroissance p97 = null;
        private SerieCroissance p99 = null;

        public SerieCroissance P1 { get { return p1; } set { p1 = value; } }
        public SerieCroissance P3 { get { return p3; } set { p3 = value; } }
        public SerieCroissance P5 { get { return p5; } set { p5 = value; } }
        public SerieCroissance P10 { get { return p10; } set { p10 = value; } }
        public SerieCroissance P25 { get { return p25; } set { p25 = value; } }
        public SerieCroissance P50 { get { return p50; } set { p50 = value; } }
        public SerieCroissance P75 { get { return p75; } set { p75 = value; } }
        public SerieCroissance P90 { get { return p90; } set { p90 = value; } }
        public SerieCroissance P95 { get { return p95; } set { p95 = value; } }
        public SerieCroissance P97 { get { return p97; } set { p97 = value; } }
        public SerieCroissance P99 { get { return p99; } set { p99 = value; } }

        public ChartAreaCroissanceBase()
        {
            p1 = new SerieCroissance();
            p3 = new SerieCroissance();
            p5 = new SerieCroissance();
            p10 = new SerieCroissance();
            p25 = new SerieCroissance();
            p50 = new SerieCroissance();
            p75 = new SerieCroissance();
            p90 = new SerieCroissance();
            p95 = new SerieCroissance();
            p97 = new SerieCroissance();
            p99 = new SerieCroissance();

            AxisX.Minimum = 13;
            AxisX.Maximum = 41;
            AxisX.Interval = 1;
        }
    }
}
