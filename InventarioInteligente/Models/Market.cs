using System.Collections.Generic;

using SmarketModels;
//using SmarketSQLServerDataAccess;
using SmarketFirebirdDataAccess;

namespace InventarioInteligente.Models
{
    public class Market
    {
        public GestorProveedores Proveedores { get; set; }
        List<Inventario> inventarios;
        List<Producto> productos;
        List<Venta> ventas;
        List<Pedido> pedidos;
        List<Compra> compras;

        public Market()
        {
            this.Proveedores = new GestorProveedores();
            this.inventarios = new List<Inventario>();
            this.productos = new List<Producto>();
            this.ventas = new List<Venta>();
            this.pedidos = new List<Pedido>();
            this.compras = new List<Compra>();
        }
    }
}