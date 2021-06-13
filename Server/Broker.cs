using Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Broker
    {
        SqlConnection connection;
        SqlCommand command;
        SqlTransaction transaction;

        void connect()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProSoft-Mart-2021;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            command = connection.CreateCommand();
        }

        Broker()
        {
            connect();
        }

        private static Broker Instance;

        public static Broker GetInstance()
        {
            if(Instance == null)
            {
                Instance = new Broker();
            }
            return Instance;
        }

        internal int BrojPrimljenihGolova(int reprezentacijaId)
        {
            int golovi = 0;
            try
            {
                connection.Open();
                command.CommandText = $"select * from Utakmica where DomacinID = {reprezentacijaId} or GostID = {reprezentacijaId}";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader[2] == reprezentacijaId)
                    {
                        golovi += (int)reader[5];
                    }
                    if ((int)reader[3] == reprezentacijaId)
                    {
                        golovi += (int)reader[4];
                    }
                }
                reader.Close();
                return golovi;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        internal List<Tabela> VratiTabelu(string grupa)
        {
            List<Tabela> tabela = new List<Tabela>();
            try
            {
                connection.Open();
                command.CommandText = $"select * from Utakmica u join Reprezentacija d " +
                    $"on(u.DomacinID = d.ReprezentacijaID) " +
                    $"join Reprezentacija g on(u.GostID = g.ReprezentacijaID) " +
                    $"where u.Grupa = '{grupa}'";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //Reprezentacija r1 = VratiRepku((int)reader[2]);
                    //Reprezentacija r2 = VratiRepku((int)reader[3]);
                    Tabela t1 = new Tabela
                    {
                        RepkaID = (int)reader[6],
                        NazivRepke = (string)reader[7]
                        
                    };

                    Tabela t2 = new Tabela
                    {
                        RepkaID = (int)reader[8],
                        NazivRepke = (string)reader[9]
                        
                    };
                    bool postojiT1 = false;
                    bool postojiT2 = false;
                    foreach(Tabela t in tabela)
                    {
                        if (t.NazivRepke == t1.NazivRepke)
                            postojiT1 = true;
                        if (t.NazivRepke == t2.NazivRepke)
                            postojiT2 = false;
                    }
                    if (!postojiT1)
                        tabela.Add(t1);
                    if (!postojiT2)
                    {
                        tabela.Add(t2);
                    }
                }
                reader.Close();
                connection.Close();
                foreach(Tabela t in tabela)
                {
                    t.GolovaDala = BrojDatihGolova(t.RepkaID);
                    t.GolovaPrimila = BrojPrimljenihGolova(t.RepkaID);
                    t.GolRazlika = t.GolovaDala - t.GolovaPrimila;
                }


                return tabela;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
            //finally
            //{
            //    if (connection != null)
            //    {
            //        connection.Close();
            //    }
            //}
        }

        internal int BrojDatihGolova(int reprezentacijaId)
        {
            int golovi = 0;
            try
            {
                connection.Open();
                command.CommandText = $"select * from Utakmica where DomacinID = {reprezentacijaId} or GostID = {reprezentacijaId}";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if((int)reader[2] == reprezentacijaId)
                    {
                        golovi += (int)reader[4];
                    }
                    if((int)reader[3] == reprezentacijaId)
                    {
                        golovi += (int)reader[5];
                    }
                }
                reader.Close();
                return golovi;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        void Template()
        {
            try
            {
                connection.Open();
                command.CommandText = $"";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if(connection != null)
                {
                    connection.Close();
                }
            }
        }

        internal List<Reprezentacija> VratiSveRepke()
        {
            List<Reprezentacija> repke = new List<Reprezentacija>();
            try
            {
                connection.Open();
                command.CommandText = $"select * from Reprezentacija";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Reprezentacija r = new Reprezentacija
                    {
                        ReprezentacijaId = (int)reader[0],
                        Naziv = (string)reader[1]
                    };
                    repke.Add(r);
                }
                reader.Close();
                return repke;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        internal int SacuvajIzmene(List<Utakmica> utakmice)
        {
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand("", connection, transaction);
                foreach(Utakmica u in utakmice)
                {
                    if(u.Status == Status.Izmeni)
                    {
                        command.CommandText = $"update Utakmica " +
                            $"set Grupa = '{u.Grupa}', DomacinID = {u.Domacin.ReprezentacijaId}, " +
                            $"GostID = {u.Gost.ReprezentacijaId}, GolovaDomacin = {u.GolovaDomacin}, " +
                            $"GolovaGost = {u.GolovaGost} " +
                            $"where UtakmicaID = {u.UtakmicaId}";
                        command.ExecuteNonQuery();
                    }
                    if(u.Status == Status.Obrisi)
                    {
                        command.CommandText = $"delete from Utakmica where UtakmicaID = {u.UtakmicaId}";
                        command.ExecuteNonQuery();
                    }
                }

                transaction.Commit();
                return 1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                transaction.Rollback();
                return 0;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        internal List<Utakmica> VratiSveUtakmice()
        {
            List<Utakmica> utakmice = new List<Utakmica>();
            try
            {
                connection.Open();
                command.CommandText = $"select * from Utakmica";
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Utakmica u = new Utakmica
                    {
                        UtakmicaId = (int)reader[0],
                        Grupa = (string)reader[1],
                        Domacin = new Reprezentacija { ReprezentacijaId = (int)reader[2] },
                        Gost = new Reprezentacija { ReprezentacijaId = (int)reader[3] },
                        
                    };
                    if(reader[4] == DBNull.Value)
                    {
                        u.GolovaDomacin = -1;
                    }
                    else
                    {
                        u.GolovaDomacin = (int)reader[4];
                    }
                    if (reader[5] == DBNull.Value)
                    {
                        u.GolovaGost = -1;
                    }
                    else
                    {
                        u.GolovaGost = (int)reader[5];
                    }
                    utakmice.Add(u);
                }
                reader.Close();
                foreach(Utakmica u in utakmice)
                {
                    u.Domacin = VratiRepku(u.Domacin.ReprezentacijaId);
                    u.Gost = VratiRepku(u.Gost.ReprezentacijaId);
                }
                return utakmice;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "ovde");
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private Reprezentacija VratiRepku(int reprezentacijaId)
        {
            Reprezentacija r = new Reprezentacija { ReprezentacijaId = reprezentacijaId };
            try
            {
                command.CommandText = $"select * from Reprezentacija where ReprezentacijaID = {reprezentacijaId}";
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    r.Naziv = (string)reader[1];
                }
                reader.Close();
                return r;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                throw;
            }
        }

        
    }
}
