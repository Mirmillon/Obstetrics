using System;
using System.Data;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;
using Echographie.Classes;
using Echographie.Classes.Parametres;


namespace Echographie.RDMS.Parametres
{
    class ElementBase
    {

        public string ChaineConnection()
        {
            return @"Database=H:\Echo project\RDMS\BASEECHO.GDB;user=SYSDBA;Password=Xrgc540108";
        }

        private int execution(FbCommand commande, FbConnection connexion)
        {
            connexion.Open();
            commande.ExecuteNonQuery();
            connexion.Close();
            return 1;
        }

        private int intExeption( FbConnection connexion, Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.ToString());
            connexion.Close();
            return 0;
        }

        private int execExcep(FbCommand commande, FbConnection connexion,Exception ex)
        {
            try { return execution(commande, connexion); } catch {return intExeption(connexion, ex); }
        }


        #region REQUETES GET

        #region ELEMENT
        public List<Element> GetElementLangue(int cle_element)
        {
            FbConnection connexion = new FbConnection(ChaineConnection());
            List<Element> listes = new List<Element>();
            using (FbCommand commande = connexion.CreateCommand())
            {
                commande.CommandText = "GET_LANGUES_ELE";
                commande.CommandType = System.Data.CommandType.StoredProcedure;
                FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FbDbType.Integer, 0).Value = cle_element;
                try
                {
                    connexion.Open();
                    FbDataReader reader = commande.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Element a = new Element();
                            a.CleElement = cle_element;
                            if (!(reader[1] == DBNull.Value))
                            {
                                a.CleLangue = (int)reader[1];
                            }
                            if (!(reader[2] == DBNull.Value))
                            {
                                a.Label = (string)reader[2];
                            }
                            if (!(reader[3] == DBNull.Value))
                            {
                                a.Description = (string)reader[3];
                            }
                            listes.Add(a);
                        }
                        connexion.Close();
                        return listes;
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
        #endregion

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
                commande.CommandText = "GET_ELEMENT_DIMENSION_1T";
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

        #region REFERENCES

        public List<Reference> GetLangue()
        {
            return new DataBase().GetReference("GET_LANGUE");
        }

        public List<ReferenceLangue> GetDimensionLangue()
        {
            return GetReferenceLangue("GET_DIMENSION_LANGUE");
        }

        public List<Reference> GetDimensionEng()
        {
            return new DataBase().GetReference("GET_DIMENSION_ENG");
        }

        public List<Reference> GetDimensionTag()
        {
            return new DataBase().GetReference("GET_DIMENSION_TAG");
        }

        public List<Reference> GetDimensionFr()
        {
            return new DataBase().GetReference("GET_DIMENSION_FR");
        }

        public List<ReferenceLangue> GetElementNameLangue()
        {
            return GetReferenceLangue("");
        }

        public List<Reference> GetElementNameEng()
        {
            return new DataBase().GetReference("");
        }

        public List<Reference> GetElementNameTag()
        {
            return new DataBase().GetReference("");
        }

        public List<Reference> GetElementNameFr()
        {
            return new DataBase().GetReference("");
        }

        public List<ReferenceLangue> GetDescriptionLangue()
        {
            return GetReferenceLangue("");
        }

        public List<Reference> GetDescriptionEng()
        {
            return new DataBase().GetReference("");
        }

        public List<Reference> GetDescriptionTag()
        {
            return new DataBase().GetReference("");
        }

        public List<Reference> GetDescriptionFr()
        {
            return new DataBase().GetReference("");
        }

        #endregion END REFERENCES

        #endregion END REQUETES GET

        #region REQUETES SET

        public int SetNewElement(int cleLangue,string element)
        {
            FbConnection connexion = new FbConnection(ChaineConnection());
            using (FbCommand commande = connexion.CreateCommand())
            {
                commande.CommandText = "SET_NEW_ELEMENT";
                commande.CommandType = CommandType.StoredProcedure;
                FbParameterCollection pc = commande.Parameters;
                pc.Add("CLELANGUE", FbDbType.Integer, 0).Value = cleLangue;
                pc.Add("LABEL", FbDbType.VarChar, 30).Value = element;
                //pc.Add("DESCRIPTION", FbDbType.VarChar, 900).Value = description;
                try
                {
                    return execution(commande, connexion);
                }
                catch (Exception ex)
                {
                    return intExeption(connexion, ex);
                }
            }
        }

        public int SetNewElementLangue(int cleElement, int cleLangue, string label, string description)
        {
            FbConnection connexion = new FbConnection(ChaineConnection());
            using (FbCommand commande = connexion.CreateCommand())
            {
                commande.CommandText = "SET_NEW_ELEMENT_LANGUE_NEW";
                commande.CommandType = CommandType.StoredProcedure;
                FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FbDbType.Integer, 0).Value = cleElement;
                pc.Add("CLELANGUE", FbDbType.Integer, 0).Value = cleLangue;
                pc.Add("LABEL", FbDbType.VarChar, 30).Value = label;
                pc.Add("DESCRIPTION", FbDbType.VarChar, 900).Value = description;
                try
                {
                    return execution(commande, connexion);
                }
                catch (Exception ex)
                {
                    return intExeption(connexion, ex);
                }
            }
        }

       

