using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App4.Model
{
    class Filiere
    {
        Int32 id_fil;
        string nom_filiere;
        string responsbale;
        DateTime date_creation;


        [PrimaryKey, AutoIncrement]
        public int Id_fil { get => id_fil; set => id_fil = value; }


        public string Nom_filiere { get => nom_filiere; set => nom_filiere = value; }
        public string Responsbale { get => responsbale; set => responsbale = value; }
        public DateTime Date_creation { get => date_creation; set => date_creation = value; }
    }
}
