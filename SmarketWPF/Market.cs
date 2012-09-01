using System.Collections.Generic;
using System;
using SmarketModels;
using SmarketSQLServerDataAccess;
using SmarketFirebirdDataAccess;
using Microsoft.VisualBasic;
using System.Windows;

namespace SmarketWPF
{
    public class Market
    {
        public SmarketSQLServerDataAccess.GestorProveedores ProveedoresSQLServer { get; set; }
        public SmarketFirebirdDataAccess.GestorProveedores ProveedoresFirebird { get; set; }
        public SmarketMySQLDataAccess.GestorProveedores ProveedoresMySQL { get; set; }
        public SmarketSQLServerRemoteDataAccess.GestorProveedores ProveedoresSQLServerRemote { get; set; }
        List<Inventario> inventarios;
        List<Producto> productos;
        List<Venta> ventas;
        List<Pedido> pedidos;
        List<Compra> compras;

        public Market()
        {
            this.ProveedoresSQLServer = new SmarketSQLServerDataAccess.GestorProveedores();
            this.ProveedoresFirebird = new SmarketFirebirdDataAccess.GestorProveedores();
            this.ProveedoresMySQL = new SmarketMySQLDataAccess.GestorProveedores();
            this.ProveedoresSQLServerRemote = new SmarketSQLServerRemoteDataAccess.GestorProveedores();
            this.inventarios = new List<Inventario>();
            this.productos = new List<Producto>();
            this.ventas = new List<Venta>();
            this.pedidos = new List<Pedido>();
            this.compras = new List<Compra>();
        }

        public void RegistrarNuevoProveedor(Proveedor proveedor)
        {
            try
            {
                ProveedoresSQLServerRemote.AgregarProveedor(proveedor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                return;
            }
            try
            {
                ProveedoresMySQL.AgregarProveedor(proveedor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                return;
            }
            try
            {
                ProveedoresSQLServer.AgregarProveedor(proveedor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                ProveedoresMySQL.RollBack();
                return;
            }
            try
            {
                ProveedoresFirebird.AgregarProveedor(proveedor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                ProveedoresMySQL.RollBack();
                ProveedoresSQLServer.RollBack();
                return;
            }
        }

        public void ActualizarProveedor(string NIT, Proveedor proveedor)
        {
            try
            {
                ProveedoresSQLServerRemote.ActualizarProveedor(NIT, proveedor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                return;
            }
            try
            {
                ProveedoresMySQL.ActualizarProveedor(NIT, proveedor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                return;
            }
            try
            {
                ProveedoresSQLServer.ActualizarProveedor(NIT, proveedor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                ProveedoresMySQL.RollBack();
                return;
            }
            try
            {
                ProveedoresFirebird.ActualizarProveedor(NIT, proveedor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                ProveedoresMySQL.RollBack();
                ProveedoresSQLServer.RollBack();
                return;
            }
        }

        public void EliminarProveedor(string NIT)
        {
            try
            {
                ProveedoresSQLServerRemote.EliminarProveedorPorNIT(NIT);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                return;
            }
            try
            {
                ProveedoresMySQL.EliminarProveedorPorNIT(NIT);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                return;
            }
            try
            {
                ProveedoresSQLServer.EliminarProveedorPorNIT(NIT);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                ProveedoresMySQL.RollBack();
                return;
            }
            try
            {
                ProveedoresFirebird.EliminarProveedorPorNIT(NIT);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show("No se puede realizar la transaccion");
                ProveedoresSQLServerRemote.RollBack();
                ProveedoresMySQL.RollBack();
                ProveedoresSQLServer.RollBack();
                return;
            }
        }

        public List<Proveedor> CargarListaProveedores()
        {
            try
            {
                return ProveedoresSQLServerRemote.ListarTodos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                return ProveedoresMySQL.ListarTodos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                return ProveedoresSQLServer.ListarTodos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            try
            {
                return ProveedoresFirebird.ListarTodos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            MessageBox.Show("No se pudo realizar la transaccion. No hay ninguna fuente de datos disponible");
            return new List<Proveedor>();
        }
        
    }
}