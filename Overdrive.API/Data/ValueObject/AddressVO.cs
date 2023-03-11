namespace Overdrive.API.Data.ValueObject
{
    public class AddressVO
    {
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Bairro { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
    }
}