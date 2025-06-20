using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.ValueObjects.TestData
{
    public static class NameTestData
    {
        public static Name GenerateValidName()
        {
            return new Name
            {
                Firstname = "John",
                Lastname = "Doe"
            };
        }
    }
}
