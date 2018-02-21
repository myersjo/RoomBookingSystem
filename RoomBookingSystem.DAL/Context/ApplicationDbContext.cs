using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RoomBookingSystem.Business.Entities;

namespace RoomBookingSystem.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<RoomEquipment> RoomEquipment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().ToTable("Locations");
            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<Booking>().ToTable("Bookings");
            modelBuilder.Entity<Equipment>().ToTable("Equipment");
            modelBuilder.Entity<RoomEquipment>().ToTable("RoomEquipment");

            modelBuilder.Entity<RoomEquipment>().HasKey(x => new {x.RoomId, x.EquipmentId});
        }

    }
}
