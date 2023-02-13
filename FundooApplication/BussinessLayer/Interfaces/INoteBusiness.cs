using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer;
using RepositoryLayer.Entity;

namespace BussinessLayer.Interfaces
{
    public interface INoteBusiness
    {
        public NoteEntity AddNote(NoteModel noteModel, long UsertId);
        public List<NoteEntity> GetAllNotes(long UserID);
        public string DeleteNote(long noteID);
        public NoteEntity UpdateNode(NoteModel note, long noteID);
        public bool PinOrUnpinNote(long noteID, long UserID);
    }
}
