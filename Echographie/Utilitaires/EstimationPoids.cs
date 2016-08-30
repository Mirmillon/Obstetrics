using System;

namespace Echographie.Utilitaires
{
    class EstimationPoids
    {
        #region CONSTANTES
        const double zScore1 = -2.326;
        const double zScore3 = -1.881;
        const double zScore5 = -1.645;
        const double zScore10 = -1.282;
        const double zScore25 = -0.674;
        const double locale = 3605;
        const double derivationStandard = 13.229;
        const double locale1 = 0.973;
        const double locale2 = 0.1287;
        const int poidsMaternelMoyen = 64;
        const int tailleMaternelMoyen = 162;
        const int variationPoidsSexeFoetal = 78;
        // Prends les caractéristiques ENP 1998 de la France
        /***********************************************************************************************
         * paramètres de la présentation de lille 
         *  Taille = 5.7
         *  Poids = 9.6 * P - 0.13(P) au carré - 0.0007 (P) au cube
         *  Parite 2 = 110.2  Parite 3 = 124 Parite 4 = 149.4 Parite 5 = 160.5 OK
         *  Poids foetal optimum à 40 semaines = 3343.9
         *  Sexe garçon 155.5 OK
         ***********************************************************************************************/

        #endregion

        public double PoidsStandard(int semaines)
        {
            return Convert.ToDouble(Math.Exp(0.578 + 0.332 * semaines - 0.00354 * semaines * semaines));
        }
        public double PoidsEgo(int semaines)
        {
            return Convert.ToDouble(Math.Exp(0.578 + 0.330 * 40 - 0.00354 * 40 * 40));
        }
        public double Handloock1984(int ca)//ca en millimétres
        {
            double ac = ca / 10;
            return Math.Log(2.695 + (0.253 * ac) - (0.00275 * Math.Pow(ac, 2)));
        }
        public double Hadlock1984(double ca, double pc, double lf)
        {
            return Math.Abs((1.326 + (0.00107 * pc) + (0.00438 * ca) + (0.0158 * lf) - (0.0000326 * ca * lf)));
        }


        #region CALCLUL CENTILES
        public double PoidsP1(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) + P1(poids40s)));
        }

        public double PoidsP3(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) + P3(poids40s)));
        }
        public double PoidsP5(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) + P5(poids40s)));
        }

        public double PoidsP10(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) + P10(poids40s)));
        }

        public double PoidsP25(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) + P25(poids40s)));
        }


        public double PoidsP75(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) - P25(poids40s)));
        }

        public double PoidsP90(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) - P10(poids40s)));
        }

        public double PoidsP95(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) - P5(poids40s)));
        }
        public double PoidsP97(double terme, double poids40s)
        {
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) - P3(poids40s)));
        }

        public double PoidsP99(double terme, double poids40s)
        {

            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * ((locale1) - P1(poids40s)));
        }


        private double P1(double poids40s)
        {
            //return (derivationStandard / 100) * (poids40s / locale) * zScore1 * (poids40s / locale);
            return (locale2) * zScore1 * (locale1);
        }
        private double P3(double poids40s)
        {
            //return (derivationStandard / 100) * (poids40s / locale) * zScore3 * (poids40s / locale);
            return (locale2) * zScore3 * (locale1);
        }
        private double P5(double poids40s)
        {
            //return (derivationStandard / 100) * (poids40s / locale) * zScore5 * (poids40s / locale);
            return (locale2) * zScore5 * (locale1);

        }
        private double P10(double poids40s)
        {
            // return (derivationStandard / 100) * (poids40s / locale) * zScore10 * (poids40s / locale);
            return (locale2) * zScore10 * (locale1);

        }
        private double P25(double poids40s)
        {
            //return (derivationStandard / 100) * (poids40s / locale) * zScore25 * (poids40s / locale);
            return (locale2) * zScore25 * (locale1);
        }

        public double Mediane(double terme, double poids40s)
        {
            //return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * (poids40s / locale));
            return Math.Truncate(Math.Exp(0.578 + 0.332 * (terme + 0.5) - 0.00354 * (terme + 0.5) * (terme + 0.5)) * (locale1));

        }

        public string Calculer(string s1, string s2, string s3)
        {
            double poids = Hadlock1984(Convert.ToDouble(s1), Convert.ToDouble(s2), Convert.ToDouble(s3));
            return Math.Truncate(Math.Pow(10, poids)).ToString();
        }
        #endregion
    }
}
