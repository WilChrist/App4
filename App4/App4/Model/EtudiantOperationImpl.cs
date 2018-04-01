using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePourSqlLite
{
    class EtudiantOperationImpl : IEtudiantOperation
    {
        SQLite.SQLiteConnection database;
        public object CountStudentPerFiliere(string nom)
        {
            var query = database.Query<Etudiant>("SELECT distinct count(*) FROM Etudiant GROUP BY id_fil having nom_filiere = ?",nom);
            return query;
        }

        public EtudiantOperationImpl()
        {
            throw new NotImplementedException();
        }
        public EtudiantOperationImpl(SQLite.SQLiteConnection database)
        {
            this.database = database;
        }
        public int CreateEtudiant(Etudiant etudiant)
        {
                //database.CreateTable<Etudiant>();
            
            return database.Insert(etudiant);
        }
        public Etudiant ReadEtudiant(int cne)
        {
            //database.CreateTable<Etudiant>();
            return (Etudiant)database.Find<Etudiant>(cne);
        }
        public List<Etudiant> ReadEtudiants()
        {
            return database.Table<Etudiant>().ToList();
        }
        
        public void DeleteEtudiant(Etudiant etudiant)
        {
            database.Delete(etudiant);
        }

        public void UpdateEtudiant(Etudiant etudiant)
        {
            throw new NotImplementedException();
        }
    }
}
