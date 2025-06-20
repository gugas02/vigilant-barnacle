using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData
{
    public static class AddressTestData
    {
        public static Address GenerateValidAddress()
        {
            return new Address
            {
                City = "Sample City",
                Street = "Sample Street",
                Number = "123",
                Zipcode = "12345-678",
                Geolocation = GeolocationTestData.GenerateValidGeolocation()
            };
        }
    }
}
