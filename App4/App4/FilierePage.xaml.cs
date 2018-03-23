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
	public partial class FilierePage : ContentPage
	{
		public FilierePage ()
		{
			InitializeComponent ();
		}
        public void Enregistrer_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Success", "Event", "OK");
        }

    }
}