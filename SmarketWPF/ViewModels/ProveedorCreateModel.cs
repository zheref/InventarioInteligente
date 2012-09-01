using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using SmarketModels;

namespace SmarketWPF
{
    public class ProveedorCreateModel : INotifyPropertyChanged
    {
        private string nombre;
        private string nit;
        private string foto;

        public ProveedorCreateModel()
        {
            this.nombre = this.nit = this.foto = string.Empty;
        }

        public Proveedor Proveedor
        {
            get
            {
                return new Proveedor()
                {
                    Nombre = this.nombre,
                    NIT = this.nit,
                    Foto = this.foto
                };
            }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set 
            {
                this.nombre = value;
                RaisePropertyChanged("Nombre");
            }
        }
        
        public string NIT
        {
            get { return this.nit; }
            set 
            { 
                this.nit = value;
                RaisePropertyChanged("NIT");
            }
        }
        
        public string Foto
        {
            get { return this.foto; }
            set 
            { 
                this.foto = value;
                RaisePropertyChanged("Foto");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Save()
        {
            App.Market.RegistrarNuevoProveedor(this.Proveedor);
        }
    }
}