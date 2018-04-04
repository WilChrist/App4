using System;
using ConsolePourSqlLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EtudiantProfil : ContentPage
	{
        Etudiant etudiant;
        public EtudiantProfil(Etudiant e)
		{
			InitializeComponent ();
            etudiant = e;
            nom.Text = etudiant.Nom;
            prenom.Text = etudiant.Prenom;
            adresse.Text = etudiant.Adresse;
            tel.Text = etudiant.Telephone;
            sexe.Text = etudiant.Sexe;
            date.Date = etudiant.Date_naissance;
            image.Source = "icon.png";
           
        }
	}
}