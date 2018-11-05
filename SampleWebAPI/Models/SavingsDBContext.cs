using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SampleWebAPI.Models
{
    public class SavingsDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SavingsDBContext() : base("name=SavingsDB")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Database.CreateIfNotExists();
            
        }

        public DbSet<SavingsType> SavingsTypes { get; set; }
        public DbSet<SavingsDetails> SavingsDetails { get; set; }

        public DbSet<UserModel> UserModels { get; set; }

        //added to prevent ef to append s in entityobjects
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SavingsType>().ToTable("SavingsType");
            modelBuilder.Entity<UserModel>().ToTable("Users");
        }
    }
}
