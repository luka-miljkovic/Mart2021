using Domen;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
