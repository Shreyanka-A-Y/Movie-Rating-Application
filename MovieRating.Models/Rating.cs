using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovieRating.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [ForeignKey("MovieId")]
        public virtual Movie Movies { get; set; }


        [Required]
        [Range(1, 5)]
        public int RatingStars { get; set; }
    }
}
