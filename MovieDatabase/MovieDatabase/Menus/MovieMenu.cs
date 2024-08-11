using MovieDatabase.Data;
using MovieDatabase.Data.Entities;
using MovieDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieDatabase.Menus
{
    public class MovieMenu
    {
        private DataContext _context;

        public MovieMenu(DataContext context) 
        {
            _context = context;
        }

        public void UserAddMovie()
        {
            Movie movie = new Movie();
            MovieService movieService = new MovieService(_context);
            ActorMenu actorMenu = new ActorMenu(_context);
            DirectorMenu directorMenu = new DirectorMenu(_context);

            Console.Clear();
            Console.WriteLine("Please enter Movie information");
            Console.Write("Title: ");
            movie.Title = Console.ReadLine();
            Console.Write("Date Released (mm/dd/yyyy): ");
            movie.DateReleased = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Description:");
            movie.Description = Console.ReadLine();
                
            var movieToTable = movieService.AddMovie(movie);
            var directorToTable = directorMenu.UserAddDirector();
            var actorToTable = actorMenu.UserAddActor();

            foreach(var item in directorToTable)
            {
                _context.MovieDirectors.Add(new MovieDirector
                {
                    Movie = movieToTable,
                    MovieId = movieToTable.Id,
                    Director = item,
                    DirectorId = item.Id
                });
            }
                
            foreach(var item in actorToTable)
            {
                _context.MovieActors.Add(new MovieActor
                {
                    Movie = movieToTable,
                    MovieId = movieToTable.Id,
                    Actor = item,
                    ActorId = item.Id
                });
            }

            _context.SaveChanges();
        }
    }
}
