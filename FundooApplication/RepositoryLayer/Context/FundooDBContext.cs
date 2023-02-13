using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;

namespace RepositoryLayer.Context
{
    public class FundooDBContext : DbContext
    {
        public FundooDBContext(DbContextOptions options): base (options) { }

        public DbSet<UserEntity> UserTable { get; set; }
        public DbSet<NoteEntity> NoteTable { get; set; }

        public DbSet<LabelEntity> LabelTable { get; set; }
    }
}
