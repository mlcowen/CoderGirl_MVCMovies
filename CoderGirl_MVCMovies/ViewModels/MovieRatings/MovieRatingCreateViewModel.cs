using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingCreateViewModel
    {
        //public int Id { get; set; }
        public string MovieName { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }

        public static MovieRatingCreateViewModel GetMovieRatingCreateViewModel(int movieId)
        {
            MovieRatingCreateViewModel viewModel = new MovieRatingCreateViewModel();

            var movie = (Models.Movie)RepositoryFactory.GetMovieRepository().GetById(movieId);
            string movieName = movie.Name;
            viewModel.MovieName = movieName;
            viewModel.MovieId = movieId;
            return viewModel;

            //return new MovieRatingCreateViewModel
            //{
            //    MovieId = movieRating.MovieId,
            //    MovieName = movieRating.MovieName
            //};
        }

        public void Persist()
        {
            Models.MovieRating movieRating = new Models.MovieRating
            {
                //Id = this.Id,
                MovieName = this.MovieName,
                Rating = this.Rating,
                MovieId = this.MovieId
            };
            RepositoryFactory.GetMovieRatingRepository().Save(movieRating);
        }

    }
}


