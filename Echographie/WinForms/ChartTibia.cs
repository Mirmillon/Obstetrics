using System.Windows.Forms.DataVisualization.Charting;
using Echographie.Graphes;

namespace Echographie.WinForms
{
    public class ChartTibia : Chart
    {
        ChartAreaTibia aireTibia = null;

        public ChartTibia() : base()
        {
            aireTibia = new ChartAreaTibia();
        }

        public void ChartTibiaLoaded()
        {
            ChartAreas.Add(aireTibia);

            Series.Add(aireTibia.P1);
            Series.Add(aireTibia.P3);
            Series.Add(aireTibia.P5);
            Series.Add(aireTibia.P10);
            Series.Add(aireTibia.P25);
            Series.Add(aireTibia.P50);
            Series.Add(aireTibia.P75);
            Series.Add(aireTibia.P90);
            Series.Add(aireTibia.P95);
            Series.Add(aireTibia.P97);
            Series.Add(aireTibia.P99);

            aireTibia.P1.ChartArea = "aireTibia";
            aireTibia.P3.ChartArea = "aireTibia";
            aireTibia.P5.ChartArea = "aireTibia";
            aireTibia.P10.ChartArea = "aireTibia";
            aireTibia.P25.ChartArea = "aireTibia";
            aireTibia.P50.ChartArea = "aireTibia";
            aireTibia.P75.ChartArea = "aireTibia";
            aireTibia.P90.ChartArea = "aireTibia";
            aireTibia.P95.ChartArea = "aireTibia";
            aireTibia.P97.ChartArea = "aireTibia";
            aireTibia.P99.ChartArea = "aireTibia";

        }
    }
}
