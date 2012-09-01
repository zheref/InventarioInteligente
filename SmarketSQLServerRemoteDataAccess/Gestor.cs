using System;
using System.Data.SqlClient;
using System.Configuration;

namespace SmarketSQLServerRemoteDataAccess
{
    public abstract class Gestor
    {
        private const string DRIVE_LETTER = "G";

        private const string CONNECTION = @"Server=192.168.0.2\SQLEXPRESS;Database=SMARKET;User ID=zheref;Password=ALTAIRIS159847jeral;";

        internal static SqlConnection Connection = new SqlConnection();

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
                Console.WriteLine("Conexion abierta en SQL Server Remoto");
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