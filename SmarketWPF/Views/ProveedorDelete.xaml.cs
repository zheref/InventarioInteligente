using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SmarketModels;

namespace SmarketWPF
{
	/// <summary>
	/// Lógica de interacción para ProveedorDelete.xaml
	/// </summary>
	public partial class ProveedorDelete : UserControl
	{
         ProveedorDeleteModel model;

        public event Action ConfirmCommand;
        public event Action BackCommand;

		public ProveedorDelete()
		{
            model = new ProveedorDeleteModel();
            base.DataContext = model;
            this.InitializeComponent();
		}

        public Proveedor Proveedor
        {
            set
            {
                model.Proveedor = value;
            }
        }

		private void btnConfirm_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            model.Delete();
            if (ConfirmCommand != null)
                ConfirmCommand();
		}

		private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            BackCommand();
		}
	}
}