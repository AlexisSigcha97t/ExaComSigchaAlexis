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
    public partial class DatosEstudiantes : ContentPage
    {

        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;

        public DatosEstudiantes()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            consulta1();
        }

        public async void consulta1()
        {
            var registros1 = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(registros1);
            ListaEstudiante.ItemsSource = tablaEstudiante;
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
    }
}