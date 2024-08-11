using Microsoft.Identity.Client;
using MovieDatabase.Data;
using MovieDatabase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Services
{
    public class DirectorService
    {
        private DataContext _context;

        public DirectorService(DataContext context) 
        {
            _context = context;
        }

        public Director AddDirector(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();
            return director;
        }

        public Director GetDirectorById(int id)
        {
            Director directorToReturn =
                _context.Directors.First(x => x.Id == id);
            return directorToReturn;
        }

        public List<Director> GetAllDirectors()
        {
            List<Director> directors = 
                _context.Directors.ToList();
            return directors;
        }
        
        public Director UpdateDirector(int id, Director director)
        {
            Director directorToUpdate =
                _context.Directors.First(x => x.Id == id);
            
            directorToUpdate.FirstName = director.FirstName;
            directorToUpdate.LastName = director.LastName;

            _context.SaveChanges();
            return directorToUpdate;
        }

        public void DeleteDirector(int id)
        {
            Director directorToDelete =
                _context.Directors.First(x=>x.Id == id);
            _context.Directors.Remove(directorToDelete);
            _context.SaveChanges();
        }
    }
}
