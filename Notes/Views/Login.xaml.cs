using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void login_Clicked(object sender, EventArgs e)
        {
            if (usernameText.Text == "admin" && passwordText.Text == "123")
            {
                await Shell.Current.GoToAsync($"//{nameof(NotesPage)}");
            }
            else
            {
                await DisplayAlert("Alert", "Invalid login credentials. Please try again", "OK");
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(Register)}");
        }
    }
}