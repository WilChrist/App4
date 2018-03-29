using App4.Model;
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
	public partial class ModifierFiliere : ContentPage
	{
        FiliereOperationImpl filireOpration;
        Filiere f1;
        public ModifierFiliere ()
		{
			InitializeComponent ();
            filireOpration = new FiliereOperationImpl(App.Connection);
            f1 = new Filiere();
        }

        //Enregistrer_Clicked
        public void Enregistrer_Clicked(object sender, EventArgs e)
        {
            f1.Id_fil = Convert.ToInt32(id.Text);
            f1.Nom_filiere = nom.Text;
            f1.Responsbale = resp.Text;
            f1.Date_creation = date.Date;
            var nbr = filireOpration.UpdateFiliere(f1);
            if (nbr > 0)
            {
                DisplayAlert("Great", "filiere correctement modifiée !", "OK");
            }
            else
            {
                DisplayAlert("Aïe Aïe Aïe", "filiere non modifiée !", "OK");
            }
        }
    }
}