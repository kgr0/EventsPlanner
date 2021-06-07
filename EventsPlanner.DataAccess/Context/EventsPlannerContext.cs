using EventsPlanner.DataAccess.Repositories.Interfaces;
using EventsPlanner.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPlanner.DataAccess.Context
{
    public class EventsPlannerContext :DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        public EventsPlannerContext(DbContextOptions<EventsPlannerContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name)
                        .HasMaxLength(30);
                b.Property(x => x.Email)
                        .HasMaxLength(30);
            });
            modelBuilder.Entity<Meeting>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name)
                       .HasMaxLength(30);
                b.Property(x => x.Description)
                       .HasMaxLength(100);
                b.HasMany(x => x.Users)
                        .WithMany(x => x.Meetings)
                        .UsingEntity(x => x.ToTable("UsersMeetings"));
            });
           
        }

    }
}
