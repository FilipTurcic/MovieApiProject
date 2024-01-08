// MovieController.cs - Manages movie data using HTTP methods (GET, POST, PUT, DELETE)

using Microsoft.AspNetCore.Mvc;
using MovieStoreAPI.Models;
using System.Collections.Generic;

namespace MovieStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // List to store movie data (for demo purposes, would usually be replaced by a database)
        private static List<Movie> _movies = new List<Movie>
        {
            // Predefined movies in the list
            new Movie { Id = 1, Title = "Movie 1", Genre = "Action", Year = 2022, Description = "Description for Movie 1", Price = 9.99m },
            new Movie { Id = 2, Title = "Movie 2", Genre = "Drama", Year = 2023, Description = "Description for Movie 2", Price = 8.49m },
            new Movie { Id = 3, Title = "Movie 3", Genre = "Horror", Year = 2022, Description = "Description for Movie 3", Price = 11.99m },
            new Movie { Id = 4, Title = "Movie 4", Genre = "Comedy", Year = 2021, Description = "Description for Movie 4", Price = 10.49m }
            // Add sample movies or use a database for actual data
        };

        // HTTP GET method to retrieve all movies
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_movies); // Returns a list of movies as a response
        }

        // HTTP GET method to retrieve a movie by its ID
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = _movies.Find(m => m.Id == id);
            if (movie == null)
                return NotFound(); // If the movie with the provided ID is not found, return a 404 Not Found response
            return Ok(movie); // Returns the requested movie
        }

        // HTTP POST method to add a new movie
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            // Validation: Checks if the movie object received is not null
            if (movie == null)
            {
                return BadRequest("Movie object is null"); // Returns a 400 Bad Request response
            }

            // Simple ID generation for the new movie (in a real scenario, use proper ID generation techniques)
            int newId = _movies.Count + 1;
            movie.Id = newId;

            // Adds the new movie to the list of movies
            _movies.Add(movie);

            // Returns a 201 Created status code along with the URI of the newly created movie
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        // HTTP PUT method to update an existing movie by its ID
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie movie)
        {
            // Validation: Checks if the provided movie object is not null or if the ID matches the one in the URL
            if (movie == null || movie.Id != id)
            {
                return BadRequest("Invalid request"); // Returns a 400 Bad Request response
            }

            // Finds the existing movie in the list by its ID
            var existingMovie = _movies.Find(m => m.Id == id);
            if (existingMovie == null)
            {
                return NotFound(); // If the movie to update is not found, return a 404 Not Found response
            }

            // Updates the existing movie's properties with the new data provided
            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;
            existingMovie.Year = movie.Year;
            existingMovie.Description = movie.Description;
            existingMovie.Price = movie.Price;

            return Ok(existingMovie); // Returns the updated movie
        }

        // HTTP DELETE method to delete a movie by its ID
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            // Finds the movie to delete by its ID
            var movieToDelete = _movies.Find(m => m.Id == id);
            if (movieToDelete == null)
            {
                return NotFound(); // If the movie to delete is not found, return a 404 Not Found response
            }

            _movies.Remove(movieToDelete); // Removes the movie from the list

            return NoContent(); // Returns a 204 No Content response indicating a successful deletion
        }
    }
}
