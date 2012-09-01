using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using SmarketModels;

namespace SmarketWPF
{
    public class ProveedorDeleteModel : INotifyPropertyChanged
    {
        private string nombre;
        private string nit;
        private string foto;

        public ProveedorDeleteModel()
        {
            this.Nombre = this.Foto = this.NIT = string.Empty;
        }

        public Proveedor Proveedor
        {
            get
            {
                return new Proveedor()
                {
                    Nombre = this.Nombre,
                    NIT = this.NIT,
                    Foto = this.Foto
                };
            }
            set
            {
                this.Nombre = value.Nombre;
                this.Foto = value.Foto;
                this.NIT = value.NIT;
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
            get
            {
                string r = this.foto;
                return r;
            }
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

        public void Delete()
        {
            App.Market.EliminarProveedor(this.NIT);
        }
    }
}
