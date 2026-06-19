using Microsoft.AspNetCore.Mvc;
using MovieRating.Business.Interface;
using MovieRating.Commons.DTOs;
using MovieRating.DataAccess.Interfaces;

namespace MovieRating.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("AddRating")]
        public IActionResult AddRatings(RatingDTO ratingDTO)
        {
            _ratingService.AddRating(ratingDTO);
            return CreatedAtAction(nameof(AddRatings), ratingDTO);
        }
    }
}
