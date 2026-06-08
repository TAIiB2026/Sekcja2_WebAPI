namespace Models
{
    public class AddressEntity
    {
        public int ID { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public PersonEntity Person { get; set; }
    }
}
