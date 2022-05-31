using ExaComSigchaAlexis.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExaComSigchaAlexis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;


        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }


        public static IEnumerable<EstudiantesLogin> SELECT_WHERE(SQLiteConnection db,  string usuario, string clave)
        {
            return db.Query<EstudiantesLogin>("SELECT * FROM EstudiantesLogin where usuario = ? and clave = ?", usuario, clave);
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "DBESTUDIANTES");
                var db = new SQLiteConnection(documentPath);
                db.CreateTable<EstudiantesLogin>();
                IEnumerable<EstudiantesLogin> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasenia.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario no existe, por favor registrarse", "ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "Usuario no existe", "ok");
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}