using EntityFrameworkCore.DAL;
using EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFrameworkCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Prestamos prestamos = new Prestamos();
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = prestamos;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Context = new PrestamosContexto();
            var registro = Context.Prestamos.Find(prestamos.PrestamosId);
            if (registro != null)
            {
                prestamos = registro;
                this.DataContext = prestamos;
            }
            Context.Dispose();
        }
        public void Limpiar()
        {
            prestamos = new Prestamos();
            this.DataContext = prestamos;
        }
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private async void  GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            var ListaReg = GetPrestamos();

            if (await GuardarLista(ListaReg))
            {
                MessageBox.Show("Registro Guardados");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            var Context = new PrestamosContexto();
            Context.Prestamos.Remove(prestamos);
            Context.SaveChanges();
            Context.Dispose();
            Limpiar();
        }
        public List<Prestamos> GetPrestamos()
        {

            var prestamos1 = new Prestamos()
            {
                
                Nombres = "Enyer",
                Apellidos = "Holguin",
                Cedula = "1111",
                FechaNacimiento = DateTime.Now,
                
            };

            var Prestamos2 = new Prestamos()
            {
                
                Nombres = "Victoria",
                Apellidos = "Santo",
                Cedula = "1117881",
                FechaNacimiento = DateTime.Now,
            };

            var Prestamos3 = new Prestamos()
            {
                Nombres = "Juan",
                Apellidos = "Perez",
                Cedula = "4321",
                FechaNacimiento = DateTime.Now,
            };



            List<Prestamos> lista = new List<Prestamos>()
            {
                prestamos1,
                Prestamos2,
                Prestamos3,
                
               
            };

            return lista;
        }

        public async Task<bool> GuardarLista(List<Prestamos> personas)
        {
            bool ok = false;

            var Context = new PrestamosContexto();
            foreach (var item in personas)
            {
                Context.Prestamos.UpdateRange(item);
                ok = await Context.SaveChangesAsync() > 0;
            }
            await Context.DisposeAsync();
            return ok;
        }


    }
}
