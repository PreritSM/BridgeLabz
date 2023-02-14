using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
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

        public List<NoteEntity> GetAllNotesByUserID(long UserID)
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

        public bool ArchiveOrNotArchived(long noteID, long UserID)
        {
            NoteEntity note = context.NoteTable.Where(e => e.NoteId == noteID).FirstOrDefault();
            if (note.IsArchived == false)
            {
                note.IsArchived = true;
                context.SaveChanges();
                return true;
            }
            else
            {
                note.IsArchived = false;
                context.SaveChanges();
                return false;
            }
        }

        public List<NoteEntity> GetAllNotes()
        {
            List<NoteEntity> notes = new List<NoteEntity>();
            foreach (var note in context.NoteTable)
            {
                notes.Add(note);
            }
            if (notes.Count > 0)
            {
                return notes;
            }
            else
            {
                return null;
            }
        }

        public string  UploadImage(long noteID, long UserID,IFormFile img)
        {
            NoteEntity note = context.NoteTable.Where(rec=> rec.NoteId== noteID && rec.UserId== UserID).FirstOrDefault();
            Cloudinary cloudinary = new Cloudinary(new Account(configuration["Cloudinary:Cloudname"],
                configuration["Cloudinary:ApiKey"], configuration["Cloudinary:ApiSecret"]));
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(img.FileName, img.OpenReadStream())
            };
            var result  = cloudinary.Upload(uploadParams);
            string imgPath = result.Url.ToString();
            note.Image = imgPath;
            context.SaveChanges();
            return imgPath;
        }

        public string DeletedNoteForever(long NoteID, long UserID)
        {
            NoteEntity note = context.NoteTable.FirstOrDefault(e => e.NoteId== NoteID && e.UserId ==UserID);
            if (note.IsTrash==false)
            {
                return null;
            }
            else
            {
                context.NoteTable.Remove(note);
                context.SaveChanges();
                return "Note Deleted";
            }
        }

        public string ChangeColor (long NoteID, long UserID, string color)
        {
            NoteEntity note = context.NoteTable.FirstOrDefault(e=> e.NoteId == NoteID && e.UserId == UserID);
            if (note.Colour != color)
            {
                note.Colour = color;
                context.SaveChanges();
                return $"Colour Changed to {color} successfully ";
            }
            else
            {
                return null;
            }
        }

        public string ReminderChange(long NoteID, long UserID,DateTime reminder)
        {
            NoteEntity note = context.NoteTable.FirstOrDefault(e => e.NoteId == NoteID && e.UserId == UserID);
            if (note.Reminder != reminder) {
                note.Reminder = reminder;
                context.SaveChanges();
                return "Reminder Changed to {reminder}";
            }
            else
            {
                return null;
            }
        }

    }
}
