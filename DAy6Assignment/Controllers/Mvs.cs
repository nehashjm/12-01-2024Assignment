using DAy6Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAy6Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mvs : ControllerBase
    {
        private static readonly List<Movies> movies = new List<Movies>()
        {
            new(){Id=1, Name="Fukrey",Genere="comedy",Rating=8},
            new(){Id=2, Name="welcome",Genere="comedy",Rating=8},
            new(){Id=3, Name="heraperi",Genere="comedy",Rating=8},

        };

        [HttpGet(Name = "GetMovies")]
        public IEnumerable<Movies> Get() 
        {
            return movies;
        }

        [HttpPost(Name = "AddMovie")]
        public IActionResult Post([FromBody] Movies newMovie)
        {
            if (newMovie == null)
            {
                return BadRequest("Invalid data");
            }

            movies.Add(newMovie);
            return CreatedAtRoute("GetMovies", new { id = newMovie.Id }, newMovie);
        }

        [HttpPut("{id}", Name = "UpdateMovie")]
        public IActionResult Put(int id, [FromBody] Movies updatedMovie)
        {
            if (updatedMovie == null || id != updatedMovie.Id)
            {
                return BadRequest("Invalid data");
            }

            var existingMovie = movies.Find(m => m.Id == id);

            if (existingMovie == null)
            {
                return NotFound();
            }

            existingMovie.Name = updatedMovie.Name;
            existingMovie.Genere = updatedMovie.Genere;
            existingMovie.Rating = updatedMovie.Rating;

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteMovie")]
        public IActionResult Delete(int id)
        {
            var movieToDelete = movies.Find(m => m.Id == id);

            if (movieToDelete == null)
            {
                return NotFound();
            }

            movies.Remove(movieToDelete);
            return NoContent();
        }
    }
}
