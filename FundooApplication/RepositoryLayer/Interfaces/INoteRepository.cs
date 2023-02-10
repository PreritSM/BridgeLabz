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
    }
}
