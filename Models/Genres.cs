namespace WebApplicationINSAT.Models
{
    public class Genres
    {
        public Guid Id { get; set; }
        public string GenreName { get; set; }
        public List<Movies> Moviesg { get; set; }
        public Genres() { }

    }
}
