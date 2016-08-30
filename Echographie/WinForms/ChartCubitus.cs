using System.Windows.Forms.DataVisualization.Charting;
using Echographie.Graphes;

namespace Echographie.WinForms
{
    public  class ChartCubitus : Chart
    {
        ChartAreaCubitus aireCubitus = null;

        public ChartCubitus() : base()
        {
            aireCubitus = new ChartAreaCubitus();
        }

        public void ChartCubitusLoaded()
        {
            ChartAreas.Add(aireCubitus);

            Series.Add(aireCubitus.P1);
            Series.Add(aireCubitus.P3);
            Series.Add(aireCubitus.P5);
            Series.Add(aireCubitus.P10);
            Series.Add(aireCubitus.P25);
            Series.Add(aireCubitus.P50);
            Series.Add(aireCubitus.P75);
            Series.Add(aireCubitus.P90);
            Series.Add(aireCubitus.P95);
            Series.Add(aireCubitus.P97);
            Series.Add(aireCubitus.P99);

            aireCubitus.P1.ChartArea = "aireCubitus";
            aireCubitus.P3.ChartArea = "aireCubitus";
            aireCubitus.P5.ChartArea = "aireCubitus";
            aireCubitus.P10.ChartArea = "aireCubitus";
            aireCubitus.P25.ChartArea = "aireCubitus";
            aireCubitus.P50.ChartArea = "aireCubitus";
            aireCubitus.P75.ChartArea = "aireCubitus";
            aireCubitus.P90.ChartArea = "aireCubitus";
            aireCubitus.P95.ChartArea = "aireCubitus";
            aireCubitus.P97.ChartArea = "aireCubitus";
            aireCubitus.P99.ChartArea = "aireCubitus";

        }
    }
}
