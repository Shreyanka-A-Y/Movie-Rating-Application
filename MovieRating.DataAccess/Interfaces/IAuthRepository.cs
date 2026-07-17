using MovieRating.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.DataAccess.Interfaces
{
    public interface IAuthRepository
    {
        User? GetUserName(string username);
    }
}
