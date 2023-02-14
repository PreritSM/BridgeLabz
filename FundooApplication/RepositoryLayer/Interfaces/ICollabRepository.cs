using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Interfaces
{
    public interface ICollabRepository
    {
        public CollabEntity AddCollab(string CollabEmail, long UserID, long NoteID);
    }
}
