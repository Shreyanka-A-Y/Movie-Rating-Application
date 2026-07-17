using EllipticCurve.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class MovieService : IMovieService
    {

        private readonly  IMovieRepository _movieRepository;
        private readonly  IRatingService _ratingService;
        public MovieService(IMovieRepository movieRepository, IRatingService ratingService)
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
                Description = m.Description,
                Genre = m.Genre,
                ReleaseYear = m.ReleaseYear,
                PosterUrl = m.PosterUrl,
                AverageRating = GetAverageRating(m.Id),
                TotalRating = GetTotalRating(m.Id)
            });
            
        }

        public MovieDetailDTO GetMovieById(int id)
        {
            var movie = _movieRepository.GetById(id);

            return  new MovieDetailDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                ReleaseYear = movie.ReleaseYear,
                PosterUrl = movie.PosterUrl,
                AverageRating = GetAverageRating(movie.Id),
                TotalRating = GetTotalRating(movie.Id)
            };
        }

        public void AddMovie(MovieDTO movieDTO)
        {
            var movie = new Movie
            {
                Title = movieDTO.Title,
                Description = movieDTO.Description,
                Genre = movieDTO.Genre,
                ReleaseYear = movieDTO.ReleaseYear,
                PosterUrl = movieDTO.PosterUrl,
            };

            
            _movieRepository.Add(movie);
        }

        public void UpdateMovie(int id, MovieDTO movieDto)
        {
            var movie = _movieRepository.GetById(id);

            movie.Id = id;
            movie.Title = movieDto.Title;
            movie.Description = movieDto.Description;
            movie.Genre = movieDto.Genre;
            movie.ReleaseYear = movieDto.ReleaseYear;
            movie.PosterUrl = movieDto.PosterUrl;
                
            _movieRepository.Update(movie);
        }

        public void DeleteMovie(int id)
        {
           var movie =  _movieRepository.GetById(id);

            if(movie == null)
            {
                throw new Exception("Movie Not Found.");
            }

            _movieRepository.Delete(id);
        }




        public IEnumerable<MovieDetailDTO> SearchMovies(string searchWord)
        {
            var movies = _movieRepository.SearchMovie(searchWord);

            return movies.Select(m => new MovieDetailDTO
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Genre = m.Genre,
                ReleaseYear = m.ReleaseYear,
                PosterUrl = m.PosterUrl,
                AverageRating = GetAverageRating(m.Id),
                TotalRating = GetTotalRating(m.Id)
            });
        }


        public IEnumerable<MovieDetailDTO> SortMovie(string? sortBy)
        {
            var movies = _movieRepository.GetAll();

             switch (sortBy)
             {
                case "Asc":
                    movies = movies.OrderBy(m => m.ReleaseYear);
                    break;
                case "Desc":
                    movies = movies.OrderByDescending(m => m.ReleaseYear);
                    break;
                default:
                    movies = movies.OrderByDescending(m => m.Id);
                    break;
             }

            return movies.Select(m => new MovieDetailDTO
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Genre = m.Genre,
                ReleaseYear = m.ReleaseYear,
                PosterUrl = m.PosterUrl,
                AverageRating = GetAverageRating(m.Id),
                TotalRating = GetTotalRating(m.Id)
            });
        }

        //public IEnumerable<MovieDetailDTO> SortMovie(string searchWord, string? sortBy)
        //{
        //    var movies = SearchMovies(searchWord);

        //    //if(sortBy == null)
        //    //{
        //    //    movies = movies.OrderBy(m => m.Id);
        //    //}

        //    if(int.TryParse(searchWord, out int year))
        //    {

        //        switch (sortBy)
        //        {
        //            case "Asc":
        //                movies = movies.OrderBy(m=> m.ReleaseYear);
        //                break;
        //            case "Desc":
        //                movies = movies.OrderByDescending(m => m.ReleaseYear);
        //                break;
        //            default:
        //                movies = movies.OrderBy(m => m.Id);
        //                break;

        //        }
        //    }
        //    else if (_movieRepository.GetAll().Where(m => m.Title.Contains(searchWord)) != null)
        //    {
        //        switch (sortBy)
        //        {
        //            case "Asc":
        //                movies = movies.OrderBy(m => m.Title);
        //                break;
        //            case "Desc":
        //                movies = movies.OrderByDescending(m => m.Title);
        //                break;
        //            default:
        //                movies = movies.OrderBy(m => m.Id);
        //                break;

        //        }
        //    }
        //    else
        //    {
        //        movies = movies.OrderBy(m => m.Id);
        //    }


        //    return movies.ToList();
        //}



        public double GetAverageRating(int id)
        {
            var movieRating = _ratingService.GetRatingById(id).ToList();

            if(movieRating == null || !movieRating.Any())
            {
                return 0;
            }

            return movieRating.Average(r => r.RatingStars);
        }
        public int GetTotalRating(int id)
        {
            var movieRating = _ratingService.GetRatingById(id).ToList();

            return movieRating.Count();
        }

        public IEnumerable<MovieDetailDTO> FilterByRating(int rating)
        {
            var movies = _movieRepository.GetAll();

            return movies.Select(m => new MovieDetailDTO
            {
                Id = m.Id,
                Title = m.Title,
                Description = m.Description,
                Genre = m.Genre,
                ReleaseYear = m.ReleaseYear,
                PosterUrl = m.PosterUrl,
                AverageRating = GetAverageRating(m.Id),
                TotalRating = GetTotalRating(m.Id)
            }).Where(m => m.AverageRating >= rating).ToList();
        }
    }
}
