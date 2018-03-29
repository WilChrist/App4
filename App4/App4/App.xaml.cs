using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsolePourSqlLite;
using SQLite;
using Xamarin.Forms;

namespace App4
{
	public partial class App : Application
	{
        static string DB_PATH;
        static SQLite.SQLiteConnection connection;
        public static string DB_PATH1 { get => DB_PATH; set => DB_PATH = value; }
        public static SQLiteConnection Connection { get => connection; set => connection = value; }


        public App ()
		{
			InitializeComponent();

			MainPage = new LoginPage();
		}
        public App(string DB_path)
        {
            InitializeComponent();
            DB_PATH = DB_path;
<<<<<<< HEAD
            connection = new SQLite.SQLiteConnection(DB_PATH);
            connection.CreateTable<Etudiant>();
            MainPage = new NavigationPage(new MainPage());
=======
             MainPage = new LoginPage();
            
>>>>>>> FrancisKholoud
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
