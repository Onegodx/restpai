using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;

namespace Lab3.Data
{
    public class ModelDB : Microsoft.EntityFrameworkCore.DbContext
    {
        public ModelDB(DbContextOptions<ModelDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public Microsoft.EntityFrameworkCore.DbSet<Tariff> Tariffs { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<CallRecord> CallRecords { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModuleBuilder modelBuilder)
        {
        }
    }
}