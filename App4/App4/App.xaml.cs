using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App4
{
	public partial class App : Application
	{
        static string DB_PATH;

        public static string DB_PATH1 { get => DB_PATH; set => DB_PATH = value; }


        public App ()
		{
			InitializeComponent();

			MainPage = new LoginPage();
		}
        public App(string DB_path)
        {
            InitializeComponent();
            DB_PATH = DB_path;
             MainPage = new LoginPage();
            
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
