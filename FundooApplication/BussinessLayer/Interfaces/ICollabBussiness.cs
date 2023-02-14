using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Entity;

namespace BussinessLayer.Interfaces
{
    public interface ICollabBussiness
    {
        public CollabEntity AddCollab(string CollabEmail, long UserID, long NoteID);
    }
}
