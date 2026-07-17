using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieRating.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; } = string.Empty;
        [Required] public string Genre { get; set; } = string.Empty;
        [Required] public string Description { get; set; } = string.Empty;
        [Required]  public int ReleaseYear { get; set; } 
        public string PosterUrl { get; set; } = string.Empty;

        public virtual ICollection<Rating>? Ratings { get; set; }

    }
}
