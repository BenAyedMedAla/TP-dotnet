namespace WebApplicationINSAT.Models
{
    public class Customers
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       public Membershiptypes? Membership { get; set; }
        public Guid MembershipId { get; set; }
        public List<Movies> Moviesc{ get; set; } = new List<Movies>();

        public Customers() { }
    }
}
