using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using UniversityProject.Models;

namespace UniversityProject.Data
{
    public class UniversityDbContext : IdentityDbContext<IdentityUser>
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Semester> Semester { get; set; }

        public DbSet<Hall> Hall { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
