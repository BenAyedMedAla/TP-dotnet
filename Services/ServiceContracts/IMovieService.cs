using WebApplicationINSAT.Models;

namespace WebApplicationINSAT.Services.ServiceContracts
{
    public interface IMovieService
    {
        List<Movies> GetMoviesByGenre(Guid genreId);
        List<Movies> GetAllMoviesOrdered();
        List<Movies> GetMoviesByGenreId(Guid genreId);

    }
}
