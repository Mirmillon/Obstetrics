using System;

namespace Echographie.Utilitaires
{
    public class Calcul
    {
        public string AfficherTerme(int nbrJours)
        {
            return ((nbrJours) / 7).ToString() + " + " + ((nbrJours) % 7).ToString();
        }

        public int NbrJour(DateTime ddg)
        {
            return DateTime.Today.Subtract(ddg.AddDays(-14)).Days;
        }

        public static DateTime DateAccouchement(DateTime ddg)
        {
            return ddg.AddDays(273);
        }

        public int NbrJour(DateTime ddg, DateTime dateCalcul)
        {
            return dateCalcul.Subtract(ddg.AddDays(-14)).Days;
        }

        public static int NbrJourParLcc(string lcc)
        {
            return Convert.ToInt32(Math.Round(8.052 * Math.Sqrt(Convert.ToDouble(lcc)) + 23.73));
        }

        public DateTime CalculerDdgParLcc(string lcc, DateTime dtDateEcho)
        {

            /////////////////////////////////////////////////////////
            double NbJ = 8.052 * Math.Sqrt(Convert.ToDouble(lcc)) + 23.73;
            int nbrJours = Convert.ToInt32(Math.Round(NbJ));
            return dtDateEcho.AddDays(-nbrJours + 14);
            ///////////////////////////////////////////////////////////

        }

        //private DateTime CalculerDdgAvecLcc(string lcc)
        //{
        //    //int nbrJours;
        //    //double nbJ;


        //    ////nbJoursWisser = 35.72 + (1.082 * Math.Pow(Convert.ToDouble(lcc), 0.5)) + (1.472 * Convert.ToDouble(lcc)) - (0.09749 * Math.Pow(Convert.ToDouble(lcc), 1.5)); 
        //    ////Formule pour calculer le terme en nbre de jours 
        //    ////Convert.ToDouble(lcc) = la lcc entrée dans le txtLcc
        //    //nbJ = 8.052 * Math.Sqrt(Convert.ToDouble(lcc)) + 23.73;
        //    ////Conversion en int
        //    //nbrJours = Convert.ToInt32(Math.Round(nbJ));
        //    ////nbrJoursWisser = Convert.ToInt32(Math.Round(nbJoursWisser));
        //    ////MessageBox.Show("Jours " + nbrJours.ToString() + "/n" + "JoursW " + nbrJoursWisser.ToString());  
        //    ////on retire le nombre de jours de la date de l'echo pour connaitre le début de grossesse
        //    //ddg = dtpDateEcho.Value.AddDays(-nbrJours + 14);
        //    //return ddg;
        //}

        ///////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////
       /* var P = (.0005831 + Math.exp(-16.1992104 + (.2892432 * AgeMater)))

if (document.forms[0].A[0].checked ==false) {
P=(P+.0075)
}

    var OddsAgeTerme = ((1 / P) - 1)
form.RisqueAgeTerme.value=Math.round(1/P)
*/
     
        public double RisqueT21AgeMaternel(int age, bool atcdT21)
        {
            double p = (.0005831 + Math.Exp(-16.1992104 + (.2892432 * age)));
            if(atcdT21)
            {
                p = p + 0.0075;
            }
            return Math.Round(1/p);

        }
    }
}
