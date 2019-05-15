using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoderGirl_MVCMovies.Data;
using Microsoft.AspNetCore.Mvc;

namespace CoderGirl_MVCMovies.Controllers
{
    public class MovieRatingController : Controller
    {
        private IMovieRatingRepository repository = RepositoryFactory.GetMovieRatingRepository();
        public List<MovieRating> uniqueMovieNames = new List<MovieRating>();

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



        /// TODO: Create a view Index. This view should list a table of all saved movie names with associated average rating
        /// TODO: Be sure to include headers for Movie and Rating
        /// TODO: Each tr with a movie rating should have an id attribute equal to the id of the movie rating
        public IActionResult Index()
        {
            //if (uniqueMovieNames.Count < 0)
            //{
            //    ViewBag.Movies = uniqueMovieNames;
            //}
            //else
            //{
            //foreach (var movie in MovieController.movies)
            //{


            //    uniqueMovieNames.Add(new MovieRating() { Id = movie.Key, Name = movie.Value.ToString(), Rating = 1 });
            //}
            //}

            List<int> movieRatingID = repository.GetIds();
            var movieRatingList = movieRatingID.Select(id => repository.GetMovieNameById(id))
                .Distinct()
                .Select(name => new KeyValuePair<string, double>(name, repository.GetAverageRatingByMovieName(name))).ToList();

            ViewBag.Movies = movieRatingList;

            //ViewBag.Movies = uniqueMovieNames;
            //ViewBag.Movies = MovieController.movies;

            return View("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {
            if (uniqueMovieNames.Count > 0)
            {
                ViewBag.Movies = uniqueMovieNames;
            }
            else
            {
                foreach (var movie in MovieController.movies)
                {

                    int tempRating = 1;
                    uniqueMovieNames.Add(new MovieRating() { Id = movie.Key, Name = movie.Value.ToString(), Rating = tempRating });
                }
            }



            ViewBag.Movies = uniqueMovieNames;


            //ViewBag.Movies = MovieController.movies.Select(m => m.Value).Distinct();


            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(string movieName, string rating)
        {
            repository.SaveRating(movieName, int.Parse(rating));

            foreach (var movie in uniqueMovieNames.Where(w=> w.Name == movieName))
            {
                   movie.Rating = int.Parse(rating);
            }

      


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