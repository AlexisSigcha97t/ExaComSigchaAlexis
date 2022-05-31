using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExaComSigchaAlexis.Models;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExaComSigchaAlexis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void bntAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new EstudiantesLogin { usuario = txtUsuario.Text, Clave = txtContrasenia.Text };
                con.InsertAsync(Registros);
                DisplayAlert("Alerta", "Dato ingresado", "ok");
                txtContrasenia.Text = "";
                txtUsuario.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }
    }
}