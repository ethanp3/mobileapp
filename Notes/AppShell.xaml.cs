using Notes.Views;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Notes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("Register", typeof(Register));
            Routing.RegisterRoute("NotesPage", typeof(NotesPage));
            Routing.RegisterRoute("NoteEntryPage", typeof(NoteEntryPage));
            Routing.RegisterRoute("WishListEntryPage", typeof(WishListEntryPage));
        }
    }
}