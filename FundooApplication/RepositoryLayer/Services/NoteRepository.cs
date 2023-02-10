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
    }
}
