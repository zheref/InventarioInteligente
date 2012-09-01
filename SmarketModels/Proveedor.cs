using System.Collections.Generic;

namespace SmarketModels
{
    public class Proveedor
    {
        public string NIT { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }

        public List<Pedido> Pedidos { get; set; }
        public List<Compra> Compras { get; set; }

        public void AgregarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        public void EliminarPedido(Pedido pedido)
        {
            Pedidos.Remove(pedido);
        }

        
    }
}