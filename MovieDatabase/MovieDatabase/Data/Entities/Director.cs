using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Data.Entities
{
    public class Director
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;       
        public string LastName { get; set; } = string.Empty;
        public List<MovieDirector>? MovieDirectors { get; set; }
    }
}
