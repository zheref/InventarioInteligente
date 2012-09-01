using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using SmarketModels;

namespace SmarketWPF
{
    public class ProveedorController
    {
        private readonly string PANTALLA_PROVEEDORES_HASH = "proveedores_screen";
        private readonly string PANTALLA_INSERTAR_PROVEEDORES_HASH = "insertar_proveedores_screen";
        private readonly string PANTALLA_ACTUALIZAR_PROVEEDORES_HASH = "actualizar_proveedores_screen";
        private readonly string PANTALLA_ELIMINAR_PROVEEDORES_HASH = "eliminar_proveedores_screen";
        private readonly string PANTALLA_DETALLES_PROVEEDORES_HASH = "detalles_proveedores_screen";

        Panel target;
        Dictionary<string, UserControl> screens;

        public ProveedorController(Panel control)
        {
            this.screens = new Dictionary<string, UserControl>();
            this.target = control;
        }

        internal void StartIndexProveedor()
        {
            if (screens.ContainsKey(PANTALLA_PROVEEDORES_HASH))
            {
                target.Children.Clear();
                (screens[PANTALLA_PROVEEDORES_HASH] as ProveedorIndex).Refresh();
                target.Children.Add(screens[PANTALLA_PROVEEDORES_HASH]);
            }
            else
            {
                ProveedorIndex screen = new ProveedorIndex();
                screen.CreateCommand += new Action(StartCreateProveedor);
                screen.DeleteCommand += new Action<IProveedorDetails>(StartDeleteProveedor);
                screen.EditCommand += new Action<IProveedorDetails>(StartEditProveedor);
                screen.DetailsCommand += new Action<IProveedorDetails>(StartDetailsProveedor);
                screen.GenerateCommand += new Action(StartGeneration);
                screens.Add(PANTALLA_PROVEEDORES_HASH, screen);
                target.Children.Clear();
                target.Children.Add(screen);
            }
        }

        private void StartGeneration()
        {
            DateTime inicio = DateTime.Now;
            Random ran = new Random();
            for (int i = 0; i < 5000; i++)
            {
                Proveedor proveedor = new Proveedor
                {
                    NIT = ran.Next(100000000, 999999999).ToString(),
                    Nombre = "Ran " + i,
                    Foto = "Fot " + i
                };
                Console.WriteLine("Se intentara guardar el registro " + i);
                App.Market.RegistrarNuevoProveedor(proveedor);
                Console.WriteLine("Se guardo el registro " + i);
            }
            long total = (DateTime.Now.Ticks - inicio.Ticks) / 1000;
            Console.WriteLine("El tiempo total de la transaccion fue " + total);
        }

        private void StartCreateProveedor()
        {
            if (screens.ContainsKey(PANTALLA_INSERTAR_PROVEEDORES_HASH))
            {
                target.Children.Clear();
                target.Children.Add(screens[PANTALLA_INSERTAR_PROVEEDORES_HASH]);
            }
            else
            {
                ProveedorCreate screen = new ProveedorCreate();
                screen.SaveCommand += new Action(EndCreateProveedor);
                screen.BackCommand += new Action(BackFromCreateProveedor);
                screens.Add(PANTALLA_INSERTAR_PROVEEDORES_HASH, screen);
                target.Children.Clear();
                target.Children.Add(screen);
            }
        }

        private void EndCreateProveedor()
        {
            screens.Remove(PANTALLA_INSERTAR_PROVEEDORES_HASH);
            StartIndexProveedor();
        }

        private void BackFromCreateProveedor()
        {
            screens.Remove(PANTALLA_INSERTAR_PROVEEDORES_HASH);
            StartIndexProveedor();
        }

        private void StartDeleteProveedor(IProveedorDetails arg)
        {
            if (screens.ContainsKey(PANTALLA_ELIMINAR_PROVEEDORES_HASH))
            {
                target.Children.Clear();
                target.Children.Add(screens[PANTALLA_ELIMINAR_PROVEEDORES_HASH]);
            }
            else
            {
                ProveedorDelete screen = new ProveedorDelete();
                screen.Proveedor = new Proveedor
                {
                    Nombre = arg.Nombre,
                    NIT = arg.NIT,
                    Foto = arg.Foto
                };
                screen.ConfirmCommand += new Action(EndDeleteProveedor);
                screen.BackCommand += new Action(BackFromDeleteProveedor);
                screens.Add(PANTALLA_ELIMINAR_PROVEEDORES_HASH, screen);
                target.Children.Clear();
                target.Children.Add(screen);
            }
        }

        private void EndDeleteProveedor()
        {
            screens.Remove(PANTALLA_ELIMINAR_PROVEEDORES_HASH);
            StartIndexProveedor();
        }

        private void BackFromDeleteProveedor()
        {
            screens.Remove(PANTALLA_ELIMINAR_PROVEEDORES_HASH);
            StartIndexProveedor();
        }

        private void StartEditProveedor(IProveedorDetails arg)
        {
            if (screens.ContainsKey(PANTALLA_ACTUALIZAR_PROVEEDORES_HASH))
            {
                target.Children.Clear();
                target.Children.Add(screens[PANTALLA_ACTUALIZAR_PROVEEDORES_HASH]);
            }
            else
            {
                ProveedorEdit screen = new ProveedorEdit();
                screen.Proveedor = new Proveedor
                {
                    Nombre = arg.Nombre,
                    NIT = arg.NIT,
                    Foto = arg.Foto
                };
                screen.SaveCommand += new Action(EndEditProveedor);
                screen.BackCommand += new Action(BackFromEditProveedor);
                screens.Add(PANTALLA_ACTUALIZAR_PROVEEDORES_HASH, screen);
                target.Children.Clear();
                target.Children.Add(screen);
            }
        }

        private void EndEditProveedor()
        {
            screens.Remove(PANTALLA_ACTUALIZAR_PROVEEDORES_HASH);
            StartIndexProveedor();
        }

        private void BackFromEditProveedor()
        {
            screens.Remove(PANTALLA_ACTUALIZAR_PROVEEDORES_HASH);
            StartIndexProveedor();
        }

        private void StartDetailsProveedor(IProveedorDetails arg)
        {
            if (screens.ContainsKey(PANTALLA_DETALLES_PROVEEDORES_HASH))
            {
                target.Children.Clear();
                target.Children.Add(screens[PANTALLA_DETALLES_PROVEEDORES_HASH]);
            }
            else
            {
                ProveedorDetails screen = new ProveedorDetails();
                screen.Proveedor = new Proveedor
                {
                    Nombre = arg.Nombre,
                    NIT = arg.NIT,
                    Foto = arg.Foto
                };
                screen.BackCommand += new Action(BackFromDetailsProveedor);
                screen.EditCommand += new Action<IProveedorDetails>(StartEditProveedor);
                screen.DeleteCommand += new Action<IProveedorDetails>(StartDeleteProveedor);
                screens.Add(PANTALLA_DETALLES_PROVEEDORES_HASH, screen);
                target.Children.Clear();
                target.Children.Add(screen);
            }
        }

        private void BackFromDetailsProveedor()
        {
            screens.Remove(PANTALLA_DETALLES_PROVEEDORES_HASH);
            StartIndexProveedor();
        }
    }
}
