using MovieDatabase.Data.Entities;
using MovieDatabase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Services
{
    public class ActorService
    {
        private DataContext _context;

        public ActorService(DataContext context)
        {
            _context = context;
        }

        public Actor AddActor(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return actor;
        }

        public Actor GetActorById(int id)
        {
            Actor actorToReturn =
                _context.Actors.First(x => x.Id == id);
            return actorToReturn;
        }

        public List<Actor> GetAllActors()
        {
            List<Actor> actors =
                _context.Actors.ToList();
            return actors;
        }

        public Actor UpdateActor(int id, Actor actor)
        {
            Actor actorsToUpdate =
                _context.Actors.First(x => x.Id == id);
            actorsToUpdate.FirstName = actor.FirstName;
            actorsToUpdate.LastName = actor.LastName;

            _context.SaveChanges();
            return actorsToUpdate;
        }

        public void DeleteActor(int id)
        {
            Actor actorToDelete
                = _context.Actors.First(x => x.Id == id);
            _context.Actors.Remove(actorToDelete);
            _context.SaveChanges();
        }
    }
}
