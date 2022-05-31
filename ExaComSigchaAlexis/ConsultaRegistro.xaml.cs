using ExaComSigchaAlexis.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExaComSigchaAlexis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<EstudiantesLogin> tablaEstudiantesLogin;
        private ObservableCollection<Estudiante> tablaEstudiante;

        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            consulta();
        }

        public async void consulta()
        {
            var registros = await con.Table<EstudiantesLogin>().ToListAsync();
            tablaEstudiantesLogin = new ObservableCollection<EstudiantesLogin>(registros);
            ListaUsuario.ItemsSource = tablaEstudiantesLogin;
        }

        public async void consulta1()
        {
            var registros1 = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(registros1);
            ListaEstudiante.ItemsSource = tablaEstudiante;
        }

        private void ListaUsuario_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (EstudiantesLogin)e.SelectedItem;
            var item = Obj.Id.ToString();
            int Id = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(Id));
            }
            catch (Exception ex)
            {

            }
        }

        private void ListaUsuario_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (EstudiantesLogin)e.SelectedItem;
            var item = Obj.Id.ToString();
            int Id = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(Id));
            }
            catch (Exception ex)
            {

            }
        }

        private void bntAgregarEst_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroEst());
        }

        private void ListaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.IdEst.ToString();
            int IdEst = Convert.ToInt32(item);
            try
            {
                Navigation.PushAsync(new Elemento(IdEst));
            }
            catch (Exception ex)
            {

            }
        }

        private void bntInformacion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegistroEst());
        }
    }
}