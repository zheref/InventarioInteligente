using System;

namespace SmarketModels
{
    public class Inventario
    {
        public Inventario(int codigo) : this(codigo, DateTime.Now) { }

        public Inventario(int codigo, DateTime fecha)
        {
            this.Codigo = codigo;
            this.Fecha = fecha;
        }

        public int Codigo { get; private set; }
        public DateTime Fecha { get; private set; }
        
    }
}