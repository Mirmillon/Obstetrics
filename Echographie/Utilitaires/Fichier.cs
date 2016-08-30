using Echographie.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace Echographie.Utilitaires
{
    public class Fichier
    {
        public List<DataBiometrique> ListeDataP3P10P50P90P97(string fichierCsv)
        {
            // on cree une table
            List<DataBiometrique> listes = new List<DataBiometrique>();
            // on lit et on insert une nvelle ligne
            StreamReader fichier = File.OpenText(fichierCsv);
           
            while (fichier.Peek() >= 0)
            {
                // on lit 1 ligne et on ajoute
                string ligne = fichier.ReadLine();
                string[] vals = ligne.Split(',');

                DataBiometrique P3 = new DataBiometrique();
                DataBiometrique P10 = new DataBiometrique();
                DataBiometrique P50 = new DataBiometrique();
                DataBiometrique P90 = new DataBiometrique();
                DataBiometrique P97 = new DataBiometrique();

                P3.Terme = Convert.ToDouble(vals[0]);
                P3.Percentile = "P3";
                vals[1] = vals[1].Replace('.', ',');
                P3.Resultat = Convert.ToDouble(vals[1]);

                P10.Terme = Convert.ToDouble(vals[0]);
                P10.Percentile = "P10";
                vals[2] = vals[2].Replace('.', ',');
                P10.Resultat = Convert.ToDouble(vals[2]);

                P50.Terme = Convert.ToDouble(vals[0]);
                P50.Percentile = "P50";
                vals[3] = vals[3].Replace('.', ',');
                P50.Resultat = Convert.ToDouble(vals[3]);

                P90.Terme = Convert.ToDouble(vals[0]);
                P90.Percentile = "P90";
                vals[4] = vals[4].Replace('.', ',');
                P90.Resultat = Convert.ToDouble(vals[4]);

                P97.Terme = Convert.ToDouble(vals[0]);
                P97.Percentile = "P97";
                vals[5] = vals[5].Replace('.', ',');
                P97.Resultat = Convert.ToDouble(vals[5]);

                // on ajoute la ligne
                listes.Add(P3);
                listes.Add(P10);
                listes.Add(P50);
                listes.Add(P90);
                listes.Add(P97);
            }
            fichier.Close();
            return listes;
        }

        public List<DataBiometrique> ListeDataP1P3P5P10P50P90P95P97P99(string fichierCsv)
        {
            // on cree une table
            List<DataBiometrique> listes = new List<DataBiometrique>();

            DataBiometrique P1 = new DataBiometrique();
            DataBiometrique P3 = new DataBiometrique();
            DataBiometrique P5 = new DataBiometrique();
            DataBiometrique P10 = new DataBiometrique();
            DataBiometrique P50 = new DataBiometrique();
            DataBiometrique P90 = new DataBiometrique();
            DataBiometrique P95 = new DataBiometrique();
            DataBiometrique P97 = new DataBiometrique();
            DataBiometrique P99 = new DataBiometrique();

            return listes;
        }

        public List<DataBiometrique> ListeDataP3(List<DataBiometrique> liste)
        {
            List<DataBiometrique> listeP3 = new List<DataBiometrique>();
            foreach(DataBiometrique data in liste)
            {
                if (data.Percentile == "P3")
                {
                    listeP3.Add(data);
                }
            }

            return listeP3;

        }

        public List<DataBiometrique> ListeData(List<DataBiometrique> liste, string percentile)
        {
            List<DataBiometrique> l = new List<DataBiometrique>();
            foreach (DataBiometrique data in liste)
            {
                if (data.Percentile == percentile)
                {
                    l.Add(data);
                }
            }

            return l;

        }
    }
    

}
