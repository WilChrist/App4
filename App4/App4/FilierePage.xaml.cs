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
		public FilierePage ()
		{
			InitializeComponent ();
		}
        public void Onupdate(object sender, EventArgs e)
        {
            
        }

        public void OnDelete(object sender, EventArgs e)
        {

        }
        
         public void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AjouterFiliere());
        }



    }
}