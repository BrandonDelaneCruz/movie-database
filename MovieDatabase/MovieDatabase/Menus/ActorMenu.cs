using Microsoft.EntityFrameworkCore;
using MovieDatabase.Data;
using MovieDatabase.Data.Entities;
using MovieDatabase.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Menus
{
    public class ActorMenu
    {
        private DataContext _context;

        public ActorMenu(DataContext context)
        {
            _context = context;
        }

        public List<Actor> UserAddActor()
        {
            List<Actor> actors = new List<Actor>();

            bool userContinue = true;
            while (userContinue)
            {
                Actor actor = new Actor();

                Console.Clear();
                Console.WriteLine("Please enter Actor information.");
                Console.Write("First Name: ");
                actor.FirstName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Last Name: ");
                actor.LastName = Console.ReadLine();


                ActorService actorService = new ActorService(_context);

                var filterActor = _context.Actors
                .Where(x => x.FirstName == actor.FirstName && x.LastName == actor.LastName)
                .ToList();

                if (filterActor.Count == 1)
                {
                    actors.Add(filterActor.First());
                }
                else
                {
                    var addedActor = actorService.AddActor(actor);
                    actors.Add(addedActor);
                }

                Console.Write("Input (M) to return to the Main Menu else input (A) to add another actor: ");
                string? userInput = Console.ReadLine();

                if (userInput == "M" || userInput == "m")
                {
                    userContinue = false;
                }
            }

            return actors;
        }

        public void UserDeleteActor()
        {
            ActorService actorService = new ActorService(_context);
            var actorList = actorService.GetAllActors();

            Console.WriteLine("ID" +
                "\t\tFirst Name" +
                "\t\tLast name");

            foreach (Actor actor in actorList) 
            {
                Console.WriteLine($"{actor.Id}" +
                    $"\t\t{actor.FirstName}" +
                    $"\t\t{actor.LastName}");
            }

            Console.WriteLine("Please Select the ID of the Actor you would like to Delete: ");
            var actorIdToDelete = int.Parse(Console.ReadLine());

            actorService.DeleteActor(actorIdToDelete);
        }

        public void UserUpdateActor()
        {
            ActorService actorService = new ActorService( _context);
            Actor actor = new Actor();
            var actorList = actorService.GetAllActors();

            Console.WriteLine("ID" +
                "\t\tFirst Name" +
                "\t\tLast name");

            foreach (var item in actorList)
            {
                Console.WriteLine($"{item.Id}" +
                    $"\t\t{item.FirstName}" +
                    $"\t\t{item.LastName}");
            }

            Console.WriteLine("Please Select the ID of the Actor you would like to update: ");
            var actorIdToUpdate = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Please enter Actor information.");
            Console.Write("First Name: ");
            actor.FirstName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Last Name: ");
            actor.LastName = Console.ReadLine();

            actorService.AddActor(actor);
            actorService.UpdateActor(actorIdToUpdate, actor);
        }
    }
}
