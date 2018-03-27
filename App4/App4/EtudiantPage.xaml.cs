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
		public EtudiantPage ()
		{
			InitializeComponent ();
            etudiantOperation = new EtudiantOperationImpl(App.Connection);
        }
        public void Enregistrer_Clicked(object sender, EventArgs e)
        {
            //Etudiant etudiant = new Etudiant(1, "Nzesseu", "Willy", "Wad El-Basha", "0635348819", "myBeautifulFace.jpg", 'M', DateTime.Now);
            Etudiant etudiant = new Etudiant()
            {
                Cne =1,
                Nom="Nzesseu",
                Prenom="Willy"
            };



            
                var numberOfRows= etudiantOperation.CreateEtudiant(etudiant);
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
            }*/
            DisplayAlert("Great", etudiantOperation.ReadEtudiants().Count.ToString(), "OK");
            etudiantOperation.DeleteEtudiant(etudiantOperation.ReadEtudiants().Last());
            
        }

    }
}