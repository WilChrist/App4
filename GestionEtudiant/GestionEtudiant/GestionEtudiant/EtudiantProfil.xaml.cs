using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEtudiant.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionEtudiant
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EtudiantProfil : ContentPage
	{
        Etudiant etudiant=new Etudiant();
		
        public EtudiantProfil(Etudiant e)
        {
            etudiant = e;
            InitializeComponent();
            nom.Text = etudiant.nom;
            prenom.Text = etudiant.prenom;
            date.Date= etudiant.date;          

        }
        
    }
}