﻿using Notes.Views;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Notes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute("notespage", typeof(NotesPage));
            Routing.RegisterRoute(nameof(NoteEntryPage), typeof(NoteEntryPage));
        }
    }
}