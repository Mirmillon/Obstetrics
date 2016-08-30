using Echographie.Graphes;
using Echographie.Classes;
using Echographie.Utilitaires;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;

namespace Echographie.WinForms
{
    public class ChartBiometrics : Chart
    {
        ChartAreaBiometricHeadCircum areaHead = null;
        ChartAreaBiometricAbdoCircum areaAbdo = null;
        ChartAreaFemur areaFemur = null;

        public ChartBiometrics():base()
        {
            areaHead = new ChartAreaBiometricHeadCircum();
            areaAbdo = new ChartAreaBiometricAbdoCircum();
            areaFemur = new ChartAreaFemur();
        }

        public ChartAreaBiometricHeadCircum AreaHead  {get {return areaHead; }}
        public ChartAreaBiometricAbdoCircum AreaAbdo  {get {return areaAbdo; }}
        public ChartAreaFemur AreaFemur { get { return areaFemur; } }

        public void ChartBiometricsLoader()
        {
            ChartAreas.Add(areaHead);
            ChartAreas.Add(areaAbdo);
            ChartAreas.Add(areaFemur);

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

            Series.Add(areaAbdo.P1);
            Series.Add(areaAbdo.P3);
            Series.Add(areaAbdo.P5);
            Series.Add(areaAbdo.P10);
            Series.Add(areaAbdo.P25);
            Series.Add(areaAbdo.P50);
            Series.Add(areaAbdo.P75);
            Series.Add(areaAbdo.P90);
            Series.Add(areaAbdo.P95);
            Series.Add(areaAbdo.P97);
            Series.Add(areaAbdo.P99);

            Series.Add(areaFemur.P1);
            Series.Add(areaFemur.P3);
            Series.Add(areaFemur.P5);
            Series.Add(areaFemur.P10);
            Series.Add(areaFemur.P25);
            Series.Add(areaFemur.P50);
            Series.Add(areaFemur.P75);
            Series.Add(areaFemur.P90);
            Series.Add(areaFemur.P95);
            Series.Add(areaFemur.P97);
            Series.Add(areaFemur.P99);

            areaFemur.P1.ChartArea = "aireFemur";
            areaFemur.P3.ChartArea = "aireFemur";
            areaFemur.P5.ChartArea = "aireFemur";
            areaFemur.P10.ChartArea = "aireFemur";
            areaFemur.P25.ChartArea = "aireFemur";
            areaFemur.P50.ChartArea = "aireFemur";
            areaFemur.P75.ChartArea = "aireFemur";
            areaFemur.P90.ChartArea = "aireFemur";
            areaFemur.P95.ChartArea = "aireFemur";
            areaFemur.P97.ChartArea = "aireFemur";
            areaFemur.P99.ChartArea = "aireFemur";

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

            areaAbdo.P1.ChartArea = "aireAbdo";
            areaAbdo.P3.ChartArea = "aireAbdo";
            areaAbdo.P5.ChartArea = "aireAbdo";
            areaAbdo.P10.ChartArea = "aireAbdo";
            areaAbdo.P25.ChartArea = "aireAbdo";
            areaAbdo.P50.ChartArea = "aireAbdo";
            areaAbdo.P75.ChartArea = "aireAbdo";
            areaAbdo.P90.ChartArea = "aireAbdo";
            areaAbdo.P95.ChartArea = "aireAbdo";
            areaAbdo.P97.ChartArea = "aireAbdo";
            areaAbdo.P99.ChartArea = "aireAbdo";

            areaHead.P3.Color = System.Drawing.Color.Red;
            areaHead.P97.Color = System.Drawing.Color.Red;

            List<DataBiometrique> listes = new List<DataBiometrique>();
            listes = new Fichier().ListeDataP3P10P50P90P97(@"H:\ProjetObstetric\Biometrics\PerimetreCranien.txt");

            new Graphiques().SetPoint(new Fichier().ListeData(listes, "P3"), areaHead.P3);
            new Graphiques().SetPoint(new Fichier().ListeData(listes, "P10"), areaHead.P10);
            new Graphiques().SetPoint(new Fichier().ListeData(listes, "P50"), areaHead.P50);
            new Graphiques().SetPoint(new Fichier().ListeData(listes, "P90"), areaHead.P90);
            new Graphiques().SetPoint(new Fichier().ListeData(listes, "P97"), areaHead.P97);

        }
    }
}
