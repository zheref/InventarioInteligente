using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using SmarketModels;

namespace SmarketWPF
{
    public class ProveedorDetailsIndexModel : GlobalViewModel, IProveedorDetails
    {
        // Campos
        private string nit;
        private string nombre;
        private string foto;

        // Constructores
        public ProveedorDetailsIndexModel(Proveedor proveedor)
        {
            this.NIT = proveedor.NIT;
            this.Nombre = proveedor.Nombre;
            this.foto = proveedor.Foto;
        }

        // Propiedades
        public string NIT
        {
            get { return this.nit; }
            set 
            { 
                this.nit = value;
            }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set 
            { 
                this.nombre = value;
            }
        }
        public string Foto
        {
            get { return GlobalViewModel.ImagesPath + this.foto; }
            set 
            { 
                this.foto = value;
            }
        }
    }
}