        #endregion END REQUETES SET

        #region REQUETES UPDATE

        public int UpdateElementLangue(int cleElement, int cleLangue, string label, string description)
        {
            FbConnection connexion = new FbConnection(ChaineConnection());
            using (FbCommand commande = connexion.CreateCommand())
            {
                commande.CommandText = "UPDATE_ELEMENT_LANGUE_NEW";
                commande.CommandType = CommandType.StoredProcedure;
                FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FbDbType.Integer, 0).Value = cleElement;
                pc.Add("CLELANGUE", FbDbType.Integer, 0).Value = cleLangue;
                pc.Add("LABEL", FbDbType.VarChar, 30).Value = label;
                pc.Add("DESCRIPTION", FbDbType.VarChar, 500).Value = description;
                try
                {
                    return execution(commande, connexion);
                }
                catch (Exception ex)
                {
                    return intExeption(connexion, ex);
                }
            }
        }

        public  int  UpdateElement(int cleElement)
        {
            FbConnection connexion = new FbConnection(ChaineConnection());
            using (FbCommand commande = connexion.CreateCommand())
            {
                commande.CommandText = "UPDATE_ELEMENT";
                commande.CommandType = CommandType.StoredProcedure;
                FbParameterCollection pc = commande.Parameters;
                pc.Add("CLE", FbDbType.Integer, 0).Value = cleElement;
                //pc.Add("CLELANGUE", FbDbType.Integer, 0).Value = cleLangue;
                //pc.Add("LABEL", FbDbType.VarChar, 30).Value = label;
                //pc.Add("DESCRIPTION", FbDbType.VarChar, 900).Value = description;
                try
                {
                    return execution(commande, connexion);
                }
                catch (Exception ex)
                {
                    return intExeption(connexion, ex);
                }
            }
        }

        #endregion END REQUETES UPDATE

        #region REQUETES DELETE

        #endregion END REQUETES DELETE

        #region REQUETES GENERIQUES

        public List<ReferenceLangue> GetReferenceLangue(string sql)
        {
            FbConnection connexion = new FbConnection(ChaineConnection());
            List<ReferenceLangue> references = new List<ReferenceLangue>();
            using (FbCommand commande = connexion.CreateCommand())
            {
                commande.CommandText = sql;
                commande.CommandType = CommandType.StoredProcedure;
                try
                {
                    connexion.Open();
                    FbDataReader reader = commande.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ReferenceLangue p = new ReferenceLangue();
                            p.Cle = (int)reader[0];
                            p.CleLangue = (int)reader[1];
                            p.Label = (string)reader[2];
                            references.Add(p);
                        }
                        connexion.Close();
                        return references;
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

       



        #endregion END REQUETES GENERIQUES

    }
}
