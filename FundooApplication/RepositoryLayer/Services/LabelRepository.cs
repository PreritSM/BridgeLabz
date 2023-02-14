using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public  class LabelRepository: ILabelRepository
    {
        private readonly FundooDBContext context;
        private readonly IConfiguration configuration;

        public LabelRepository(FundooDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public LabelEntity AddLabel (long NoteId, long UserId, string Label)
        {
            LabelEntity label = new LabelEntity ();
            label.LabelName = Label;
            label.UserID= UserId;   
            label.NoteID= NoteId;
            context.LabelTable.Add (label);
            context.SaveChanges();
            return label;

        }

        public List<LabelEntity> GetLabels()
        {
            List<LabelEntity> labelEntities= new List<LabelEntity> ();
            foreach ( var label in context.LabelTable )
            {
                labelEntities.Add(label);
            }
            return labelEntities;
        }

        public string DeleteLabel(long LabelID,long NoteID,long UserID)
        {
            LabelEntity label = context.LabelTable.FirstOrDefault(e => e.LabelId == LabelID && e.UserID == UserID && e.NoteID == NoteID);
            if (label != null)
            {
                context.LabelTable.Remove(label);
                context.SaveChanges();
                return $"Label Deleted for NoteID {NoteID}";
            }
            else
            {
                return null;
            }
        }

        public LabelEntity UpdateLabel(string labelDesc, long LabelId, long UserID)
        {
            LabelEntity label = context.LabelTable.FirstOrDefault(e=> e.LabelId==LabelId && e.UserID == UserID );
            if (label != null)
            {
                label.LabelName = labelDesc;
                context.SaveChanges();
                return label;
            }
            else
            {
                return null;
            }
        }
    }
}
