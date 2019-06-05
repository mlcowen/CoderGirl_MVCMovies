using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingEditViewModel
    {
        //public int Id { get; set; }
        public string MovieName { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }

        public static MovieRatingEditViewModel GetModel(int id)
        {
            Models.MovieRating movieRating = (Models.MovieRating)RepositoryFactory.GetMovieRatingRepository().GetById(id);
            return new MovieRatingEditViewModel
            {
                //Id = movieRating.Id,
                MovieName = movieRating.MovieName,
                MovieId = movieRating.MovieId,
                Rating = movieRating.Rating
            };
        }

        public void Persist(int id)
        {
            Models.MovieRating movieRating = new Models.MovieRating
            {
                Id = id,
                MovieName = this.MovieName,
                MovieId = this.MovieId,
                Rating = this.Rating
            };
            RepositoryFactory.GetMovieRatingRepository().Update(movieRating);
        }

    }
}




