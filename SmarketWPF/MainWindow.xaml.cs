using System.Windows;

namespace SmarketWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProveedorController proveedorControlador;

        public MainWindow()
        {
            InitializeComponent();
            this.proveedorControlador = new ProveedorController(grdContainer);
            grdContainer.MaxHeight = (this.Height - (stkHeader.ActualHeight  + grdFooter.ActualHeight)) - 30;
        }

        private void btnProveedores_Click(object sender, RoutedEventArgs e) 
        {
            proveedorControlador.StartIndexProveedor(); 
        }

        private void winMain_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            grdContainer.MaxHeight = (e.NewSize.Height - (stkHeader.ActualHeight + grdFooter.ActualHeight)) - 35;
        }
    }
}