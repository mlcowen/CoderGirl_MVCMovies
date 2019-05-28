using CoderGirl_MVCMovies.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoderGirl_MVCMovies.Data
{
    internal class MovieRepository : BaseRepository
    {
        static IRepository ratingRepository = RepositoryFactory.GetMovieRatingRepository();
        static IRepository directorRepository = RepositoryFactory.GetDirectorRepository();

        public override IModel GetById(int id)
        {
            Movie movie = (Movie)base.GetById(id);
            movie = SetMovieRatings(movie);
            movie = SetDirectorName(movie);
            return movie;
        }

        public override List<IModel> GetModels()
        {
            /*return models.Select(movie => SetMovieRatings(movie))
                .Select(movie => SetDirectorName(movie)).ToList();
            */
            
            List<Movie> movies = base.GetModels().Cast<Movie>().ToList();

            return movies.Select(movie => SetMovieRatings(movie))
                .Select(movie => SetDirectorName(movie)).Cast<IModel>().ToList();
        }
       
        private Movie SetMovieRatings(Movie movie)
        {
            movie.Ratings = ratingRepository.GetModels().Cast<MovieRating>()
                                                .Where(rating => rating.MovieId == movie.Id)
                                                .Select(rating => rating.Rating)
                                                .ToList();
            //movie.Ratings = ratings;
            return movie;

        }

        private Movie SetDirectorName(Movie movie)
        {
            Director director = (Director)directorRepository.GetById(movie.DirectorId);
            //Director director = directorRepository.GetById(movie.Id).Cast<Director>();
            movie.DirectorName = director.FullName;
            return movie;
        }
    }
}
