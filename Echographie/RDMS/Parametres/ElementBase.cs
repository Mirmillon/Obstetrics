using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;
using Echographie.Classes;


namespace Echographie.RDMS.Parametres
{
    class ElementBase
    {
        public string ChaineConnection()
        {
            return @"Database=H:\Echo project\RDMS\BASEECHO.GDB;user=SYSDBA;Password=Xrgc540108";
        }

        #region REQUETES GET

        #region PREMIER TRIMESTRE
        public List<ElementAnatomique> GetElementsAnatomiques1T()
        {
            FbConnection connexion = new FbConnection(ChaineConnection());
            List<ElementAnatomique> l = new List<ElementAnatomique>();
            using (FbCommand commande = connexion.CreateCommand())
            {
                commande.CommandText = "GET_ELEMENTS_MORPHO_1T";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    connexion.Open();
                    FbDataReader reader = commande.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ElementAnatomique a = new ElementAnatomique();
                            a.CleElement = (int)reader[0];
                            a.Label = (string)reader[1];
                            a.Evaluation = -1;
                            l.Add(a);
                        }
                        connexion.Close();
                        return l;
                    }
                    connexion.Close();
                    return null;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    connexion.Close();
                    return null;
                }
            }
        }

        public List<ElementBiometrique> GetElementBiometrie1T()
        {
            FbConnection connexion = new FbConnection(ChaineConnection());
            List<ElementBiometrique> elements = new List<ElementBiometrique>();
            using (FbCommand commande = connexion.CreateCommand())
            {
                commande.CommandText = "GET_ELEMENT_DIMENSION";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    connexion.Open();
                    FbDataReader reader = commande.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ElementBiometrique p = new ElementBiometrique();
                            p.CleElement = (int)reader[0];
                            p.CleDimension = (int)reader[1];
                            p.Label = (string)reader[2];
                            elements.Add(p);
                        }
                        connexion.Close();
                        return elements;
                    }
                    connexion.Close();
                    return null;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    connexion.Close();
                    return null;
                }
            }
        }
        #endregion FIN PREMIER TRIMESTRE

        #endregion END REQUETES GET
    }
}
