using MovieRating.Models;
using MovieRating.Commons.DTOs;
using System.Collections.Generic;

namespace MovieRating.DataAccess.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> SearchMovie(string searchWord);
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
       
    }
}
