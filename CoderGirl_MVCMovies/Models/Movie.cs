using CoderGirl_MVCMovies.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.Models
{
    public class Movie
    {
        private IDirectorRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public int Id { set; get; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<int> Ratings { get; set; }
        public int DirectorId { get; set; }

        public Director Director
        {
            get { return directorRepository.GetById(DirectorId); }
        }

        public string AverageRating
        {
            get { return Ratings.Average().ToString(); }
        }

        public string NumberOfRatings
        {
            get { return Ratings.Count.ToString(); }
        }
    }

    
}
