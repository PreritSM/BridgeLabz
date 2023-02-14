using System;
using System.Collections.Generic;
using System.Text;
using BussinessLayer.Interfaces;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace BussinessLayer.Services
{
    public class LabelBussiness: ILabelBussiness
    {
        private readonly ILabelRepository labelRepository;
        public LabelBussiness (ILabelRepository labelRepository)
        {
            this.labelRepository = labelRepository;
        }
    
        public LabelEntity AddLabel(long NoteId, long UserId, string Label)
        {
            return this.labelRepository.AddLabel(NoteId, UserId, Label);
        }

        public List<LabelEntity> GetLabels()
        {
            return this.labelRepository.GetLabels();
        }

        public string DeleteLabel(long LabelID, long NoteID, long UserID)
        {
            return this.labelRepository.DeleteLabel(LabelID, NoteID, UserID);
        }

        public LabelEntity UpdateLabel(string labelDesc, long LabelId, long UserID)
        {
            return this.labelRepository.UpdateLabel(labelDesc, LabelId, UserID);
        }

    }
}
