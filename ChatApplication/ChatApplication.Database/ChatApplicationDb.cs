using ChatApplication.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApplication.Database
{
    public class ChatApplicationDb : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasIndex(a => a.Email).IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = DESKTOP-O1NBMET; 
                                    Initial Catalog = ChatApplication; 
                                    Integrated Security = true;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
