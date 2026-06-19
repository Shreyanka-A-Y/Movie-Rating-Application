using Microsoft.AspNetCore.Mvc;
using MovieRating.Business.Interface;
using MovieRating.Commons.DTOs;

namespace MovieRating.API.Controllers
{
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

        [HttpPost("Create")]
        public IActionResult AddMovies(MovieDTO movieDTO)
        {
            _movieService.AddMovie(movieDTO);
            return Ok("Movie added sucessfully");
        }

        [HttpPut("Update")]
        public IActionResult UpdateMovies(int id, MovieDTO movieDTO)
        {
            _movieService.UpdateMovie(id, movieDTO);
            return Ok("Movie updated sucessfully");
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteMovies(int id)
        {
            _movieService.DeleteMovie(id);
            return Ok("Movie deleted sucessfully");
        }

        [HttpGet("Search")]
        public IActionResult SearchMovies(string searchWord)
        {
            var movies = _movieService.SearchMovie(searchWord);
            return Ok(movies);
        }

        [HttpGet("Sort")]
        public IActionResult SortMovies(string searchWord, string? sortBy)
        {
            var movies = _movieService.SortMovie(searchWord, sortBy);
            return Ok(movies);
        }
    }
}
