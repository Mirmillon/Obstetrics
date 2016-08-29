using System;
using Echographie.Graphes;
using System.Windows.Forms.DataVisualization.Charting;

namespace Echographie.WinForms
{
    public class ChartHumerus : Chart
    {
        ChartAreaHumerus aireHumerus = null;

        public ChartHumerus() : base()
        {
            Title t = new Title("Humerus Growth");

            aireHumerus = new ChartAreaHumerus();


        }

        public void ChartHumerusLoaded()
        {
            Series.Add(aireHumerus.P1);
            Series.Add(aireHumerus.P3);
            Series.Add(aireHumerus.P5);
            Series.Add(aireHumerus.P10);
            Series.Add(aireHumerus.P25);
            Series.Add(aireHumerus.P50);
            Series.Add(aireHumerus.P75);
            Series.Add(aireHumerus.P90);
            Series.Add(aireHumerus.P95);
            Series.Add(aireHumerus.P97);
            Series.Add(aireHumerus.P99);

            ChartAreas.Add(aireHumerus);

            aireHumerus.P1.ChartArea = "aireHumerus";
            aireHumerus.P3.ChartArea = "aireHumerus";
            aireHumerus.P5.ChartArea = "aireHumerus";
            aireHumerus.P10.ChartArea = "aireHumerus";
            aireHumerus.P25.ChartArea = "aireHumerus";
            aireHumerus.P50.ChartArea = "aireHumerus";
            aireHumerus.P75.ChartArea = "aireHumerus";
            aireHumerus.P90.ChartArea = "aireHumerus";
            aireHumerus.P95.ChartArea = "aireHumerus";
            aireHumerus.P97.ChartArea = "aireHumerus";
            aireHumerus.P99.ChartArea = "aireHumerus";

            Series[3].Points.AddXY(Convert.ToDouble(13), Convert.ToDouble(6.5));
            Series[3].Points.AddXY(Convert.ToDouble(14), Convert.ToDouble(9.9));
            Series[3].Points.AddXY(Convert.ToDouble(15), Convert.ToDouble(11.6));
            Series[3].Points.AddXY(Convert.ToDouble(16), Convert.ToDouble(13.7));
            Series[3].Points.AddXY(Convert.ToDouble(17), Convert.ToDouble(18.2));
            Series[3].Points.AddXY(Convert.ToDouble(18), Convert.ToDouble(21.3));
            Series[3].Points.AddXY(Convert.ToDouble(19), Convert.ToDouble(23));


            Series[3].Points.AddXY(Convert.ToDouble(29), Convert.ToDouble(48));


        }
    }
}
