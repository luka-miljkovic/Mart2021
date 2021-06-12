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
            connection = new SqlConnection(@"");
            command = connection.CreateCommand();
        }

        Broker()
        {
            connect();
        }

        private static Broker Instance;

        static Broker GetInstance()
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
    }
}
