using MovieRating.DataAccess.Data;
using MovieRating.DataAccess.Interfaces;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRating.DataAccess.Repositories
{
    public class RatingRepositories : IRatingRepository
    {
        private readonly AppDbContext _context;
        public RatingRepositories(AppDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Rating> GetAll()
        {
            return _context.Ratings.ToList();
        }

        public IEnumerable<Rating> GetById(int id)
        {
            return _context.Ratings.Where(r => r.MovieId == id).ToList();
        }

        public void Add(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
        }
    }
}
