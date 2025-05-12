using WebApplicationINSAT.Models;
using WebApplicationINSAT.Services.ServiceContracts;

namespace WebApplicationINSAT.Services.Services
{
    public class MovieService : IMovieService
    {
        private readonly List<Movies> _movies;

        public MovieService()
        {
            // Initialize with mock data
            _movies = new List<Movies>
            {
                new Movies { Id = Guid.NewGuid(), Name = "Inception", Genre_id = Guid.NewGuid(), Cus = new List<Customers>() },
                new Movies { Id = Guid.NewGuid(), Name = "The Matrix", Genre_id = Guid.NewGuid(), Cus = new List<Customers>() },
                new Movies { Id = Guid.NewGuid(), Name = "Interstellar", Genre_id = Guid.NewGuid(), Cus = new List<Customers>() }
            };
        }

        // List all movies by a specific genre
        public List<Movies> GetMoviesByGenre(Guid genreId)
        {
            return _movies.Where(movie => movie.Genre_id == genreId).ToList();
        }

        // List all movies in ascending order by name
        public List<Movies> GetAllMoviesOrdered()
        {
            return _movies.OrderBy(movie => movie.Name).ToList();
        }

        // Get movies by their genre ID
        public List<Movies> GetMoviesByGenreId(Guid genreId)
        {
            return _movies.Where(movie => movie.Genre_id == genreId).ToList();
        }
    }
}

