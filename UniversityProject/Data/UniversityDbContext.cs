using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UniversityProject.Models;

namespace UniversityProject.Data
{
    public class UniversityDbContext : IdentityDbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Grade> Grade { get; set; }

        public DbSet<Location> Location { get; set; }

        public DbSet<Hall> Hall { get; set; }

        public DbSet<Professor> Professor { get; set; }
        public DbSet<Student> Student { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Group> Groups { get; set; }
    }
}
