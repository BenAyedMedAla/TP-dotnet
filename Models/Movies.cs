using System.Security.Cryptography.X509Certificates;

namespace WebApplicationINSAT.Models
{
    public class Movies
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Genre_id { get; set; }
        public List<Customers> Cus { get; set; }
        public Movies() { }
    }
}
