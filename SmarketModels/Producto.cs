using System;

namespace SmarketModels
{
    public class Producto
    {
        public string CodigoDeBarras { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public DateTime Caducidad { get; set; }

        public Proveedor Proveedor { get; set; }
    }
}