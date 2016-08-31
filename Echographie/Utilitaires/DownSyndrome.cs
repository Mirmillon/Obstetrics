using System;

namespace Echographie.Utilitaires
{
    public class DownSyndrome
    {
        /* var P = (.0005831 + Math.exp(-16.1992104 + (.2892432 * AgeMater)))
        if (document.forms[0].A[0].checked ==false) {
        P=(P+.0075)
        }
        var OddsAgeTerme = ((1 / P) - 1)
        form.RisqueAgeTerme.value=Math.round(1/P)
        */

      

       

     

        public double ClarteNuqualeAttendue(int lcc)
        {

            /*var CNattendue = Math.pow(10, (-.3599 + (0.0127 * form.LCC.value)) - (.000058 * form.LCC.value * form.LCC.value))
            CNattendue = CNattendue * 10
            CNattendue = Math.round(CNattendue)
            CNattendue = CNattendue / 10*/
            double cn = Math.Pow(10, (-.3599 + (0.0127 * lcc)) - (.000058 * lcc * lcc));
            return Math.Round(cn * 10) / 10;
        }

        public string AfficherClarteNuqualeAttendue(double cn)
        {
            double cnModulo = cn % 1;
            return Convert.ToString(cn - cnModulo) + "," + Convert.ToString(Math.Round(cnModulo * 10));
        }

       

        public double RapportVraisemblance(double mOM)
        {
            var Zd = ((.4342944819032518 * (Math.Log(mOM))) - .305) / .235;
            var Zu = (.4342944819032518 * (Math.Log(mOM))) / .12;

            return (Math.Round( (0.12 / 0.235) * Math.Exp(-0.5 * (Math.Pow(Zd, 2) - Math.Pow(Zu, 2))) *1000))/1000;
        }

        public double RisquePostClarteTerme(int age,bool atcdT21,double mOM)
        {
            return (Math.Round(OddsAgeTerme(age, atcdT21) / RapportVraisemblance(mOM)) + 1);
        }

        public string RisqueRelatifAgeEcho(int terme)
        {
            //double terme = (8.052 * Math.Sqrt(lcc) + 23.73);
            //var RisqueRelatif = (Math.pow(10, ((0.2718 * Math.log(Terme) * Math.log(Terme) * .434294482 * .434294482) - (1.023 * Math.log(Terme) * .434294482) + 0.9425)))
            //RRmodulo = RisqueRelatif % 1
            //RRentier = RisqueRelatif - RRmodulo
            //RRmodulo = RRmodulo * 1000
            //form.RisqueRelatif.value = RRentier + "," + Math.round(RRmodulo)//Risque relatif de T21 (Ã  la date de l'Ã©chographie
            double risqueRelatif = (Math.Pow(10, ((0.2718 * Math.Log(terme) * Math.Log(terme) * .434294482 * .434294482) - (1.023 * Math.Log(terme) * .434294482) + 0.9425)));
            double modulo = risqueRelatif % 1;
            double risqueRelatifEntier = risqueRelatif - modulo;
            modulo = modulo * 1000;
            return Convert.ToString(risqueRelatifEntier) + "," + Convert.ToString(Math.Round(modulo));
        }

        public double RisqueAgeDateEcho(int age, bool atcdT21,int terme)
        {
            //var OddsAgeDateEcho = OddsAgeTerme / RisqueRelatif
            //var OddsPostClarte = OddsAgeDateEcho
            //form.RisqueAgeDateEcho.value = Math.round(OddsAgeDateEcho + 1)
            double oddsAgeTerme = (1 / RisqueT21AgeMaternelTerme(age, atcdT21)) - 1;
            double rr = RisqueRelatifIntAgeEcho(terme);
            // return Math.Round((( / (RisqueRelatifAgeEcho(terme))) + 1);
            return Math.Round((oddsAgeTerme / rr)+ 1);
        }

        public double RisqueT21AgeMaternelTerme(int age, bool atcdT21)
        {
            double p = (.0005831 + Math.Exp(-16.1992104 + (.2892432 * age)));
            if (atcdT21)
            {
                p = p + 0.0075;
            }
            return Math.Round(1 / p);

        }

        public  double OddsAgeTerme(int age, bool atcdT21)
        {
            //var OddsAgeTerme = ((1 / P) - 1)
            return (1 / RisqueT21AgeMaternelTerme(age, atcdT21)) - 1;
        }

        private double RisqueRelatifIntAgeEcho(int terme)
        {
            //double terme = (8.052 * Math.Sqrt(lcc) + 23.73);
            //var RisqueRelatif = (Math.pow(10, ((0.2718 * Math.log(Terme) * Math.log(Terme) * .434294482 * .434294482) - (1.023 * Math.log(Terme) * .434294482) + 0.9425)))
            //RRmodulo = RisqueRelatif % 1
            //RRentier = RisqueRelatif - RRmodulo
            //RRmodulo = RRmodulo * 1000
            //form.RisqueRelatif.value = RRentier + "," + Math.round(RRmodulo)//Risque relatif de T21 (Ã  la date de l'Ã©chographie
            return  (Math.Pow(10, ((0.2718 * Math.Log(terme) * Math.Log(terme) * .434294482 * .434294482) - (1.023 * Math.Log(terme) * .434294482) + 0.9425)));
            //double modulo = risqueRelatif % 1;
            //double risqueRelatifEntier = risqueRelatif - modulo;
            //modulo = modulo * 1000;
            
        }
    }
}
