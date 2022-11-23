namespace CoreLibrary.Web.Models
{
    public class Address
    {
        public int Id { get; set; }
        public String Content { get; set; }
        public String Province { get; set; }
        public String PostCode { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
