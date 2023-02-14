using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Entity;

namespace BussinessLayer.Interfaces
{
    public interface ILabelBussiness
    {
        public LabelEntity AddLabel(long NoteId, long UserId, string Label);
        public List<LabelEntity> GetLabels();
        public string DeleteLabel(long LabelID, long NoteID, long UserID);
        public LabelEntity UpdateLabel(string labelDesc, long LabelId, long UserID);
    }
}
