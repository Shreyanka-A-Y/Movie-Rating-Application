using MovieRating.Commons.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Business.Interface
{
    public interface IMovieService
    {

        IEnumerable<MovieDetailDTO> GetMovieDetail();
        void AddMovie(MovieDTO movieDTO);
        void UpdateMovie(int id, MovieDTO movieDto);
        void DeleteMovie(int id);

        IEnumerable<MovieDetailDTO> SearchMovie(string searchWord);
        IEnumerable<MovieDetailDTO> SortMovie(string searchWord, string? sortBy);

    }
}
