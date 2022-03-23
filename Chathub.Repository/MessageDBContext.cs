using Chathub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chathub.Repository
{
    public class MessageDBContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public MessageDBContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseLazyLoadingProxies().UseInMemoryDatabase("message");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().HasData(new Message[]
            {
                new Message()
                {
                    MessageID = 1,
                    Username = "user_1",
                    Content = "I'm user_1",
                    Date = DateTime.Now
                }
            });
        }
    }
}
