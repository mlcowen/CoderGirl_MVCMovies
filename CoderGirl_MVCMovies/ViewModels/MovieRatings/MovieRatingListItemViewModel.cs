using CoderGirl_MVCMovies.Data;
using CoderGirl_MVCMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderGirl_MVCMovies.ViewModels.MovieRatings
{
    public class MovieRatingListItemViewModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        //public int MovieId { get; set; }
        public int Rating { get; set; }

        public static List<MovieRatingListItemViewModel> GetMovieRatingList()
        {
            return RepositoryFactory.GetMovieRatingRepository()
                .GetModels()
                .Cast<Models.MovieRating>()
                .Select(movieRating => GetMovieRatingIndexFromMovieRating(movieRating))
                //.Select(movieRating => GetMovieRatingListItemFromMovieRating(movieRating))
                .ToList();
        }
        private static MovieRatingListItemViewModel GetMovieRatingIndexFromMovieRating(Models.MovieRating movieRating)
        {
            return new MovieRatingListItemViewModel
            {
                Id = movieRating.Id,
                MovieName = movieRating.MovieName,
                //MovieId = movieRating.MovieId,
                Rating = movieRating.Rating
            };
        }
    }
}

