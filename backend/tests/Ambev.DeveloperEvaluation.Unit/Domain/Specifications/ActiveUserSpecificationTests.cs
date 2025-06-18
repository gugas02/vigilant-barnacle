using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications
{
    public class ActiveUserSpecificationTests
    {
        [Theory]
        [InlineData(EUserStatus.Active, true)]
        [InlineData(EUserStatus.Inactive, false)]
        [InlineData(EUserStatus.Suspended, false)]
        public void IsSatisfiedBy_ShouldValidateUserStatus(EUserStatus status, bool expectedResult)
        {
            // Arrange
            var user = ActiveUserSpecificationTestData.GenerateUser(status);
            var specification = new ActiveUserSpecification();

            // Act
            var result = specification.IsSatisfiedBy(user);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
