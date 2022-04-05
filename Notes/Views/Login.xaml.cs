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

        private void login_Clicked(object sender, EventArgs e)
        {
            if (usernameText.Text == "admin" && passwordText.Text == "123")
            {
                Navigation.PushAsync(new NotesPage());
            }
            else
            {
                DisplayAlert("Alert", "Invalid login credentials. Please try again", "OK");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }
    }
}