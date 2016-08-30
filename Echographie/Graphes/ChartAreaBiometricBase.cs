namespace Echographie.Graphes
{
    public class ChartAreaBiometricBase : ChartAreaCroissanceBase
    {
        public ChartAreaBiometricBase()
        {
            AxisY.Minimum = 20;
            AxisY.Maximum = 400;
            AxisY.Interval = 20;
        }
    }
}
