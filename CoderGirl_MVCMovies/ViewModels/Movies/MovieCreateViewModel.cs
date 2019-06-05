using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieCreateViewModel
    {
        //public static MovieCreateViewModel GetMovieCreateViewModel()
        private static List<Director> GetDirectors()
        {
            //List<Director> directors = RepositoryFactory.GetDirectorRepository()
            return RepositoryFactory.GetDirectorRepository()
                .GetModels()
                .Cast<Director>()
                .ToList();
            //return new MovieCreateViewModel(directors);
        }

        //[Required(ErrorMessage = "Name must be included")]
        public string Name { get; set; }
        public int DirectorId { get; set; }
        public List<Director> Directors { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }
      

        //private MovieCreateViewModel(List<Director> directors)
        //{
        //    this.Directors = directors;
        //}
        public MovieCreateViewModel()
        {
            Directors = GetDirectors();
        }


        public void Persist()
        {
            Movie movie = new Movie
            {
                Name = this.Name,
                DirectorId = this.DirectorId,
                DirectorName = this.DirectorName,
                Year = this.Year
            };
            RepositoryFactory.GetMovieRepository().Save(movie);
        }
    }
}
