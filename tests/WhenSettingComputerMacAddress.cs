using domain;
using domain.Entities;
using System.Net;
using System.Net.NetworkInformation;

namespace tests
{
    public class WhenSettingComputerMacAddress
    {
        [Fact]
        public void WithNullMacAddressShouldThrowDomainException()
        {
            // Arrange
            PhysicalAddress computerInvalidMacAddress = null;
            IPAddress computerValidIpv4Address = IPAddress.Parse("192.168.1.105");
            Guid valid_id = Guid.NewGuid();

            // Act + Assert
            Assert.Throws<DomainException>(() =>
            {
                Computer computer = new(
                    valid_id,
                    valid_id,
                    valid_id,
                    computerInvalidMacAddress,
                    computerValidIpv4Address);
            });
        }       


        [Theory]
        [InlineData("00-1A-2B-3C-4D-5E")]
        [InlineData("A4:5E:60:12:34:56")]
        [InlineData("B827EB456789")]
        [InlineData("DC-A6-32-98-76-54")]
        public void WithValidMacAddressDontShouldThrowException(string computerValidMacAddress)
        {
            // Arrange
            IPAddress computerValidIpv4Address = IPAddress.Parse("192.168.1.105");
            Guid valid_id = Guid.NewGuid();

            // Act
            var result = Record.Exception(() =>
            {
                Computer computer = new(
                    valid_id,
                    valid_id,
                    valid_id,
                    PhysicalAddress.Parse(computerValidMacAddress),
                    computerValidIpv4Address);
            });

            // Assert
            Assert.True(!(result is DomainException));            
        }       
    }
}
