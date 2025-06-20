using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData
{
    public static class GeolocationTestData
    {
        public static Geolocation GenerateValidGeolocation()
        {
            return new Geolocation
            {
                Lat = "-23.5505",
                Long = "-46.6333"
            };
        }
    }
}
