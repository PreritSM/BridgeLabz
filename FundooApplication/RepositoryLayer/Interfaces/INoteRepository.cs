using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRepository
    {
        public NoteEntity AddNote(NoteModel note, long UserID);
        public List<NoteEntity> GetAllNotes(long UserID);
        public string DeleteNote(long noteID);
        public NoteEntity UpdateNode(NoteModel note, long noteID);
        public bool PinOrUnpinNote(long noteID, long UserID);
    }
}
