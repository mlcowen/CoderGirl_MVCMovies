using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository repository = RepositoryFactory.GetMovieRatingRepository();
        public static List<Movie> movies = new List<Movie>();

        //Create a string html template for a form
        // with method of post
        // an input with name "movieName" 
        // a select with name "rating" and that contains options for 1 through 5
        // a button with type of submit
        private string htmlForm = @"
            <form method='post'>
                <input name='movieName' />
                <select name='rating'>
                    <option>1</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
                <button type='submit'>Submit</button>  
            </form>";

        private void PopulateMovieList()
        {
            //repository.SaveRating("The Matrix", 5);
            //repository.SaveRating("The Matrix", 3);
            //repository.SaveRating("The Matrix Reloaded", 2);
            //repository.SaveRating("The Matrix Reloaded", 3);
            //repository.SaveRating("The Matrix The really bad one", 2);
            //repository.SaveRating("The Matrix The really bad one", 1);

            foreach (int id in repository.GetIds())
            {
                Movie mov = new Movie();
                mov.Id = movies.Count + 1;
                mov.Name = repository.GetMovieNameById(id);
                mov.Rating = repository.GetRatingById(id);
                movies.Add(mov);
            }
        }

        /// TODO: Create a view Index. This view should list a table of all saved movie names with associated average rating
        /// TODO: Be sure to include headers for Movie and Rating
        /// TODO: Each tr with a movie rating should have an id attribute equal to the id of the movie rating
        public IActionResult Index()
        {
            PopulateMovieList();
            Dictionary<Movie, double> movieAverages = new Dictionary<Movie, double>();
            List<string> uniqueMovieNames = new List<string>();
            foreach (Movie movie in movies)
            {
                if (uniqueMovieNames.Contains(movie.Name))
                {
                    continue;
                }
                uniqueMovieNames.Add(movie.Name);
                movieAverages.Add(movie, repository.GetAverageRatingByMovieName(movie.Name));
            }
            ViewBag.Movies = movieAverages;

            return View("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Movies = movies;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            int id = repository.SaveRating(movieName, int.Parse(rating));

            return RedirectToAction(actionName: nameof(Details), routeValues: new { movieName, rating });
        }

        [HttpGet]
        public IActionResult Details(string movieName, string rating)
        {
            ViewBag.movieName = movieName;
            ViewBag.movieRating = rating;
            return View("Details");
        }
    }
}