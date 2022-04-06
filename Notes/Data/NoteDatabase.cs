using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Notes.Models;

namespace Notes.Data
{
    public class NoteDatabase
    {
        readonly SQLiteAsyncConnection database;

        public NoteDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Note>().Wait();
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            var c = await database.QueryAsync<Note>("select ID, Text, Date, Icon, ItemType from Note where ItemType = 'Collection'  ");
            return c;
            //Get all notes.
            //return database.Table<Note>()
            //    .Where(i => i.ItemType != "Wishlist")
            //    .ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Note>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }


        //Wishlist Functions
        public async Task<List<Note>> GetWishListNotesAsync()
        {
            var w = await database.QueryAsync<Note>("select ID, Text, Date, Icon, ItemType from Note where ItemType = 'Wishlist'  ");
            return w;
            //Get all notes.
            //return database.Table<Note>()
            //    .Where(i => i.ItemType == "Wishlist")
            //    .ToListAsync();
        }


    }
}