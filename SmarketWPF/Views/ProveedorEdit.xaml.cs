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
	/// Lógica de interacción para ProveedorEdit.xaml
	/// </summary>
	public partial class ProveedorEdit : UserControl
	{
        ProveedorEditModel model;

        public event Action SaveCommand;
        public event Action BackCommand;

		public ProveedorEdit()
		{
            model = new ProveedorEditModel();
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

        private void btnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            model.Save();
            if (SaveCommand != null)
                SaveCommand();
        }

        private void btnBack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            BackCommand();
        }
	}
}