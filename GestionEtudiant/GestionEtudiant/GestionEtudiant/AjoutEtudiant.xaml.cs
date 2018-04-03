using Plugin.Media;
using GestionEtudiant.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GestionEtudiant
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AjoutEtudiant : ContentPage
	{
        private object it;

        public AjoutEtudiant ()
		{
			InitializeComponent();
            traitementImage();

        }
        public async void AjouterEtudiant()
        {
            Etudiant etudiant = new Etudiant();
            etudiant.nom = nom.Text;
            etudiant.prenom = prenom.Text;
            etudiant.cne = cne.Text;
            etudiant.date = date.Date;
            etudiant.nom = nom.Text;
            etudiant.nom = nom.Text;
            etudiant.nom = nom.Text;
            await DisplayAlert("Success", "l'etudiant est ajoutée", "OK");
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
                    image.Source = ImageSource.FromStream(() => stream);
                }
                catch //(Exception ex)
                {
                    // Xamarin.Insights.Report(ex);
                    // await DisplayAlert("Uh oh", "Something went wrong, but don't worry we captured
                    await DisplayAlert("Photo Non enregistrée", ":( error.", "OK");
                }
            };
        }
    }
}