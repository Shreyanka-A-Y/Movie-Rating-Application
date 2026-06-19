using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.DataAccess.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
       
    }
}
