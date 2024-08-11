using MovieDatabase.Data;
using MovieDatabase.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Services
{
    public class MovieService
    {
        private DataContext _context;

        public MovieService(DataContext context)
        {
            _context = context;
        }

        public Movie AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        public Movie GetMovieById (int id)
        {
            Movie movieToReturn =
                _context.Movies.First(x => x.Id == id);
            return movieToReturn;
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = 
                _context.Movies.ToList();
            return movies;
        }

        public Movie UpdateMovie(int id, Movie movie)
        {
            Movie movieToUpdate = 
                _context.Movies.First(x => x.Id == id);
            movieToUpdate.Title = movie.Title;
            movieToUpdate.Description = movie.Description;
            movieToUpdate.DateReleased = movie.DateReleased;
            
            _context.SaveChanges();
            return movieToUpdate;
        }

        public void DeleteMovie(int id)
        {
            Movie movieToDelete 
                = _context.Movies.First(x => x.Id == id);
            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();
        }
    }
}
