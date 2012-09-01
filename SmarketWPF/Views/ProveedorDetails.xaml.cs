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
	/// Lógica de interacción para ProveedorDetails.xaml
	/// </summary>
	public partial class ProveedorDetails : UserControl
	{
        ProveedorDetailsModel model;

        public event Action BackCommand;
        public event Action<IProveedorDetails> DeleteCommand;
        public event Action<IProveedorDetails> EditCommand;

		public ProveedorDetails()
		{
            model = new ProveedorDetailsModel();
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

		private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            BackCommand();
		}

		private void btnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            EditCommand(model);
		}

		private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            DeleteCommand(model);
		}
	}
}