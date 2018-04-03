using System;
using System.Collections.Generic;
using System.Text;

namespace GestionEtudiant.Model
{
    public class Etudiant
    {
        public String nom { get; set; }
        public String prenom { get; set; }
        public String cne { get; set; }
        public String image { get; set; }
        public DateTime date { get; set; }

        public List<Etudiant> GetEtudiants()
        {
            List<Etudiant> etudiants = new List<Etudiant>();
            etudiants.Add(new Etudiant { nom = "Douiab",prenom="Asmaa", cne="15252",image= "etudiant.png" });
            etudiants.Add(new Etudiant { nom = "Mays", prenom = "Hafssa", cne = "48551", image = "etudiant.png" });
            etudiants.Add(new Etudiant { nom = "Akif", prenom = "Rabha", cne = "18623", image = "etudiant.png" });
            return etudiants;
        }
    }
}
