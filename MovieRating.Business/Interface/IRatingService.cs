using MovieRating.Commons.DTOs;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Business.Interface
{
    public interface IRatingService
    {
        IEnumerable<RatingDTO> GetRatingDetail();
        IEnumerable<RatingDTO> GetRatingById(int id);
        void AddRating(RatingDTO ratingDto);

    }
}
