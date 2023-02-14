using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Entity;
using RepositoryLayer.Interfaces;

namespace BussinessLayer.Services
{
    public class CollabBussiness
    {
        private readonly ICollabRepository collabRepository;

        public CollabBussiness (ICollabRepository collabRepository)
        {
            this.collabRepository = collabRepository;
        }

        public CollabEntity AddCollab(string CollabEmail, long UserID, long NoteID)
        {
            return this.collabRepository.AddCollab(CollabEmail, UserID, NoteID);
        }
    }
}
