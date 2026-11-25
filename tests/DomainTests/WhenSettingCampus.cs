using domain.Entities;
using shared_kernel.Exceptions.DomainLayerExceptions;

namespace tests.DomainTests
{
    public class WhenSettingCampus
    {
        [Fact]
        public void WithEmptyCampusNameShouldThrowDomainException()
        {
            // Arrange
            string invalidCampusName = string.Empty;

            // Act + Assert
            Assert.Throws<DomainLayerException>(() =>
            {
                Campus campus = new(invalidCampusName);
            });
        }

        [Fact]
        public void WithNullCampusNameShouldThrowDomainException()
        {
            // Arrange
            string invalidCampusName = null;

            // Act + Assert
            Assert.Throws<DomainLayerException>(() =>
            {
                Campus campus = new(invalidCampusName);
            });
        }

        [Fact]
        public void WithValidCampusNameShouldBeDefinedInUpperCaseFormat()
        {
            // Arrange
            string validCampusName = "sOUth ciTy";

            // Act
            Campus campus = new(validCampusName);

            // Assert
            Assert.True(campus.GetName() == validCampusName.ToUpper());
        }

        [Fact]
        public void WithValidCampusNameShouldGenerateAnId()
        {
            // Arrange
            string validCampusName = "South City";

            // Act
            Campus campus = new(validCampusName);

            // Assert
            Assert.NotEqual(Guid.Empty, campus.GetId());
        }
    }
}
