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
using System.Windows.Shapes;

using SmarketModels;
using System.Collections.ObjectModel;

namespace SmarketWPF
{
	/// <summary>
	/// Lógica de interacción para ProveedorIndex.xaml
	/// </summary>
	public partial class ProveedorIndex : UserControl
	{
        public event Action CreateCommand;
        public event Action<IProveedorDetails> DeleteCommand;
        public event Action<IProveedorDetails> EditCommand;
        public event Action<IProveedorDetails> DetailsCommand;
        public event Action GenerateCommand;

        ProveedorIndexModel Model = new ProveedorIndexModel();

		public ProveedorIndex()
		{
            this.InitializeComponent();
            base.DataContext = this.Model;
		}

        public void Refresh()
        {
            this.Model.Reload();
        }

        private void btnCreate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateCommand();
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DeleteCommand(dgrProveedores.SelectedItem as ProveedorDetailsIndexModel);
        }

        private void btnEdit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EditCommand(dgrProveedores.SelectedItem as ProveedorDetailsIndexModel);
        }

        private void dgrProveedores_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dgrProveedores.SelectedItem != null)
            {
                btnDelete.Visibility = System.Windows.Visibility.Visible;
                btnEdit.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                btnDelete.Visibility = System.Windows.Visibility.Hidden;
                btnEdit.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void dgrProveedores_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (dgrProveedores.SelectedItem != null)
                DetailsCommand(dgrProveedores.SelectedItem as ProveedorDetailsIndexModel);
        }

        private void btnGenerate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            GenerateCommand();
        }
	}
}