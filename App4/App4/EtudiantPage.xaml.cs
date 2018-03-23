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
		public EtudiantPage ()
		{
			InitializeComponent ();
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



            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DB_PATH1))
            {
                connection.CreateTable<Etudiant>();
                var numberOfRows= connection.Insert(etudiant);
                if (numberOfRows > 0)
                {
                    DisplayAlert("Success", "Etudiant correctement ajouté", "OK");
                }
                else
                {
                    DisplayAlert("Failure", "Etudiant non ajouté", "OK");
                }
            }

            //
        }

    }
}