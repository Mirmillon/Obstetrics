using Echographie.Classes;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Echographie.Utilitaires
{
    public class Graphiques
    {
        public void SetPoint (List<DataBiometrique> l , Series s)
        {
            foreach (DataBiometrique d in l)
            {
                DataPoint p = new DataPoint(d.Terme, d.Resultat);
                s.Points.Add(p);
            }
        }
    }
}
