using domain.Entities;
using domain.Exceptions;

namespace tests.DomainTests
{
    public class WhenSettingBuilding
    {
        [Fact]
        public void WithEmptyBuildingNameShouldThrowDomainException()
        {
            // Arrange
            string invalidBuildingName = string.Empty;

            // Act + Assert
            Assert.Throws<DomainLayerException>(() =>
            {
                Building building = new(invalidBuildingName);
            });
        }

        [Fact]
        public void WithNullBuildingNameShouldThrowDomainException()
        {
            // Arrange
            string invalidBuildingName = null;

            // Act + Assert
            Assert.Throws<DomainLayerException>(() =>
            {
                Building building = new(invalidBuildingName);
            });
        }

        [Fact]
        public void WithValidBuildingNameShouldBeDefinedInUpperCaseFormat()
        {
            // Arrange
            string validBuildingName = "buIlDIng A";

            // Act
            Building building = new(validBuildingName);

            // Assert
            Assert.True(building.GetName() == validBuildingName.ToUpper());
        }

        [Fact]
        public void WithValidBuildingNameShouldGenerateAnId()
        {
            // Arrange
            string validBuildingName = "Building A";

            // Act
            Building building = new(validBuildingName);

            // Assert
            Assert.NotEqual(Guid.Empty, building.GetId());
        }


    }
}
