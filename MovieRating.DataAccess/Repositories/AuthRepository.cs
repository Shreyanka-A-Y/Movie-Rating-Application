using MovieRating.DataAccess.Data;
using MovieRating.DataAccess.Interfaces;
using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRating.DataAccess.Repositories
{
    public class AuthRepository : IAuthRepository
    {

        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetUserName(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username)!;
        }
    }
}
