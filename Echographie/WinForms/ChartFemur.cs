using System.Windows.Forms.DataVisualization.Charting;
using Echographie.Graphes;

namespace Echographie.WinForms
{
    public class ChartFemur :  Chart
    {
        ChartAreaFemur aireFemur = null;

        public ChartFemur() : base()
        {
            aireFemur = new ChartAreaFemur();
        }

        public void ChartFemurLoaded()
        {
            ChartAreas.Add(aireFemur);

            Series.Add(aireFemur.P1);
            Series.Add(aireFemur.P3);
            Series.Add(aireFemur.P5);
            Series.Add(aireFemur.P10);
            Series.Add(aireFemur.P25);
            Series.Add(aireFemur.P50);
            Series.Add(aireFemur.P75);
            Series.Add(aireFemur.P90);
            Series.Add(aireFemur.P95);
            Series.Add(aireFemur.P97);
            Series.Add(aireFemur.P99);

            aireFemur.P1.ChartArea = "aireFemur";
            aireFemur.P3.ChartArea = "aireFemur";
            aireFemur.P5.ChartArea = "aireFemur";
            aireFemur.P10.ChartArea = "aireFemur";
            aireFemur.P25.ChartArea = "aireFemur";
            aireFemur.P50.ChartArea = "aireFemur";
            aireFemur.P75.ChartArea = "aireFemur";
            aireFemur.P90.ChartArea = "aireFemur";
            aireFemur.P95.ChartArea = "aireFemur";
            aireFemur.P97.ChartArea = "aireFemur";
            aireFemur.P99.ChartArea = "aireFemur";
        }
    }
}
