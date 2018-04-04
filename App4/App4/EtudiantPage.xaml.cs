using ConsolePourSqlLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static List<string> listFiliere = new List<string>();
        public static ObservableCollection<Etudiant> listEtudiantModel;

        public EtudiantPage ()
		{
			InitializeComponent ();
            etudiantOperation = new EtudiantOperationImpl(App.Connection);
            listEtudiantModel = new ObservableCollection<Etudiant>(etudiantOperation.ReadEtudiants());
            listFiliere.Add("All");
            listFiliere.Add("Info");
            listFiliere.Add("GTR");
            listFiliere.Add("Indus");
            picker.ItemsSource = listFiliere;
            Etudiant test = new Etudiant();
            test.Nom = "Douiab";
            test.Prenom = "Asmaa";
            test.Cne = 15124524;
            test.Image = "icon.png";
            test.Adresse = "Jnane Clonne 2 Safi";
            //test.Date_naissance = Convert.ToDateTime("01/02/1996");
            test.Sexe = "Femme";
            test.Telephone = "+21265058090";
            listEtudiantModel.Add(test);
            ListEtudiants.ItemsSource = listEtudiantModel;
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
                Navigation.PushAsync(new ModifierEtudiant(etudiant));
            }
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            if (menuitem != null)
            {
                var etudiant = menuitem.BindingContext as Etudiant;
                var answer = await DisplayAlert("Question?", "Voulez-vous vraiment supprimer l'etuidiant " + etudiant.Nom, "Yes", "No");
                if (answer)
                {
                    listEtudiantModel.Remove(etudiant);
                    await DisplayAlert("Success", etudiant.Nom + " a été supprimée", "Ok");
                }
                else
                {
                    return;
                }
            }
        }
        public void More(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            if (menuitem != null)
            {
                var etudiant = menuitem.BindingContext as Etudiant;
                Navigation.PushAsync(new EtudiantProfil(etudiant));
            }
        }
        

    }
}