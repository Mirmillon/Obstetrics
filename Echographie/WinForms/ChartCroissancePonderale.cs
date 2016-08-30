using System.Windows.Forms.DataVisualization.Charting;
using Echographie.Graphes;
using System;
using Echographie.Utilitaires;

namespace Echographie.WinForms
{
    public class ChartCroissancePonderale : Chart
    {
        private ChartAreaCroissance aireCroissance = null;

        public ChartCroissancePonderale() : base()
        {
            aireCroissance = new ChartAreaCroissance();
        }

        public void CroissancePonderaleLoaded()
        {
            Series.Add(aireCroissance.P1);
            Series.Add(aireCroissance.P3);
            Series.Add(aireCroissance.P5);
            Series.Add(aireCroissance.P10);
            Series.Add(aireCroissance.P25);
            Series.Add(aireCroissance.P50);
            Series.Add(aireCroissance.P75);
            Series.Add(aireCroissance.P90);
            Series.Add(aireCroissance.P95);
            Series.Add(aireCroissance.P97);
            Series.Add(aireCroissance.P99);


            ChartAreas.Add(aireCroissance);

            aireCroissance.P1.ChartArea = "aireCroissance";
            aireCroissance.P3.ChartArea = "aireCroissance";
            aireCroissance.P5.ChartArea = "aireCroissance";
            aireCroissance.P10.ChartArea = "aireCroissance";
            aireCroissance.P25.ChartArea = "aireCroissance";
            aireCroissance.P50.ChartArea = "aireCroissance";
            aireCroissance.P75.ChartArea = "aireCroissance";
            aireCroissance.P90.ChartArea = "aireCroissance";
            aireCroissance.P95.ChartArea = "aireCroissance";
            aireCroissance.P97.ChartArea = "aireCroissance";
            aireCroissance.P99.ChartArea = "aireCroissance";


            for (int t = 21; t < 43; t++)
            {
                //Poids standard
                Series[0].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP1(t, new EstimationPoids().PoidsStandard(40)));
                Series[1].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP3(t, new EstimationPoids().PoidsStandard(40)));
                Series[2].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP5(t, new EstimationPoids().PoidsStandard(40)));
                Series[3].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP10(t, new EstimationPoids().PoidsStandard(40)));
                Series[4].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP25(t, new EstimationPoids().PoidsStandard(40)));
                Series[5].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().Mediane(t, new EstimationPoids().PoidsStandard(40)));
                Series[6].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP75(t, new EstimationPoids().PoidsStandard(40)));
                Series[7].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP90(t, new EstimationPoids().PoidsStandard(40)));
                Series[8].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP95(t, new EstimationPoids().PoidsStandard(40)));
                Series[9].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP97(t, new EstimationPoids().PoidsStandard(40)));
                Series[10].Points.AddXY(Convert.ToDouble(t), new EstimationPoids().PoidsP99(t, new EstimationPoids().PoidsStandard(40)));
            }
        }
    }
}
