using System.Windows.Forms.DataVisualization.Charting;
using Echographie.Graphes;

namespace Echographie.WinForms
{
    public class ChartPeronee : Chart
    {
        ChartAreaPeronee airePerone = null;



        public ChartPeronee():base()
        {
            airePerone = new ChartAreaPeronee();


        }

        public void ChartPeroneLoaded()
        {
            ChartAreas.Add(airePerone);

            Series.Add(airePerone.P1);
            Series.Add(airePerone.P3);
            Series.Add(airePerone.P5);
            Series.Add(airePerone.P10);
            Series.Add(airePerone.P25);
            Series.Add(airePerone.P50);
            Series.Add(airePerone.P75);
            Series.Add(airePerone.P90);
            Series.Add(airePerone.P95);
            Series.Add(airePerone.P97);
            Series.Add(airePerone.P99);

            airePerone.P1.ChartArea = "airePerone";
            airePerone.P3.ChartArea = "airePerone";
            airePerone.P5.ChartArea = "airePerone";
            airePerone.P10.ChartArea = "airePerone";
            airePerone.P25.ChartArea = "airePerone";
            airePerone.P50.ChartArea = "airePerone";
            airePerone.P75.ChartArea = "airePerone";
            airePerone.P90.ChartArea = "airePerone";
            airePerone.P95.ChartArea = "airePerone";
            airePerone.P97.ChartArea = "airePerone";
            airePerone.P99.ChartArea = "airePerone";

        }
    }
}
