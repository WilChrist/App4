using App4.Model;
using ConsolePourSqlLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EtudiantPage : ContentPage
	{
        EtudiantOperationImpl etudiantOperation;
        FiliereOperationImpl filiereOperation;
		public EtudiantPage ()
		{
			InitializeComponent ();
            etudiantOperation = new EtudiantOperationImpl(App.Connection);
            filiereOperation = new FiliereOperationImpl(App.Connection);
        }

        public void EtudiantItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EtudiantPage());
        }
        public void FiliereItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FilierePage());
        }

        public void StatistiqeItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Statistiques());
        }

        public void Enregistrer_Clicked(object sender, EventArgs e)
        {
            List<Filiere> filieres = new List<Filiere>
            {
                new Filiere(){Nom_filiere = "génie informatique" },
                new Filiere(){Nom_filiere = "génie industriel" },
                new Filiere(){Nom_filiere = "génie procedes" },
                new Filiere(){Nom_filiere = "génie telecome" }
            };
            foreach (var item in filieres)
            {
                filiereOperation.CreateFiliere(item);
            }

            List<Etudiant> etudiants = new List<Etudiant>
            {
                new Etudiant()
                {
                    Cne = 1,
                    Nom = "Nzesseu",
                    Prenom = "Willy",
                    Id_fil = 1
                },
                new Etudiant()
                {
                    Cne = 78,
                    Nom = "Alaa",
                    Prenom = "khouloud",
                    Id_fil = 1
                },
                new Etudiant()
                {
                    Cne = 121,
                    Nom = "herraz",
                    Prenom = "Imane",
                    Id_fil = 1
                },
                new Etudiant()
                {
                    Cne = 15,
                    Nom = "Asmaa",
                    Prenom = "bj",
                    Id_fil = 2
                },
                new Etudiant()
                {
                    Cne = 154,
                    Nom = "Ezzahraoui",
                    Prenom = "meriem",
                    Id_fil = 2
                }
            };
            foreach (var item in etudiants)
            {
                etudiantOperation.CreateEtudiant(item);
            }


           /* var numberOfRows= etudiantOperation.CreateEtudiant(etudiant);
                if (numberOfRows > 0)
                {
                    DisplayAlert("Great", "Etudiant correctement ajouté !", "OK");
                }
                else
                {
                    DisplayAlert("Aïe Aïe Aïe", "Etudiant non ajouté !", "OK");
                }
            DisplayAlert("Great", etudiantOperation.ReadEtudiant(1).Prenom, "OK");
            /*for(int i=0; i < etudiantOperation.ReadEtudiants().Count; i++)
            {
                DisplayAlert("Great", etudiantOperation.ReadEtudiant(i).Prenom, "OK");
            }
            DisplayAlert("Great", etudiantOperation.ReadEtudiants().Count.ToString(), "OK");
            etudiantOperation.DeleteEtudiant(etudiantOperation.ReadEtudiants().Last());*/

        }

    }
}