using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace ModelLayer
{
    public class NoteModel
    {
        public long NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Colour { get; set; }
        public string Image { get; set; }
        public DateTime Reminder { get; set; }
        public bool IsArchived { get; set; }
        public bool IsPinned { get; set; }
        public bool IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
         public long UserId { get; set; }
      
    }
}
