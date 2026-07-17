using MovieRating.Commons.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Business.Interface
{
    public interface IMovieService
    {

        IEnumerable<MovieDetailDTO> GetMovieDetail();
        MovieDetailDTO GetMovieById(int id);
        void AddMovie(MovieDTO movieDTO);
        void UpdateMovie(int id, MovieDTO movieDto);
        void DeleteMovie(int id);

        IEnumerable<MovieDetailDTO> SearchMovies(string searchWord);
        IEnumerable<MovieDetailDTO> SortMovie(string? sortBy);

        IEnumerable<MovieDetailDTO> FilterByRating(int rating);

    }
}
