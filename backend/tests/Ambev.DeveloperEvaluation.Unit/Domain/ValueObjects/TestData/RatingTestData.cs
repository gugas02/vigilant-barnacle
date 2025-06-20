using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData
{
    public static class RatingTestData
    {
        public static Rating GenerateValidRating()
        {
            return new Rating
            {
                Rate = 4.5m,
                Count = 10
            };
        }
    }
}
