namespace Echographie.Graphes
{
    class ChartAreaCroissance : ChartAreaCroissanceBase
    {
        public ChartAreaCroissance()
        {
            Name = "aireCroissance";

            AxisY.Minimum = 200;
            AxisY.Maximum = 5250;
            AxisY.Interval = 250;
        }
    }
}
