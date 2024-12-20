﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSPS.Models;
namespace SSPS.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Printer> printers { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<History> histories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // need when we use IdentityDbContext
            modelBuilder.Entity<Printer>().HasData(new Printer { Id = 1, Name = "Printer1", Model = "Model1", SerialNumber = "SerialNumber1", paperNumber = 100 });

            modelBuilder.Entity<History>()
            .HasOne(h => h.Printer)
            .WithMany()
            .HasForeignKey(h => h.PrinterID);

            modelBuilder.Entity<History>()
                .HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserID);
        }
    }
}


