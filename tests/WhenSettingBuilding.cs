using domain.Entities;
using domain.Exceptions;

namespace tests
{
    public class WhenSettingBuilding
    {

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
    }
}
