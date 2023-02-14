using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Services
{
    public class CollabRespository
    {
        private readonly FundooDBContext context;
        private readonly IConfiguration configuration;

        public CollabRespository(FundooDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public CollabEntity AddCollab (string CollabEmail,long UserID,long NoteID)
        {
            CollabEntity collabEntity = new CollabEntity();
            collabEntity.CollabEmail = CollabEmail;
            collabEntity.UserID = UserID;
            collabEntity.NoteID = NoteID;

            if (collabEntity!= null)
            {
                context.CollabTable.Add(collabEntity);
                context.SaveChanges();
                return collabEntity;
            }
            else
            {
                return null;
            }

        }
    }
}
