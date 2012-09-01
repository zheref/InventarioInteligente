using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using SmarketModels;

namespace SmarketSQLServerRemoteDataAccess
{
	public class GestorProveedores : Gestor
	{
		List<Proveedor> proveedores;

		public GestorProveedores()
		{
			this.proveedores = new List<Proveedor>();
		}

		private void Connect()
		{
			if (!Gestor.IsConnected()) Gestor.Connect();
		}

		public List<Proveedor> ListarTodos()
		{
			string query = @"select * from PROVEEDOR;";
			Connect();
			SqlCommand command = new SqlCommand(query, Gestor.Connection);
			SqlDataReader reader = command.ExecuteReader();
			List<Proveedor> retrieval = new List<Proveedor>();
			Connect();
			if (reader.HasRows)
			{
				while (reader.Read())
				{
					Proveedor proveedor = new Proveedor
					{
						NIT = reader.GetString(0).Trim(),
						Nombre = reader.GetString(1),
						Foto = reader.GetString(2).Trim()
					};
					retrieval.Add(proveedor);
				}
			}
			else Console.WriteLine("No rows returned");
			reader.Close();
			return retrieval;
		}

		public Proveedor ListarPorNIT(string NIT)
		{
			string strquery = @"select * from PROVEEDOR where NIT like '%" + NIT + @"%';";
			Connect();
			SqlCommand cmd = new SqlCommand(strquery, Gestor.Connection);
			SqlDataReader reader = cmd.ExecuteReader();
			List<Proveedor> retrieval = new List<Proveedor>();
			if (reader.HasRows)
				while (reader.Read())
				{
					Proveedor proveedor = new Proveedor
					{
						NIT = reader.GetString(0),
						Nombre = reader.GetString(1),
						Foto = reader.GetString(2)
					};
					retrieval.Add(proveedor);
				}
			else
				Console.WriteLine("No rows returned.");
			reader.Close();
			return retrieval.Single();
		}

		public void AgregarProveedor(Proveedor proveedor)
		{
			string strquery = @"INSERT INTO PROVEEDOR
								(
									NIT,
									NOMBRE,
									FOTO
								)
								VALUES
								(
									'" + proveedor.NIT + @"',
									'" + proveedor.Nombre + @"',
									'" + proveedor.Foto + @"'
								);";
			Connect();
			SqlCommand cmd = new SqlCommand(strquery, Gestor.Connection);
			cmd.ExecuteScalar();
		}

		public void EliminarProveedor(Proveedor proveedor)
		{
			string strquery = @"delete from PROVEEDOR
								where NIT = " + proveedor.NIT + ";";
			Connect();
			SqlCommand cmd = new SqlCommand(strquery, Gestor.Connection);
			cmd.ExecuteScalar();
		}

		public void EliminarProveedorPorNIT(string NIT)
		{
			string strquery = @"delete from PROVEEDOR
								where NIT = " + NIT + ";";
			Connect();
			SqlCommand cmd = new SqlCommand(strquery, Gestor.Connection);
			cmd.ExecuteScalar();
		}

		public void ActualizarProveedor(string NIT, Proveedor proveedor)
		{
			string strquery = @"update PROVEEDOR
								set 
								NIT = '" + proveedor.NIT + @"',
								NOMBRE = '" + proveedor.Nombre + @"',
								FOTO = '" + proveedor.Foto + @"'
								where NIT = " + NIT + ";";
			Connect();
			SqlCommand cmd = new SqlCommand(strquery, Gestor.Connection);
			cmd.ExecuteScalar();
		}

        public void RollBack()
        {
            string strquery = @"rollback;";
            Connect();
            SqlCommand cmd = new SqlCommand(strquery, Gestor.Connection);
            cmd.ExecuteScalar();
        }
	}
}