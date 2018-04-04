using App4.Model;
using ConsolePourSqlLite;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
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
        FiliereOperationImpl filiereOperation;
        Model.Image img;

        public EtudiantPage ()
		{
			InitializeComponent ();
            etudiantOperation = new EtudiantOperationImpl(App.Connection);
            filiereOperation = new FiliereOperationImpl(App.Connection);
            image.Source = ImageSource.FromFile(Height > Width ? "icon.png" : "Cute.jpg");
            img = new Model.Image();
            traitementImage();
            
        }

        public void EtudiantItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EtudiantPage());
        }
        public void FiliereItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FilierePage());
        }

        public void StatistiqeItem_Activeted(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Statistiques());
        }

        public void Enregistrer_Clicked(object sender, EventArgs e)
        {
            List<Filiere> filieres = new List<Filiere>
            {
                new Filiere(){Nom_filiere = "génie informatique" },
                new Filiere(){Nom_filiere = "génie industriel" },
                new Filiere(){Nom_filiere = "génie procedes" },
                new Filiere(){Nom_filiere = "génie telecome" }
            };
            foreach (var item in filieres)
            {
                filiereOperation.CreateFiliere(item);
            }

            List<Etudiant> etudiants = new List<Etudiant>
            {
                new Etudiant()
                {
                    Cne = 1,
                    Nom = "Nzesseu",
                    Prenom = "Willy",
                    Id_fil = 1
                },
                new Etudiant()
                {
                    Cne = 78,
                    Nom = "Alaa",
                    Prenom = "khouloud",
                    Id_fil = 1
                },
                new Etudiant()
                {
                    Cne = 121,
                    Nom = "herraz",
                    Prenom = "Imane",
                    Id_fil = 1
                },
                new Etudiant()
                {
                    Cne = 15,
                    Nom = "Asmaa",
                    Prenom = "bj",
                    Id_fil = 2
                },
                new Etudiant()
                {
                    Cne = 154,
                    Nom = "Ezzahraoui",
                    Prenom = "meriem",
                    Id_fil = 2
                }
            };
            foreach (var item in etudiants)
            {
                etudiantOperation.CreateEtudiant(item);
            }


           /* var numberOfRows= etudiantOperation.CreateEtudiant(etudiant);
                if (numberOfRows > 0)
                {
                    DisplayAlert("Great", "Etudiant correctement ajouté !", "OK");
                }
                else
                {
                    DisplayAlert("Aïe Aïe Aïe", "Etudiant non ajouté !", "OK");
                }
            //DisplayAlert("Great", etudiantOperation.ReadEtudiant(1).Prenom, "OK");
            /*for(int i=0; i < etudiantOperation.ReadEtudiants().Count; i++)
            {
                DisplayAlert("Great", etudiantOperation.ReadEtudiant(i).Prenom, "OK");
            }*/
            // DisplayAlert("Great", etudiantOperation.ReadEtudiants().Count.ToString(), "OK");
            //etudiantOperation.DeleteEtudiant(etudiantOperation.ReadEtudiants().Last());

            /*ImageOperationImpl imageOperation = new ImageOperationImpl(App.Connection);
            imageOperation.CreateImageFromPath("icon.png", "Image1");
            App4.Model.Image images = imageOperation.ReadImages().Last();

           // etudiantOperation.ReadEtudiants().Last().Image = image.Id;
            DisplayAlert(imageOperation.ReadImages().Count.ToString(),images.FileName, "Yes");
            string p="Cute.jpg";
            DisplayAlert("source", image.Source.ToString(), "ok");
            image.Source = imageOperation.ReadImageToPath(images, p);
            DisplayAlert("po", images.Content.ToString(), "ok");*/

            ImageOperationImpl imageOperation = new ImageOperationImpl(App.Connection);
            imageOperation.CreateImage(img); 

            App4.Model.Image images = imageOperation.ReadImages().Last();
            File.WriteAllBytes(images.Id.ToString() + "jpg", images.Content);
            image.Source = ImageSource.FromFile(images.Id.ToString() + "jpg");

           /* FileUtility fileUtility = new FileUtility();
            image.Source = "icon.png";
            string r=fileUtility.SaveFile("monimage", File.ReadAllBytes(image.Source.ToString()));
            image.Source = "p";
            image.Source = r;*/
        }

        public void traitementImage()
        {
            takePhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }
                try
                {
                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        SaveToAlbum = saveToGallery.IsToggled
                    });
                    if (file == null)
                        return;
                    await DisplayAlert("File Location", (saveToGallery.IsToggled ? file.AlbumPath :
                    file.Path), "OK");

                }
                catch //(Exception ex)
                {

                }
            };
            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                try
                {
                    Stream stream = null;
                    var file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);
                    if (file == null)
                        return;
                    stream = file.GetStream();
                    file.Dispose();
                    //image.Source = ImageSource.FromStream(() => stream);
                    System.Threading.Thread.Sleep(2000);
                    stream.Read(img.Content,0,Int32.MaxValue);
                    //img.Id = (int)DateTime.Now.ToBinary();
                }
                catch (Exception ex)
                {
                    // Xamarin.Insights.Report(ex);
                    // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured
                    await DisplayAlert("Photo Non enregistrée", ":( error."+ex.Message, "OK");
                }
            };
        }
    }
}