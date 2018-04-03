using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEtudiant.Model
{
    public class listViewEtudiantsModel
    {
        public List<Etudiant> etudiants { get; set; }
        public listViewEtudiantsModel()
        {
            etudiants = new Etudiant().GetEtudiants();
        }
    }
}
