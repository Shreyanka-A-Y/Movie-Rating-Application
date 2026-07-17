using MovieRating.Commons.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Business.Interface
{
    public interface IAuthService
    {
        string isLoginSuccessful(string username, string password);
    }
}
