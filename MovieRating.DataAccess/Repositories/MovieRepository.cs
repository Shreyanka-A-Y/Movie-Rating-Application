using MovieRating.DataAccess.Data;
using MovieRating.DataAccess.Interfaces;
using MovieRating.Commons.DTOs;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRating.DataAccess.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;
        public MovieRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public IEnumerable<Movie> SearchMovie(string searchWord)
        {
            return _context.Movies.Where(
                m => m.Title.Contains(searchWord) || 
                m.Genre.Contains(searchWord) || 
                m.ReleaseYear.ToString().Contains(searchWord)                
                ).ToList();
        }

        public Movie GetById(int id)
        {
            var movie = _context.Movies.Find(id);
            
            if (movie == null)
            {
                throw new Exception("Movie Not Found");
            }

            return movie;
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
           if(movie == null)
            {
                throw new Exception("Movie Not Found");
            }

            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);

            if (movie == null)
            {
                throw new Exception("Movie Not Found");
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

    }
}
