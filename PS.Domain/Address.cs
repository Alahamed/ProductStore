using Microsoft.EntityFrameworkCore;

namespace PS.Domain
{
    [Owned]
    public class Address
    {
        public string City { get; set; }
        public string StreetAddress { get; set; }
    }
}