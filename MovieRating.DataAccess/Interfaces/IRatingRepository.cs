using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.DataAccess.Interfaces
{
    public interface IRatingRepository
    {
        IEnumerable<Rating> GetAll();
        IEnumerable<Rating> GetById(int id);

        void Add(Rating rating);
    }
}
