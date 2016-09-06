using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;
using Echographie.Acteurs;
using Echographie.Classes;
using System.Data;

namespace Echographie.RDMS
{

        public class DataBase
        {
            public string ChaineConnection()
            {
                return @"Database=H:\Echo project\RDMS\BASEECHO.GDB;user=SYSDBA;Password=Xrgc540108";
            }

            #region REQUETES GET

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////

            #region REQUETE REFERENCES

            public List<Reference> GetAlive()
            {
                return GetReference("GET_ALIVE");
            }

            public List<Reference> GetGenre()
            {
                return GetReference("GET_GENRE");
            }

            public List<Reference> GetCivilStatut()
            {
                return GetReference("GET_CIVIL_STATUT");
            }

            public List<Reference> GetOutcome()
            {
                return GetReference("GET_OUTCOME");
            }

            public List<Reference> GetPregnancyKind()
            {
                return GetReference("GET_TYPE_GROSSESSE");
            }

            public List<Reference> GetDatation()
            {
                return GetReference("GET_TYPE_DATATION");
            }

            public List<Reference> GetTwin()
            {
                return GetReference("GET_TWIN");
            }

            public List<Reference> GetPregnancyUscKind()
            {
                return GetReference("GET_PREGNANCY_USC_KIND");
            }

            public List<Reference> GetCheck()
            {
                return GetReference("GET_CHECK");
            }

            public List<Reference> GetElements()
            {
                return GetReference("GET_ELEMENTS");
            }

            public List<Reference> GetDimension()
            {
                return GetReference("GET_DIMENSION");
            }

            public List<Reference> GetElementsMorpho1T()
            {
                return GetReference("GET_ELEMENTS_MORPHO_1T");
            }

            #endregion FIN REQUETE REFERENCES

            /////////////////////////////////////////////////////////////////////////////////////////

            #region REQUETES GET PATIENTS BY IDENTITE

