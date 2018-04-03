using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GestionEtudiant.Model;

namespace GestionEtudiant
{
	public partial class MainPage : ContentPage
	{
        List<string> listFiliere = new List<string>();
        listViewEtudiantsModel listEtudiantModel = new listViewEtudiantsModel();
        public MainPage()
		{
			InitializeComponent();
            listFiliere.Add("All");
            listFiliere.Add("Info");
            listFiliere.Add("GTR");
            listFiliere.Add("Indus");
            picker.ItemsSource = listFiliere;
            ListEtudiants.ItemsSource = listEtudiantModel.etudiants;
            BindingContext = listEtudiantModel;
            
        }
        public void FiliereChange(object sender, EventArgs e)
        {
            var filiereSelected = picker.SelectedItem as string;
            FiliereSelectionnée.Text = filiereSelected;
        }
        
        public void AjouterEtudiant(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjoutEtudiant());
            //new AjoutEtudiant();
        }
        public void OnUpdate(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            if (menuitem != null)
            {
                var etudiant = menuitem.BindingContext as Etudiant;
                Navigation.PushAsync(new AjoutEtudiant());
            }
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            if (menuitem != null)
            {
                var etudiant = menuitem.BindingContext as Etudiant;
                var answer = await DisplayAlert("Question?", "Voulez-vous vraiment supprimer l'etuidiant " + etudiant.nom, "Yes", "No");
                if (answer)
                {
                    await DisplayAlert("Success", etudiant.nom + " a été supprimée", "Ok");
                }
                else
                {
                    return;
                }
            }
        }



    }
}
