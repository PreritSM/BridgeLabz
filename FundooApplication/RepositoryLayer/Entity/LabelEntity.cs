using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace RepositoryLayer.Entity
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }
        public string LabelName { get; set; }

        [ForeignKey("User")]
        public long UserID { get; set; }

        [ForeignKey("Notes")]
        public long NoteID { get; set; }

        [JsonIgnore]
        public virtual UserEntity User { get; set; }
        [JsonIgnore]
        public virtual NoteEntity Notes { get; set;}
    }
}
