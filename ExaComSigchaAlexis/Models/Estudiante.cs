using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExaComSigchaAlexis.Models
{
    public class Estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int IdEst { set; get; }
        [MaxLength(50)]
        public string NombreEst { get; set; }
        [MaxLength(25)]

        public string ApelidoEst { get; set; }
        [MaxLength(25)]
        public string CursoEst { get; set; }
        [MaxLength(25)]

        public string ParaleloEst { get; set; }
        [MaxLength(2)]

        public float notaFinalEst { get; set; }

    }
}
