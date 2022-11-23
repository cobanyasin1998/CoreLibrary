namespace CoreLibrary.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }
        public DateTime? BirthDate { get; set; }
        public EGender Gender { get; set; }
        public CreditCard CreditCard { get; set; }

        public string FullName2()
        {
            return $"{Name} - {Email} - {Age}";
        }

        public IList<Address> Address { get; set; }
    }
}
