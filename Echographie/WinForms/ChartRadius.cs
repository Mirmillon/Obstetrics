using System.Windows.Forms.DataVisualization.Charting;
using Echographie.Graphes;

namespace Echographie.WinForms
{
    public class ChartRadius : Chart
    {
        ChartAreaRadius aireRadius = null;

        public ChartRadius() : base()
        {
            aireRadius = new ChartAreaRadius();

        }

        public void ChartRadiusLoaded()
        {
            ChartAreas.Add(aireRadius);

            Series.Add(aireRadius.P1);
            Series.Add(aireRadius.P3);
            Series.Add(aireRadius.P5);
            Series.Add(aireRadius.P10);
            Series.Add(aireRadius.P25);
            Series.Add(aireRadius.P50);
            Series.Add(aireRadius.P75);
            Series.Add(aireRadius.P90);
            Series.Add(aireRadius.P95);
            Series.Add(aireRadius.P97);
            Series.Add(aireRadius.P99);

            aireRadius.P1.ChartArea = "aireRadius";
            aireRadius.P3.ChartArea = "aireRadius";
            aireRadius.P5.ChartArea = "aireRadius";
            aireRadius.P10.ChartArea = "aireRadius";
            aireRadius.P25.ChartArea = "aireRadius";
            aireRadius.P50.ChartArea = "aireRadius";
            aireRadius.P75.ChartArea = "aireRadius";
            aireRadius.P90.ChartArea = "aireRadius";
            aireRadius.P95.ChartArea = "aireRadius";
            aireRadius.P97.ChartArea = "aireRadius";
            aireRadius.P99.ChartArea = "aireRadius";
        }
    }
}
