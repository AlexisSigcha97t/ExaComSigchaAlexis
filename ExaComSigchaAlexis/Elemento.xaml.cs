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
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<EstudiantesLogin> ResultadoDelete;
        IEnumerable<EstudiantesLogin> ResultadUpdate;

        public Elemento(int Id)
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = Id;
        }







        public static IEnumerable<EstudiantesLogin> Delete(SQLiteConnection db, int id)
        {
            return db.Query<EstudiantesLogin>("DELETE FROM EstudiantesLogin where Id = ?", id);
        }


        public static IEnumerable<EstudiantesLogin> Update(SQLiteConnection db,   string usuario, string clave, int id)
        {
            return db.Query<EstudiantesLogin>("UPDATE EstudiantesLogin SET Clave =?, Usuario=? where Id =?", clave, usuario, id);
        }

        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DBESTUDIANTES");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Update(db, Usuario.Text ,Contrasenia.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se actualizo correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }
        }

        private void btn_eliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DBESTUDIANTES");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se elimino correctamente", "ok");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }
        }
    }
}