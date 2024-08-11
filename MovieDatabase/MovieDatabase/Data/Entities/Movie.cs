using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;   
        public DateOnly DateReleased { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<MovieDirector>? MovieDirectors { get; set; }
        public List<MovieActor>? MovieActors { get; set; }
    }
}
