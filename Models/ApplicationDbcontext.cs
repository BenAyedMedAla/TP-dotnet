using Microsoft.EntityFrameworkCore;

namespace WebApplicationINSAT.Models
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }
        public DbSet<Movies>? Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Membershiptypes> Membershiptypes { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            string GenreJSon = System.IO.File.ReadAllText("genres.Json");
            List<Genres>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genres>>(GenreJSon);
            foreach (Genres c in genres)
                model.Entity<Genres>()
                .HasData(c);
        }
    }
}
