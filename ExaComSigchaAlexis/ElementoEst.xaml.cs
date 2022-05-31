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
    public partial class ElementoEst : ContentPage
    {

        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Estudiante> ResultadoDelete;
        IEnumerable<Estudiante> ResultadUpdate;
        public ElementoEst(int IdEst)
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            IdSeleccionado = IdEst;
        }



        public static IEnumerable<Estudiante> Delete(SQLiteConnection db, int idEst)
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where IdEst = ?", idEst);
        }


        public static IEnumerable<Estudiante> Update(SQLiteConnection db, string notaEst, string paraleloEst, string cursoEst, string apellidoEst, string nombreEst, int idEst)
        {
            return db.Query<Estudiante>("UPDATE Estudiante SET  notaFinalEst=?, ParaleloEst =?, CursoEst=? , ApellidoEst =?, NombreEst=? where IdEst =?", notaEst, paraleloEst, cursoEst, apellidoEst, nombreEst, idEst);
        }



        private void btn_actualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "DBESTUDIANTES");
                var db = new SQLiteConnection(databasePath);
                ResultadoDelete = Update(db, txtNotaFinal.Text, txtParalelo.Text, txtCurso.Text, txtApellido.Text, txtNombre.Text, IdSeleccionado);
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