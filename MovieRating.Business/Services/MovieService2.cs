using MovieRating.Business.Interface;
using MovieRating.Commons.DTOs;
using MovieRating.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRating.Business.Services
{
    public class MovieService2 : IMovieService
    {

        private readonly  IMovieRepository _movieRepository;
        private readonly  IRatingService _ratingService;
        public MovieService2(IMovieRepository movieRepository, IRatingService ratingService)
        {
            _movieRepository = movieRepository;
            _ratingService = ratingService;
        }


        public IEnumerable<MovieDetailDTO> GetMovieDetail()
        {
            var movies = _movieRepository.GetAll();

            return movies.Select(m => new MovieDetailDTO
            {
                Id = m.Id,
                Title = m.Title,
                //Description = m.Description,
                Genre = m.Genre,
                ReleaseYear = m.ReleaseYear,
                AverageRating = GetAverageRating(m.Id),
                TotalRating = GetTotalRating(m.Id)
            });
            
        }


        public double GetAverageRating(int id)
        {
            var movieRating = _ratingService.GetRatingById(id);

            return movieRating.Average(r => r.RatingStars);
        }
        public int GetTotalRating(int id)
        {
            var movieRating = _ratingService.GetRatingById(id);

            return movieRating.Count();
        }

        public void AddMovie(MovieDTO movieDTO)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(int id, MovieDTO movieDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDetailDTO> SearchMovie(string searchWord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDetailDTO> SortMovie(string searchWord, string sortBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDetailDTO> SearchMovies(string searchWord)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDetailDTO> FilterByRating(int rating)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDetailDTO> SortMovie(string? sortBy)
        {
            throw new NotImplementedException();
        }

        public MovieDetailDTO GetMovieById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
