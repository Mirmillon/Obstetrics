using System;
using Echographie.Graphes;
using System.Windows.Forms.DataVisualization.Charting;
using Echographie.Classes;
using Echographie.Utilitaires;
using System.Collections.Generic;

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

            List<DataBiometrique> listes = new List<DataBiometrique>();
            listes = new Fichier().ListeDataP10P50P90(@"H:\ProjetObstetric\Biometrics\Humerus.csv");

           
            new Graphiques().SetPoint(new Fichier().ListeData(listes, "P10"), aireHumerus.P10);
            new Graphiques().SetPoint(new Fichier().ListeData(listes, "P50"), aireHumerus.P50);
            new Graphiques().SetPoint(new Fichier().ListeData(listes, "P90"), aireHumerus.P90);
          


        }
    }
}
