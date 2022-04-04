using System;
using System.IO;
using System.Threading.Tasks;
using NativeMedia;
using Notes.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace Notes.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class NoteEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public NoteEntryPage()
        {
            InitializeComponent();

            // Set the BindingContext of the page to a new Note.
            BindingContext = new Note();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                Note note = await App.Database.GetNoteAsync(id);
                BindingContext = note;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        private async void BtnCam_Clicked(object sender, EventArgs e)
        {
            try
            {

                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
                {
                    DefaultCamera = Plugin.Media.Abstractions.CameraDevice.Rear,
                    Directory = "Xamarin",
                    SaveToAlbum = true
                });

                if (photo != null)
                    imgCam.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        private async void OnPickImagesClick(object sender, EventArgs args)
        {
            var result = await MediaGallery.PickAsync(1, MediaFileType.Image);

            if (result?.Files == null)
            {
                return;
            }

            foreach (var media in result.Files)
            {
                var fileName = media.NameWithoutExtension;
                var extension = media.Extension;

                await DisplayAlert(fileName, $"Extension: {extension}", "OK");


            }
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;

            if (!string.IsNullOrWhiteSpace(note.Text))
            {
                await App.Database.SaveNoteAsync(note);
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");

        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}

