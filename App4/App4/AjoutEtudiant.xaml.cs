﻿
using ConsolePourSqlLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Plugin.Media;

namespace App4
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AjoutEtudiant : ContentPage
	{
        
        public AjoutEtudiant ()
		{
			InitializeComponent ();
            traitementImage();
            picker.ItemsSource = EtudiantPage.listFiliere;
        }
        public async void AjouterEtudiant()
        {
            Etudiant etudiant = new Etudiant();
            etudiant.Nom = nom.Text;
            etudiant.Prenom = prenom.Text;
            etudiant.Cne = Convert.ToInt32(cne.Text);
            etudiant.Date_naissance = date.Date;
            etudiant.Adresse = adresse.Text;
            etudiant.Telephone = tel.Text;
            etudiant.Sexe = sexe.Text;
            EtudiantPage.listEtudiantModel.Add(etudiant);
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