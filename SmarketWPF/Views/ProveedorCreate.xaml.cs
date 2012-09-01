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

namespace SmarketWPF
{
	/// <summary>
	/// Lógica de interacción para ProveedorCreate.xaml
	/// </summary>
	public partial class ProveedorCreate : UserControl
	{
        ProveedorCreateModel model;

        public event Action SaveCommand;
        public event Action BackCommand;

		public ProveedorCreate()
		{
            model = new ProveedorCreateModel();
            base.DataContext = model;
			this.InitializeComponent();
		}

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
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