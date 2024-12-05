namespace WebApplicationINSAT.Models
{
    public class Membershiptypes
    {
        public Guid Id { get; set; }
        public int SignUpFee { get; set; }
        public String DurationInMonth { get; set; }
        public int DiscountRate { get; set; }
        public List<Customers> customers { get; set; } = new List<Customers>();
        public string Name { get; internal set; }

        public Membershiptypes() { }

    }
}
