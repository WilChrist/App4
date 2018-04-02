using App4.Model;
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
	public partial class FilierePage : ContentPage
	{
        ObservableCollection<Model.Filiere> list;
        FiliereOperationImpl filireOpration;
        
        public FilierePage ()
		{
			InitializeComponent ();
            filireOpration = new FiliereOperationImpl(App.Connection);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            list = new ObservableCollection<Model.Filiere>(filireOpration.ReadFilieres());
            filiereListView.ItemsSource = list;
        }
            public void Onupdate(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            var filiere = menuitem.BindingContext as Filiere;
            if (menuitem != null)
            {
                Navigation.PushAsync(new ModifierFiliere(filiere));
            }
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var menuitem = sender as MenuItem;
            if (menuitem != null)
            {
                var filiere = menuitem.BindingContext as Filiere;
                var answer = await DisplayAlert("Question?", "Voulez-vous Vraiment supprimer la filiere " + filiere.Nom_filiere, "Yes", "No");
                if (answer)
                {
                    filireOpration.DeleteFiliere(filiere);
                    list.Remove(filiere);
                    DisplayAlert("Success", filiere.Nom_filiere +" a été supprimée avec succe", "Ok");
                }
                else
                {
                    return;
                }
            }
        }
        
         public void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjouterFiliere());
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {  

            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                filiereListView.ItemsSource = list;
            }

            else
            {
                filiereListView.ItemsSource = list.Where(x => x.Nom_filiere.StartsWith(e.NewTextValue));
            }
        }



    }
}