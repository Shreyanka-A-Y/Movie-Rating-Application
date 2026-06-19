using MovieRating.Business.Interface;
using MovieRating.Commons.DTOs;
using MovieRating.DataAccess.Interfaces;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRating.Business.Services
{
    public class RatingService : IRatingService
    {

        private readonly IRatingRepository _ratingRepository;
        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public IEnumerable<RatingDTO> GetRatingDetail()
        {
            var ratings = _ratingRepository.GetAll();

            return ratings.Select(r => new RatingDTO
            {
                MovieId = r.MovieId,
                RatingStars = r.RatingStars
            });
        }
        public IEnumerable<RatingDTO> GetRatingById(int id)
        {
            var rating = _ratingRepository.GetById(id);

            return rating.Select(r => new RatingDTO
            {
                MovieId = r.MovieId,
                RatingStars = r.RatingStars
            }).ToList();
        }

        public void AddRating(RatingDTO ratingDto)
        {
            var rating = new Rating
            {
                MovieId = ratingDto.MovieId,
                RatingStars = ratingDto.RatingStars
            };

            _ratingRepository.Add(rating);
        }
    }
}
