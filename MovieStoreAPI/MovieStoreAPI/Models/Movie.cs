using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public decimal Price { get; set; }
        // Add other properties as needed (e.g., Director, Duration, Rating, etc.)
    }
}
