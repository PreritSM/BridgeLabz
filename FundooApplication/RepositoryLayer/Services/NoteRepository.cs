using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class NoteRepository : INoteRepository
    {
        private readonly FundooDBContext context;
        private readonly IConfiguration configuration;

        public NoteRepository(FundooDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public NoteEntity AddNote(NoteModel note, long UserID)
        {
            NoteEntity noteEntity = new NoteEntity(); ;
            noteEntity.Title = note.Title;
            noteEntity.Description = note.Description;
            noteEntity.Colour = note.Colour;
            noteEntity.Image = note.Image;
            noteEntity.Reminder = note.Reminder;
            noteEntity.ModifiedAt = DateTime.Now;
            noteEntity.IsArchived = note.IsArchived;
            noteEntity.IsPinned = note.IsPinned;
            noteEntity.IsTrash = note.IsTrash;
            noteEntity.CreatedAt = DateTime.Now;
            noteEntity.UserId = UserID;
            context.NoteTable.Add(noteEntity);
            context.SaveChanges();
            return noteEntity;
        }

        public List<NoteEntity> GetAllNotes(long UserID)
        {
            var NotesList = this.context.NoteTable.Where(a => a.UserId == UserID).ToList(); 
            return NotesList;
        }

        public string DeleteNote(long noteID)
        {
            var delete = context.NoteTable.FirstOrDefault(a => a.NoteId == noteID);
            if (delete != null)
            {
                context.NoteTable.Remove(delete);
                context.SaveChanges();
                return "Deleted Succesfully";
            }
            else
            {
                return null;
            }
        }
        public NoteEntity UpdateNode(NoteModel note, long noteID)
        {
            var notes = context.NoteTable.Where(a => a.NoteId == noteID).FirstOrDefault();
            if (note != null)
            {
                notes.Title = note.Title;
                notes.Description = note.Description;
                notes.Colour = note.Colour;
                notes.Image = note.Image;
                notes.Reminder = note.Reminder;
                notes.ModifiedAt = DateTime.Now;
                notes.CreatedAt = DateTime.Now;
                notes.IsArchived = note.IsArchived;
                notes.IsPinned = note.IsPinned;
                notes.IsTrash = note.IsTrash; context.SaveChanges(); return notes;
            }
            else
            {
                return null;
            }
        }

        public bool PinOrUnpinNote (long noteID, long UserID)
        {
            NoteEntity note = context.NoteTable.Where(e => e.NoteId == noteID).FirstOrDefault();
            if (note.IsPinned == false)
            {
                note.IsPinned = true;
                context.SaveChanges(); 
                return true;
            }
            else
            {
                note.IsPinned=false;
                context.SaveChanges();
                return false;
            }
        }
    }
}
