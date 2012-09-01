using System;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;
using System.Data;

namespace SmarketFirebirdDataAccess
{
    public abstract class Gestor
    {
        private const string DRIVE_LETTER = "G";
        private const string CONNECTION =   @"User ID=SYSDBA;Password=masterkey;"
                                          + @"Database=localhost:" + DRIVE_LETTER
                                          + @":\DATA\InventarioInteligente\SmarketFirebirdDataAccess\App_Data\FirebirdDB.fdb;"
                                          + @"DataSource=localhost;Charset=NONE;";
        
        internal static FbConnection Connection = new FbConnection();

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
                Console.WriteLine("Conexion abierta en Firebird");
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