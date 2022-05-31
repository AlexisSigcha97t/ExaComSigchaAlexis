using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExaComSigchaAlexis.Models
{
    public class EstudiantesLogin
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }

        public string usuario { set; get; }
        [MaxLength(50)]

        public string Clave { get; set; }

    }
}
