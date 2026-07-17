using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieRating.Business.Interface;
using MovieRating.Commons.DTOs;

namespace MovieRating.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult AllMovies()
        {
            var movies = _movieService.GetMovieDetail();
            return Ok(movies);
        }

        [HttpGet("MovieById")]
        public IActionResult GetMovieByTd(int id)
        {
            try
            {
                var movie = _movieService.GetMovieById(id);
                return Ok(movie);
            }catch(Exception e)
            {
                return NotFound(e.Message);
            }

        }

        
        [HttpPost("Create")]
        public IActionResult AddMovies(MovieDTO movieDTO)
        {
            _movieService.AddMovie(movieDTO);
            return Ok(new
            {
                message = "Movie added successfully"
            });
        }

        [HttpPut("Update")]
        public IActionResult UpdateMovies(int id, MovieDTO movieDTO)
        {
            _movieService.UpdateMovie(id, movieDTO);
            return Ok("Movie updated sucessfully");
        }




        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public IActionResult DeleteMovies(int id)
        {
            try
            {
                 _movieService.DeleteMovie(id);
                return Ok(new
                {
                    message = "Movie deleted successfully"
                });


            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            


        }

        [HttpGet("Search")]
        public IActionResult SearchMovies(string searchWord)
        {
            var movies = _movieService.SearchMovies(searchWord);
            return Ok(movies);
        }

        [HttpGet("Sort")]
        public IActionResult SortMovies(string? sortBy)
        {
            var movies = _movieService.SortMovie(sortBy);
            return Ok(movies);
        }

        [HttpGet("Filter")]
        public IActionResult FilterByRating(int rating)
        {
            var movies = _movieService.FilterByRating(rating);
            return Ok(movies);
        }
    }
}
