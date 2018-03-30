using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App4.Model;
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
            
		}

        public LoginPage(String path)
        {
            InitializeComponent();
            outil = new UserOperation(new SQLite.SQLiteConnection(path));
           
        }

        UserOperation outil;
        
         void Handle_Clicked(object sender, System.EventArgs e)
        {
            String email = emailField.Text;
            String password = passwordField.Text;

            User s = null;
             s = outil.FindUserByEmailAndPassword(email, password);
            if (s==null)
            {
                DisplayAlert("ERREUR", "email ou mot de passe incorrecte", "ok");
            }
            else
            {
                App.Current.MainPage = new NavigationPage(new MainPage());
            }


        }
    }
}