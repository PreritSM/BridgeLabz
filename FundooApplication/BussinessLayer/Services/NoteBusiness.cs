using System;
using System.Collections.Generic;
using System.Text;
using BussinessLayer.Interfaces;
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

        public List<NoteEntity> GetAllNotes(long UserID)
        {
            return note.GetAllNotes(UserID);
        }
    }
}
