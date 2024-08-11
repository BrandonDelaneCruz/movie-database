using MovieDatabase.Data;
using MovieDatabase.Data.Entities;
using MovieDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Menus
{
    public class DirectorMenu
    {
        private DataContext _context;
        
        public DirectorMenu(DataContext context)
        {
            _context = context;
        }

        public List<Director> UserAddDirector()
        {
            List<Director> directors = new List<Director>();

            bool userContinue = true;
            while (userContinue)
            {
                Director director = new Director();

                Console.Clear();
                Console.WriteLine("Please enter Director information.");
                Console.Write("First Name: ");
                director.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                director.LastName = Console.ReadLine();

                DirectorService directorService = new DirectorService(_context);

                var filterDirector = _context.Directors
                    .Where(x => x.FirstName == director.FirstName && x.LastName == director.LastName)
                    .ToList();
               
                if (filterDirector.Count == 1)
                {
                    directors.Add(filterDirector.First());
                }
                else
                {
                    var addedDirector = directorService.AddDirector(director);
                    directors.Add(addedDirector);
                }

                Console.Write("Input (M) to return to the Main Menu else input (A) to add another actor: ");
                string? userInput = Console.ReadLine();

                if (userInput == "M" || userInput == "m")
                {
                    userContinue = false;
                }
            }

            return directors;
        }

        public void UserDeleteDirector()
        {
            DirectorService directorService = new DirectorService(_context);
            var directorList = directorService.GetAllDirectors();

            Console.WriteLine("ID" +
                "\t\tFirst Name" +
                "\t\tLast name");

            foreach (var item in directorList)
            {
                Console.WriteLine($"{item.Id}" +
                    $"\t\t{item.FirstName}" +
                    $"\t\t{item.LastName}");
            }

            Console.WriteLine("Please Select the ID of the Director you would like to Delete: ");
            var directorIdToDelete = int.Parse(Console.ReadLine());

            directorService.DeleteDirector(directorIdToDelete);
        }

        public void UserUpdateDirector()
        {
            DirectorService directorService = new DirectorService( _context);
            Director director = new Director();
            var directorList = directorService.GetAllDirectors();

            Console.WriteLine("ID" +
                "\t\tFirst Name" +
                "\t\tLast name");

            foreach (var item in directorList)
            {
                Console.WriteLine($"{item.Id}" +
                    $"\t\t{item.FirstName}" +
                    $"\t\t{item.LastName}");
            }

            Console.WriteLine("Please Select the ID of the Director you would like to update: ");
            var directorIdToUpdate = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Please enter director information.");
            Console.Write("First Name: ");
            director.FirstName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Last Name: ");
            director.LastName = Console.ReadLine();

            directorService.AddDirector(director);
            directorService.UpdateDirector(directorIdToUpdate, director);
        }
    }
}
