using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.Movies
{
    public class MovieEditViewModel
    {
        public static MovieEditViewModel GetModel(int id)
        {
            Movie movie = (Movie)RepositoryFactory.GetMovieRepository().GetById(id);
            return new MovieEditViewModel
            {
                Name = movie.Name,
                DirectorName = movie.DirectorName,
                Year = movie.Year,
                DirectorId = movie.DirectorId,
            };
        }

        public string Name { get; set; }
        public string DirectorName { get; set; }
        public int Year { get; set; }
        public int DirectorId { get; set; }

        public void Persist(int id)
        {
            Movie movie = new Movie
            {
                Id = id,
                Name = this.Name,
                DirectorName = this.DirectorName,
                Year = this.Year,
                DirectorId = this.DirectorId
            };
            RepositoryFactory.GetMovieRepository().Update(movie);
        }
    }
}