            public List<Patient> GetPatients(string ps, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FML", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                p.FirstName = (string)reader[1];
                                //p.MiddleName = (string)reader[2];
                                p.LastName = (string)reader[3];
                                p.DateBirth = Convert.ToDateTime(reader[4]);
                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPatients(string ps, string name)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FML", FbDbType.VarChar, 30).Value = name;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                p.FirstName = (string)reader[1];
                                //p.MiddleName = (string)reader[2];
                                p.LastName = (string)reader[3];
                                p.DateBirth = Convert.ToDateTime(reader[4]);
                                p.Gender = (int)reader[6];
                                p.Statut = (int)reader[7];
                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPatients(string ps, string n1, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                p.FirstName = (string)reader[1];
                                //p.MiddleName = (string)reader[2];
                                p.LastName = (string)reader[3];
                                p.DateBirth = Convert.ToDateTime(reader[4]);
                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPatients(string ps, string n1, string n2)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                p.FirstName = (string)reader[1];
                                //p.MiddleName = (string)reader[2];
                                p.LastName = (string)reader[3];
                                p.DateBirth = Convert.ToDateTime(reader[4]);
                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPatients(string ps, string n1, string n2, string n3)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("FMLD3", FbDbType.VarChar, 30).Value = n3;

                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                p.FirstName = (string)reader[1];
                                //p.MiddleName = (string)reader[2];
                                p.LastName = (string)reader[3];
                                p.DateBirth = Convert.ToDateTime(reader[4]);
                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPatients(string ps, string n1, string n2, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                p.FirstName = (string)reader[1];
                                //p.MiddleName = (string)reader[2];
                                p.LastName = (string)reader[3];
                                p.DateBirth = Convert.ToDateTime(reader[4]);
                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPatients(string ps, string n1, string n2, string n3, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("FMLD3", FbDbType.VarChar, 30).Value = n3;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                p.FirstName = (string)reader[1];
                                //p.MiddleName = (string)reader[2];
                                p.LastName = (string)reader[3];
                                p.DateBirth = Convert.ToDateTime(reader[4]);
                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            #endregion FIN REQUETES GET PATIENTS BY IDENTITE

            /////////////////////////////////////////////////////////////////////////////////////////

            #region REQUETES GET PREGNANT WOMEN BY IDENTITE

            public List<PregnantWoman> GetPregnantWomen(string ps, string name)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FML", FbDbType.VarChar, 30).Value = name;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                p.NumeroPatient = (int)reader[1];
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                p.UneGrossesse.CleGrossesse = (int)reader[6];
                                p.UneGrossesse.Ddg = Convert.ToDateTime(reader[7]);
                                p.UneGrossesse.PregnancyKind = (int)reader[8];
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetPregnantWomen(string ps, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FML", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                p.NumeroPatient = (int)reader[1];
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                p.UneGrossesse.CleGrossesse = (int)reader[6];
                                p.UneGrossesse.Ddg = Convert.ToDateTime(reader[7]);
                                p.UneGrossesse.PregnancyKind = (int)reader[8];
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetPregnantWomen(string ps, string n1, string n2)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                p.NumeroPatient = (int)reader[1];
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                p.UneGrossesse.CleGrossesse = (int)reader[6];
                                p.UneGrossesse.Ddg = Convert.ToDateTime(reader[7]);
                                p.UneGrossesse.PregnancyKind = (int)reader[8];

                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetPregnantWomen(string ps, string n1, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                p.NumeroPatient = (int)reader[1];
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                p.UneGrossesse.CleGrossesse = (int)reader[6];
                                p.UneGrossesse.Ddg = Convert.ToDateTime(reader[7]);
                                p.UneGrossesse.PregnancyKind = (int)reader[8];

                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetPregnantWomen(string ps, string n1, string n2, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                p.NumeroPatient = (int)reader[1];
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                p.UneGrossesse.CleGrossesse = (int)reader[6];
                                p.UneGrossesse.Ddg = Convert.ToDateTime(reader[7]);
                                p.UneGrossesse.PregnancyKind = (int)reader[8];

                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetPregnantWomen(string ps, string n1, string n2, string n3)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("FMLD3", FbDbType.VarChar, 30).Value = n3;

                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                p.NumeroPatient = (int)reader[1];
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                p.UneGrossesse.CleGrossesse = (int)reader[6];
                                p.UneGrossesse.Ddg = Convert.ToDateTime(reader[7]);
                                p.UneGrossesse.PregnancyKind = (int)reader[8];

                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetPregnantWomen(string ps, string n1, string n2, string n3, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("FMLD3", FbDbType.VarChar, 30).Value = n3;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                p.NumeroPatient = (int)reader[1];
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                p.UneGrossesse.CleGrossesse = (int)reader[6];
                                p.UneGrossesse.Ddg = Convert.ToDateTime(reader[7]);
                                p.UneGrossesse.PregnancyKind = (int)reader[8];

                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            #endregion FIN REQUETES GET PREGNANT WOMEN BY IDENTITE

            /////////////////////////////////////////////////////////////////////////////////////////

            #region REQUETES GET PEOPLE BY IDENTITE

            public List<Patient> GetPeople(string ps, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FML", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }

                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            public List<PregnantWoman> GetPeople(string ps, string name)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> peoples = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FML", FbDbType.VarChar, 30).Value = name;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                //if (!(reader[8] == DBNull.Value))
                                //{
                                //    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                //}
                                //if (!(reader[9] == DBNull.Value))
                                //{
                                //    p.UneGrossesse.Outcome = (int)reader[9];
                                //}


                                peoples.Add(p);
                            }
                            connexion.Close();
                            return peoples;
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

            public List<Patient> GetPeople(string ps, string n1, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }

                                patients.Add(p);
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPeople(string ps, string n1, string n2)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }

                                patients.Add(p); ;
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPeople(string ps, string n1, string n2, string n3)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("FMLD3", FbDbType.VarChar, 30).Value = n3;

                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }

                                patients.Add(p); ;
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPeople(string ps, string n1, string n2, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }

                                patients.Add(p); ;
                            }
                            connexion.Close();
                            return patients;
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

            public List<Patient> GetPeople(string ps, string n1, string n2, string n3, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Patient> patients = new List<Patient>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("FMLD3", FbDbType.VarChar, 30).Value = n3;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Patient p = new Patient();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }

                                patients.Add(p); ;
                            }
                            connexion.Close();
                            return patients;
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


            #endregion FIN REQUETES GET PEOPLE BY IDENTITE

            /////////////////////////////////////////////////////////////////////////////////////////

            #region GET FEMALE PEOPLE BY IDENTITE
            public List<PregnantWoman> GetFemalePeople(string ps, string name)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FML", FbDbType.VarChar, 30).Value = name;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                if (!(reader[8] == DBNull.Value))
                                {
                                    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                }
                                if (!(reader[9] == DBNull.Value))
                                {
                                    p.UneGrossesse.PregnancyKind = (int)reader[9];
                                }
                                if (!(reader[10] == DBNull.Value))
                                {
                                    p.UneGrossesse.Outcome = (int)reader[10];
                                }
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetFemalePeople(string ps, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FML", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                if (!(reader[8] == DBNull.Value))
                                {
                                    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                }
                                if (!(reader[9] == DBNull.Value))
                                {
                                    p.UneGrossesse.PregnancyKind = (int)reader[9];
                                }
                                if (!(reader[10] == DBNull.Value))
                                {
                                    p.UneGrossesse.Outcome = (int)reader[10];
                                }
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetFemalePeople(string ps, string n1, string n2)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                if (!(reader[8] == DBNull.Value))
                                {
                                    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                }
                                if (!(reader[9] == DBNull.Value))
                                {
                                    p.UneGrossesse.PregnancyKind = (int)reader[9];
                                }
                                if (!(reader[10] == DBNull.Value))
                                {
                                    p.UneGrossesse.Outcome = (int)reader[10];
                                }
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetFemalePeople(string ps, string n1, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                if (!(reader[8] == DBNull.Value))
                                {
                                    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                }
                                if (!(reader[9] == DBNull.Value))
                                {
                                    p.UneGrossesse.PregnancyKind = (int)reader[9];
                                }
                                if (!(reader[10] == DBNull.Value))
                                {
                                    p.UneGrossesse.Outcome = (int)reader[10];
                                }
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetFemalePeople(string ps, string n1, string n2, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                if (!(reader[8] == DBNull.Value))
                                {
                                    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                }
                                if (!(reader[9] == DBNull.Value))
                                {
                                    p.UneGrossesse.PregnancyKind = (int)reader[9];
                                }
                                if (!(reader[10] == DBNull.Value))
                                {
                                    p.UneGrossesse.Outcome = (int)reader[10];
                                }
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetFemalePeople(string ps, string n1, string n2, string n3)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("FMLD3", FbDbType.VarChar, 30).Value = n3;

                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                if (!(reader[8] == DBNull.Value))
                                {
                                    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                }
                                if (!(reader[9] == DBNull.Value))
                                {
                                    p.UneGrossesse.PregnancyKind = (int)reader[9];
                                }
                                if (!(reader[10] == DBNull.Value))
                                {
                                    p.UneGrossesse.Outcome = (int)reader[10];
                                }
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetFemalePeople(string ps, string n1, string n2, string n3, DateTime d)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("FMLD1", FbDbType.VarChar, 30).Value = n1;
                    pc.Add("FMLD2", FbDbType.VarChar, 30).Value = n2;
                    pc.Add("FMLD3", FbDbType.VarChar, 30).Value = n3;
                    pc.Add("DOB", FbDbType.Date, 10).Value = d;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                if (!(reader[8] == DBNull.Value))
                                {
                                    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                }
                                if (!(reader[9] == DBNull.Value))
                                {
                                    p.UneGrossesse.PregnancyKind = (int)reader[9];
                                }
                                if (!(reader[10] == DBNull.Value))
                                {
                                    p.UneGrossesse.Outcome = (int)reader[10];
                                }
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

        #endregion FIN GET FEMALE PEOPLE BY IDENTITE

            #region REQUETES GET BY KEY

            public Grossesse GetKeyGrossesseByKeyPatient(int cle)
            {

                FbConnection connexion = new FbConnection(ChaineConnection());
                Grossesse p = new Grossesse();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "GET_KEY_GRO_BY_CLE_PATIENT";
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("KEY", FbDbType.Integer, 0).Value = cle;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                p.CleGrossesse = (int)reader[0];
                            }
                            connexion.Close();
                            return p;
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

            public Patient GetPatientByKeyGrossesse(int cle)
                {
                    FbConnection connexion = new FbConnection(ChaineConnection());
                    Patient p = new Patient();
                    using (FbCommand commande = connexion.CreateCommand())
                    {
                        commande.CommandText = "GET_PATIENT_KEY_DOSSIER_OBS";
                        commande.CommandType = CommandType.StoredProcedure;
                        FbParameterCollection pc = commande.Parameters;
                        pc.Add("KEY", FbDbType.Integer, 0).Value = cle;
                        try
                        {
                            connexion.Open();
                            FbDataReader reader = commande.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    p.ClePeople = (int)reader[0];
                                    p.FirstName = (string)reader[1];
                                    if (!(reader[2] == DBNull.Value))
                                    {
                                        p.MiddleName = (string)reader[2];
                                    }
                                    p.LastName = (string)reader[3];
                                    p.DateBirth = Convert.ToDateTime(reader[4]);

                                }
                                connexion.Close();
                                return p;
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

            public Patient GetPeopleByKey(int cle)
                {
                    FbConnection connexion = new FbConnection(ChaineConnection());
                    Patient p = new Patient();
                    using (FbCommand commande = connexion.CreateCommand())
                    {
                        commande.CommandText = "GET_PEOPLE_BY_KEY";
                        commande.CommandType = CommandType.StoredProcedure;
                        FbParameterCollection pc = commande.Parameters;
                        pc.Add("KEY", FbDbType.Integer, 0).Value = cle;
                        try
                        {
                            connexion.Open();
                            FbDataReader reader = commande.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    p.ClePeople = (int)reader[0];
                                    if (!(reader[1] == DBNull.Value))
                                    {
                                        p.NumeroPatient = (int)reader[1];
                                    }
                                    p.FirstName = (string)reader[2];
                                    if (!(reader[3] == DBNull.Value))
                                    {
                                        p.MiddleName = (string)reader[3];
                                    }
                                    p.LastName = (string)reader[4];
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                    if (!(reader[6] == DBNull.Value))
                                    {
                                        p.Gender = (int)reader[6];
                                    }
                                    if (!(reader[7] == DBNull.Value))
                                    {
                                        p.Statut = (int)reader[7];
                                    }

                                }
                                connexion.Close();
                                return p;
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

            public Grossesse GetPregnancyByKey(int cle)
                {
                    FbConnection connexion = new FbConnection(ChaineConnection());
                    Grossesse g = new Grossesse();
                    using (FbCommand commande = connexion.CreateCommand())
                    {
                        commande.CommandText = "GET_PREGNANCY_KEY";
                        commande.CommandType = CommandType.StoredProcedure;
                        FbParameterCollection pc = commande.Parameters;
                        pc.Add("KEY", FbDbType.Integer, 0).Value = cle;
                        try
                        {
                            connexion.Open();
                            FbDataReader reader = commande.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    g.CleGrossesse = (int)reader[0];
                                    g.Ddg = Convert.ToDateTime(reader[1]);
                                    g.PregnancyKind = (int)reader[2];
                                    if (g.PregnancyKind == 1)
                                    {
                                        g.NombreFoetus = 1;
                                    }
                                    else if (g.PregnancyKind == 2)
                                    {
                                        g.NombreFoetus = 2;
                                    }
                                }
                                connexion.Close();
                                return g;
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

            public int GetKeyPatientByKeyPregnancy(int cle)
            {
                return SetForeignKey("GET_KEY_PATIENT_KEY_DOSSIER", cle);                
            }

            //TODO Refaire cette methode
            public List<Foetus> GetPoidsFoetus(int keyGrossesse)
                {
                    FbConnection connexion = new FbConnection(ChaineConnection());
                    List<Foetus> poids = new List<Foetus>();
                    using (FbCommand commande = connexion.CreateCommand())
                    {
                        commande.CommandText = "GET_POIDS_FOETUS";
                        commande.CommandType = CommandType.StoredProcedure;
                        FbParameterCollection pc = commande.Parameters;
                        pc.Add("KEY", FbDbType.Integer, 0).Value = keyGrossesse;
                        try
                        {
                            connexion.Open();
                            FbDataReader reader = commande.ExecuteReader();
                            if (reader.HasRows)
                            {
                                connexion.Open();
                                commande.ExecuteNonQuery();
                                while (reader.Read())
                                {
                                    Foetus e = new Foetus();
                                    e.CleGrossesse = (int)reader[0];
                                    e.Ddg = Convert.ToDateTime(reader[1]);
                                    e.NumeroFoetus = (int)reader[2];
                                    e.DateUsc = Convert.ToDateTime(reader[3]);
                                    e.Poids = (int)reader[4];
                                    poids.Add(e);
                                }
                                connexion.Close();
                                return poids;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.ToString());
                            connexion.Close();
                            return null;
                        }
                    }

                }

            public Patient GetPeopleFemaleByKey(int cle)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "GET_PEOPLE_FEMALE_BY_KEY";
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("KEY", FbDbType.Integer, 0).Value = cle;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        Patient p = new Patient();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                            }
                            connexion.Close();
                            return p;
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


            #endregion FIN REQUETES GET BY KEY

        /////////////////////////////////////////////////////////////////////////////////////////


            #region REQUETES LISTES

            public List<PregnantWoman> GetListPregnantWomen()
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "GET_PREGNANT_WOMEN";
                    commande.CommandType = System.Data.CommandType.StoredProcedure;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                p.NumeroPatient = (int)reader[1];
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                p.DateBirth = Convert.ToDateTime(reader[5]);
                                p.UneGrossesse.CleGrossesse = (int)reader[6];
                                p.UneGrossesse.Ddg = Convert.ToDateTime(reader[7]);
                                p.UneGrossesse.PregnancyKind = (int)reader[8];
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetPeopleMale()
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "GET_PEOPLE_MALE";
                    commande.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }


                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

            public List<PregnantWoman> GetPeopleFemale()
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<PregnantWoman> pregnantWomen = new List<PregnantWoman>();
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "GET_PEOPLE_FEMALE";
                    commande.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        connexion.Open();
                        FbDataReader reader = commande.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {

                                PregnantWoman p = new PregnantWoman();
                                p.ClePeople = (int)reader[0];
                                if (!(reader[1] == DBNull.Value))
                                {
                                    p.NumeroPatient = (int)reader[1];
                                }
                                p.FirstName = (string)reader[2];
                                if (!(reader[3] == DBNull.Value))
                                {
                                    p.MiddleName = (string)reader[3];
                                }
                                p.LastName = (string)reader[4];
                                if (!(reader[5] == DBNull.Value))
                                {
                                    p.DateBirth = Convert.ToDateTime(reader[5]);
                                }

                                if (!(reader[6] == DBNull.Value))
                                {
                                    p.Gender = (int)reader[6];
                                }
                                if (!(reader[7] == DBNull.Value))
                                {
                                    p.Statut = (int)reader[7];
                                }
                                if (!(reader[8] == DBNull.Value))
                                {
                                    p.UneGrossesse.CleGrossesse = (int)reader[8];
                                }
                                if (!(reader[9] == DBNull.Value))
                                {
                                    p.UneGrossesse.PregnancyKind = (int)reader[9];
                                }
                                if (!(reader[10] == DBNull.Value))
                                {
                                    p.UneGrossesse.Outcome = (int)reader[10];
                                }
                                pregnantWomen.Add(p);
                            }
                            connexion.Close();
                            return pregnantWomen;
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

        //TODO Verifier cette methode
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
                                p.Label = (string)reader[3];

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

            #endregion FIN REQUETES LISTES

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////


            #endregion FIN REQUETES GET

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////

            #region REQUETES SET

            public int SetPersonne(string firstName, string middleName, string lastName, DateTime dob, int genre, int statut)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "SET_PERSONNE";
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("CLE", FbDbType.Integer, 0).Direction = ParameterDirection.Output;
                    pc.Add("FIRSTNAME", FbDbType.VarChar, 30).Value = firstName;
                    pc.Add("MIDDLANAME", FbDbType.VarChar, 30).Value = middleName;
                    pc.Add("LASTNAME", FbDbType.VarChar, 30).Value = lastName;
                    pc.Add("DOB", FbDbType.Date, 10).Value = dob;
                    pc.Add("GENRE", FbDbType.Integer, 0).Value = genre;
                    pc.Add("STATUT", FbDbType.Integer, 0).Value = statut;
                    try
                    {
                        connexion.Open();
                        commande.ExecuteNonQuery();
                        int cle;
                        if (pc[0].Value is int)
                        {
                            cle = (int)pc[0].Value;
                            return cle;

                        }
                        else
                        {
                            cle = -2;
                        }

                        connexion.Close();
                        return cle;

                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        connexion.Close();
                        return -1;
                    }
                }
            }

            public int SetPregnancy(int clePer, DateTime dlm, DateTime ddg, int kindG)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "SET_PREGNANCY";
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("CLE", FbDbType.Integer, 0).Direction = ParameterDirection.Output;
                    pc.Add("CLEPER", FbDbType.Integer, 0).Value = clePer;
                    pc.Add("DLM", FbDbType.Date, 10).Value = dlm;
                    pc.Add("DDG", FbDbType.Date, 10).Value = ddg;
                    pc.Add("KIND", FbDbType.Integer, 0).Value = kindG;
                    try
                    {
                        connexion.Open();
                        commande.ExecuteNonQuery();
                        int cle;
                        if (pc[0].Value is int)
                        {
                            cle = (int)pc[0].Value;
                            return cle;

                        }
                        else
                        {
                            cle = -2;
                        }

                        connexion.Close();
                        return cle;

                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        connexion.Close();
                        return -1;
                    }
                }
            }

            public int SetPatient(int clePer)
            {
                return SetForeignKey("SET_PATIENT", clePer);
            }

            public int SetUS(int cleGro)
            {
                return SetForeignKey("SET_ULTRASOUNDSCAN", cleGro);
            }

            public void SetFoetus(int cle, int number)
            {
                for (int i = 1; i < number + 1; ++i)
                {
                    Foetus("SET_FOETUS", cle, i);
                }
            }

            public void SetPoids(int numEcho, int numFoetus, int poids)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "SET_POIDS";
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("CLE", FbDbType.Integer, 0).Value = numEcho;
                    pc.Add("FOETUS", FbDbType.Integer, 0).Value = numFoetus;
                    pc.Add("POIDS", FbDbType.Integer, 0).Value = poids;

                    try
                    {
                        connexion.Open();
                        commande.ExecuteNonQuery();
                        connexion.Close();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        connexion.Close();

                    }
                }
            }

            public void SetMorphologie(int numEcho, int numFoetus, int element, int check)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "SET_MORPHOLOGIE_FOETUS";
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("CLE", FbDbType.Integer, 0).Value = numEcho;
                    pc.Add("FOETUS", FbDbType.Integer, 0).Value = numFoetus;
                    pc.Add("ELEMENT", FbDbType.Integer, 0).Value = element;
                    pc.Add("CHECK", FbDbType.Integer, 0).Value = check;
                    try
                    {
                        connexion.Open();
                        commande.ExecuteNonQuery();
                        connexion.Close();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        connexion.Close();
                    }
                }
            }

            public void SetBiometrieFoetus(int numEcho, int numFoetus, int element, int dimension, double taile)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = "SET_BIOMETRIC_FOETUS";
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("CLE", FbDbType.Integer, 0).Value = numEcho;
                    pc.Add("FOETUS", FbDbType.Integer, 0).Value = numFoetus;
                    pc.Add("ELEMENT", FbDbType.Integer, 0).Value = element;
                    pc.Add("DIMENSION", FbDbType.Integer, 0).Value = dimension;
                    pc.Add("TAILLE", FbDbType.Double, 0).Value = taile;
                    try
                    {
                        connexion.Open();
                        commande.ExecuteNonQuery();
                        connexion.Close();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        connexion.Close();
                    }
                }
            }

            #endregion FIN REQUETES SET

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////

            #region REQUETES UPDATE

            public void UpdatePatient(int pkey)
            {

            }

            public void UpdatePregnancy(int pke)
            {

            }

            #endregion FIN REQUETES UPDATE

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////

            #region REQUETES DELETE

            public void DeletePregnancy(int pke)
            {

            }

            #endregion FIN REQUETES DELETE

            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////

            #region REQUETES GENERIQUES

            private List<Reference> GetReference(string sql)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                List<Reference> references = new List<Reference>();
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
                                Reference p = new Reference();
                                p.Cle = (int)reader[0];
                                p.Label = (string)reader[1];
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

            private void Foetus(string ps, int cle, int number)
            {
                FbConnection connexion = new FbConnection(ChaineConnection());
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("CLE", FbDbType.Integer, 0).Value = cle;
                    pc.Add("NUMBER", FbDbType.Integer, 0).Value = number;
                    try
                    {
                        connexion.Open();
                        commande.ExecuteNonQuery();
                        connexion.Close();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        connexion.Close();
                    }
                }
            }

            private int SetForeignKey(string ps, int fK)
            {               
                FbConnection connexion = new FbConnection(ChaineConnection());
                using (FbCommand commande = connexion.CreateCommand())
                {
                    commande.CommandText = ps;
                    commande.CommandType = CommandType.StoredProcedure;
                    FbParameterCollection pc = commande.Parameters;
                    pc.Add("PK", FbDbType.Integer, 0).Direction = ParameterDirection.Output;
                    pc.Add("FK", FbDbType.Integer, 0).Value = fK;

                    try
                    {
                        connexion.Open();
                        commande.ExecuteNonQuery();
                        connexion.Close();
                        return (int)pc[0].Value;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        connexion.Close();
                        return -2;
                    }
                }
            }

            #endregion END REQUETES GENERIQUES
        }
    }



