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
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            //this.BackgroundImage = "C:\\Users\\FRANCIS YEMETIO\\Desktop\\App4\\App4\\App4.Android\\Resources\\drawable\\background_1.jpg";
		}

         void Handle_Clicked(object sender, System.EventArgs e)
        {
            String email = emailField.Text;
            String password = passwordField.Text;

            if (email.Equals("fr") && password.Equals("fr"))
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                DisplayAlert("Erreur", "email ou mot de passe invalide", "ok");
            }



        }
    }
}