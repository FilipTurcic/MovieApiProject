// Movie.cs
using System;

namespace MovieStoreAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        // Add other properties as needed (e.g., Director, Duration, Rating, etc.)
    }
}
