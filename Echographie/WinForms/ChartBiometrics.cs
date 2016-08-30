using Echographie.Graphes;
using Echographie.Classes;
using Echographie.Utilitaires;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Echographie.WinForms
{
    public class ChartBiometrics : Chart
    {
        ChartAreaBiometricHeadCircum areaHead = null;

        public ChartBiometrics():base()
        {
            areaHead = new ChartAreaBiometricHeadCircum();
        }

        public ChartAreaBiometricHeadCircum AireHead  {get {return areaHead; }}

        public void ChartBiometricsLoader()
        {
            ChartAreas.Add(areaHead);

            Series.Add(areaHead.P1);
            Series.Add(areaHead.P3);
            Series.Add(areaHead.P5);
            Series.Add(areaHead.P10);
            Series.Add(areaHead.P25);
            Series.Add(areaHead.P50);
            Series.Add(areaHead.P75);
            Series.Add(areaHead.P90);
            Series.Add(areaHead.P95);
            Series.Add(areaHead.P97);
            Series.Add(areaHead.P99);

            areaHead.P1.ChartArea = "aireHead";
            areaHead.P3.ChartArea = "aireHead";
            areaHead.P5.ChartArea = "aireHead";
            areaHead.P10.ChartArea = "aireHead";
            areaHead.P25.ChartArea = "aireHead";
            areaHead.P50.ChartArea = "aireHead";
            areaHead.P75.ChartArea = "aireHead";
            areaHead.P90.ChartArea = "aireHead";
            areaHead.P95.ChartArea = "aireHead";
            areaHead.P97.ChartArea = "aireHead";
            areaHead.P99.ChartArea = "aireHead";

            areaHead.P3.Color = System.Drawing.Color.Red;
            areaHead.P97.Color = System.Drawing.Color.Red;

            List<DataBiometrique> listes = new List<DataBiometrique>();
            listes = new Fichier().ListeDataP3P10P50P90P97(@"H:\ProjetObstetric\Biometrics\PerimetreCranien.txt");
            List<DataBiometrique> listesP3 = new Fichier().ListeData(listes, "P3");
            List<DataBiometrique> listesP10 = new Fichier().ListeData(listes, "P10");
            List<DataBiometrique> listesP50 = new Fichier().ListeData(listes, "P50");
            List<DataBiometrique> listesP90 = new Fichier().ListeData(listes, "P90");
            List<DataBiometrique> listesP97 = new Fichier().ListeData(listes, "P97");
            foreach (DataBiometrique d in listesP3)
            {
                DataPoint p = new DataPoint(d.Terme, d.Resultat);
                Series[1].Points.Add(p);
            }
            foreach(DataBiometrique d in listesP10)
            {
                DataPoint p = new DataPoint(d.Terme, d.Resultat);
                areaHead.P10.Points.Add(p);
            }
            foreach (DataBiometrique d in listesP50)
            {
                DataPoint p = new DataPoint(d.Terme, d.Resultat);
                areaHead.P50.Points.Add(p);
            }
            foreach (DataBiometrique d in listesP90)
            {
                DataPoint p = new DataPoint(d.Terme, d.Resultat);
                areaHead.P90.Points.Add(p);
            }
            foreach (DataBiometrique d in listesP97)
            {
                DataPoint p = new DataPoint(d.Terme, d.Resultat);
                areaHead.P97.Points.Add(p);
            }



        }
    }
}
