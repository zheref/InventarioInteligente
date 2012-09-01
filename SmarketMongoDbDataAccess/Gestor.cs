using System;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace SmarketMongoDbDataAccess
{
    public abstract class Gestor
    {
        private const string DRIVE_LETTER = "G";
        private const string CONNECTION =   @"mongodb://" 
                                          + @"localhost/"
                                          + @"?safe=true";

        internal static MongoServer Connection;

        static string ConnectionString
        {
            get 
            {
                //string connection_stirng = ConfigurationManager.ConnectionStrings["SmarketSQLServerDataAccess.Properties.Settings.SQLServerDBConnectionString"].ConnectionString;
                return CONNECTION;
            }
        }

        static Gestor()
        {
            Gestor.Connect();
        }

        public static bool IsConnected()
        {
            return Gestor.Connection.State == MongoServerState.Connected;
        }

        public static void Connect()
        {
            try
            {
                Gestor.Connection = MongoServer.Create(Gestor.CONNECTION);
                Console.WriteLine("Conexion abierta en MongoDB");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}