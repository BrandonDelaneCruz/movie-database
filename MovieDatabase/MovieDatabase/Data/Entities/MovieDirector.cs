using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Data.Entities
{
    public class MovieDirector
    {
        public int Id { get; set; }
        public Movie? Movie { get; set; }
        public int MovieId { get; set; }
        public Director? Director { get; set; }
        public int DirectorId { get; set; }
    }
}
