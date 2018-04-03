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
		public EtudiantPage ()
		{
			InitializeComponent ();
            etudiantOperation = new EtudiantOperationImpl(App.Connection);
            image.Source = ImageSource.FromFile(Height > Width ? "icon.png" : "Cute.jpg");
            traitementImage();
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


            
                var numberOfRows= etudiantOperation.CreateEtudiant(etudiant);
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

            FileUtility fileUtility = new FileUtility();
            image.Source = "icon.png";
            string r=fileUtility.SaveFile("monimage", File.ReadAllBytes(image.Source.ToString()));
            image.Source = "p";
            image.Source = r;
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
                    
                }
                catch //(Exception ex)
                {
                    
                }
            };
        }


    }
}