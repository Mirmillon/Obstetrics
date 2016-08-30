namespace Echographie.Graphes
{
    public class ChartAreaCroissance : ChartAreaCroissanceBase
    {
        public ChartAreaCroissance()
        {
            Name = "aireCroissance";

            AxisY.Minimum = 200;
            AxisY.Maximum = 5000;
            AxisY.Interval = 250;

            AxisX.Minimum = 20;
        }
    }
}
