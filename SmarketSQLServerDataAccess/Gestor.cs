using System;
using System.Data.SqlClient;
using System.Configuration;

namespace SmarketSQLServerDataAccess
{
    public abstract class Gestor
    {
        private const string DRIVE_LETTER = "G";
        private const string CONNECTION =   @"Data Source=.\SQLEXPRESS;" 
                                          + @"AttachDbFilename=" + DRIVE_LETTER 
                                          + @":\DATA\InventarioInteligente\SmarketSQLServerDataAccess\App_Data\SMARKET2.mdf;"
                                          + @"Integrated Security=True;User Instance=True";

        internal static SqlConnection Connection = new SqlConnection();

        static string ConnectionString
        {
            get 
            {
                //string connection_stirng = ConfigurationManager.ConnectionStrings["SmarketSQLServerDataAccess.Properties.Settings.SQLServerDBConnectionString"].ConnectionString;
                string connectionString = SmarketSQLServerDataAccess.Properties.Settings.Default.SQLServerDBConnectionString;
                return connectionString;
            }
        }

        static Gestor()
        {
            Connect();
        }

        public static bool IsConnected()
        {
            return Connection.State == System.Data.ConnectionState.Open;
        }

        public static void Connect()
        {
            Gestor.Connection.ConnectionString = Gestor.CONNECTION;
            try
            {
                Gestor.Connection.Open();
                Console.WriteLine("Conexion abierta en SQL Server");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            /*
            finally
            {
                connection.Close();
            }
            */
        }
    }
}