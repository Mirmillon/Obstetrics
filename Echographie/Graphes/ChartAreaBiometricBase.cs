namespace Echographie.Graphes
{
    public class ChartAreaBiometricBase : ChartAreaCroissanceBase
    {
        public ChartAreaBiometricBase()
        {
            AxisY.Minimum = 60;
            AxisY.Maximum = 400;
            AxisY.Interval = 20;
        }
    }
}
