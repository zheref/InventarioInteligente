using System;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace SmarketMySQLDataAccess
{
    public abstract class Gestor
    {
        private const string CONNECTION =   @"Server=127.0.0.1;" 
                                          + @"Port=3306;"
                                          + @"Database=smarket;"
                                          + @"Uid=zheref;Pwd=ALTAIRIS159847jeral";

        internal static MySqlConnection Connection = new MySqlConnection();

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
                Console.WriteLine("Conexion abierta en SQL Server Local");
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