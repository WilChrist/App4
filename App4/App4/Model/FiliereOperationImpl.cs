using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace App4.Model
{
    class FiliereOperationImpl : IFiliereOperation
    {
        SQLite.SQLiteConnection database;
        public FiliereOperationImpl(SQLite.SQLiteConnection database)
        {
            this.database = database;
        }
        public int CreateFiliere(Filiere filiere)
        {
            return database.Insert(filiere);
        }

        public void DeleteFiliere(Filiere filiere)
        {
            database.Delete(filiere);
        }

        public List<Filiere> ReadFilieres()
        {
            return database.Table<Filiere>().ToList();
        }

        public void UpdateFiliere(Filiere filiere)
        {
            database.Update(filiere);
        }
    }
}
