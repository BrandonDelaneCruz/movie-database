using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MovieDatabase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Data
{
    public class DataContext : DbContext
    {
        // DbSets<> go here!
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Do not change this value. It reads the assembly and sets the name to the project name.
                var myDatabaseName = typeof(Program).Assembly.GetName().Name;
                optionsBuilder.UseSqlServer($"Server=localhost;Database={myDatabaseName};Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            }
        }
    }
}
