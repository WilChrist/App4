using App4.Model;
using ConsolePourSqlLite;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace App4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Statistiques : ContentPage
    {
        /*List<Entry> entries = new List<Entry>
            {

               new Entry(212)
                 {
                     Label = "UWP",
                     ValueLabel = "212",
                     Color = SKColor.Parse("#2c3e50")
                 },
                 new Entry(248)
                 {
                     Label = "Android",
                     ValueLabel = "248",
                     Color = SKColor.Parse("#77d065")
                 },
                 new Entry(128)
                 {
                     Label = "iOS",
                     ValueLabel = "128",
                     Color = SKColor.Parse("#b455b6")
                 },
                 new Entry(514)
                 {
                     Label = "Shared",
                     ValueLabel = "514",
                     Color = SKColor.Parse("#3498db")
                 }

            };*/
        List<Microcharts.Entry> entries = new List<Entry>();
        EtudiantOperationImpl op;

        public Statistiques()
        {
            InitializeComponent();
          /*  op = new EtudiantOperationImpl(App.Connection);

            var etudiant = op.ReadEtudiants();

            foreach (var item in etudiant)
            {
                entries.Add(
                    new Entry((int)op.CountStudentPerFiliere("noun"))
                    {
                        Label = "item.Nom",
                        ValueLabel = op.CountStudentPerFiliere("noun").ToString(),
                        Color = SKColor.Parse("#3498db")
                    });
            }

            if (entries != null)
                chart.Chart = new BarChart { Entries = entries };*/
        }
    }
}