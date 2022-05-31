using ExaComSigchaAlexis.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExaComSigchaAlexis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroEst : ContentPage
    {
        private SQLiteAsyncConnection con;
        public RegistroEst()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new Estudiante { NombreEst = txtNombre.Text, ApelidoEst=txtApellido.Text, CursoEst = txtCurso.Text, ParaleloEst = txtParalelo.Text, notaFinalEst = Convert.ToInt16(txtNota.Text)};
                con.InsertAsync(Registros);
                DisplayAlert("Alerta", "Dato ingresado", "ok");
                txtApellido.Text = "";
                txtCurso.Text = "";
                txtNombre.Text = "";
                txtNota.Text = "";
                txtParalelo.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "ok");
            }
        }

        private void btnVerDatos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DatosEstudiantes());
        }
    }
}