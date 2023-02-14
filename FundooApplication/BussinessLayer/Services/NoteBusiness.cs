using System;
using System.Collections.Generic;
using System.Text;
using BussinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using ModelLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace BussinessLayer.Services
{
    public class NoteBusiness:INoteBusiness
    {
        private readonly INoteRepository note;
        public NoteBusiness(INoteRepository note)
        {
            this.note = note;
        }

        public NoteEntity AddNote(NoteModel noteModel,long UsertId)
        {
            return note.AddNote(noteModel,UsertId);
        }

        public List<NoteEntity> GetAllNotesByUserID(long UserID)
        {
            return note.GetAllNotesByUserID(UserID);
        }

        public string DeleteNote(long noteID)
        {
            return note.DeleteNote(noteID);
        }

        public NoteEntity UpdateNode(NoteModel notes, long noteID)
        {
            return note.UpdateNode(notes, noteID);
        }

        public bool PinOrUnpinNote(long noteID, long UserID)
        {
            return note.PinOrUnpinNote(noteID, UserID);
        }

        public bool ArchiveOrNotArchived(long noteID, long UserID)
        {
            return note.ArchiveOrNotArchived(noteID, UserID);
        }

        public List<NoteEntity> GetAllNotes()
        {
            return note.GetAllNotes();
        }

        public string UploadImage(long noteID, long UserID, IFormFile img)
        {
            return note.UploadImage(noteID, UserID, img);
        }
        public string DeletedNoteForever(long NoteID, long UserID)
        {
            return note.DeletedNoteForever(NoteID, UserID);
        }

        public string ChangeColor(long NoteID, long UserID, string color)
        {
            return note.ChangeColor(NoteID, UserID, color);
        }

        public string ReminderChange(long NoteID, long UserID, DateTime reminder)
        {
            return note.ReminderChange(NoteID, UserID, reminder);
        }
    }
}
