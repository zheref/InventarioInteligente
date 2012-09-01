using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using SmarketModels;
using System.Collections.ObjectModel;

namespace SmarketWPF
{
	public class ProveedorIndexModel : GlobalViewModel, INotifyPropertyChanged
	{
        private ObservableCollection<ProveedorDetailsIndexModel> proveedores;

		public ProveedorIndexModel()
		{
            Reload();
		}

        public void Reload()
        {
            List<Proveedor> proveedores = App.Market.CargarListaProveedores();
            this.Proveedores = new ObservableCollection<ProveedorDetailsIndexModel>();
            foreach (Proveedor proveedor in proveedores)
            {
                Proveedores.Add(new ProveedorDetailsIndexModel(proveedor));
                RaisePropertyChanged("Proveedores");
            }
        }

        public ObservableCollection<ProveedorDetailsIndexModel> Proveedores
        {
            get 
            {
                return this.proveedores;
            }
            set
            {
                this.proveedores = value;
                RaisePropertyChanged("Proveedores");
            }
        }

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
		#endregion
	}
}