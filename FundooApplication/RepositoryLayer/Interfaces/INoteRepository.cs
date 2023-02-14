using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using ModelLayer;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interfaces
{
    public interface INoteRepository
    {
        public NoteEntity AddNote(NoteModel note, long UserID);
        public List<NoteEntity> GetAllNotesByUserID(long UserID);
        public string DeleteNote(long noteID);
        public NoteEntity UpdateNode(NoteModel note, long noteID);
        public bool PinOrUnpinNote(long noteID, long UserID);
        public bool ArchiveOrNotArchived(long noteID, long UserID);
        public List<NoteEntity> GetAllNotes();
        public string UploadImage(long noteID, long UserID, IFormFile img);
        public string DeletedNoteForever(long NoteID, long UserID);
        public string ChangeColor(long NoteID, long UserID, string color);
        public string ReminderChange(long NoteID, long UserID, DateTime reminder);
    }
}
