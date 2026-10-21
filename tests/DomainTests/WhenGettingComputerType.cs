using domain.Entities;

namespace tests.DomainTests
{
    public class WhenGettingComputerType
    {
        [Fact]
        public void ShouldReturnEmptyIdWhenComputerTypeIsNotInitialized()
        {
            // Arrange
            ComputerType computerType =
                (ComputerType)Activator.CreateInstance(
                    typeof(ComputerType),
                    nonPublic: true);

            // Act
            Guid result = computerType.GetId();

            // Assert
            Assert.Equal(Guid.Empty, result);
        }

        [Fact]
        public void ShouldReturnNullNameWhenComputerTypeIsNotInitialized()
        {
            // Arrange
            ComputerType computerType =
                (ComputerType)Activator.CreateInstance(
                    typeof(ComputerType),
                    nonPublic: true);

            // Act
            string result = computerType.GetName();

            // Assert
            Assert.Null(result);
        }
    }
}