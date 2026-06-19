using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRating.Commons.DTOs
{
    public class MovieDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string PosterUrl { get; set; } = string.Empty;
    }
}
