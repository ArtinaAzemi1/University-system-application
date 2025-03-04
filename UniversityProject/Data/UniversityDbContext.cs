using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Models;

namespace UniversityProject.Data
{
    public class UniversityDbContext : DbContext
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
    }
}
