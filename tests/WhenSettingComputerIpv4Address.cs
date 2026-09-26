using domain;
using domain.Entities;
using System.Net;
using System.Net.NetworkInformation;

namespace tests
{
    public class WhenSettingComputerIpv4Address
    {
        [Fact]
        public void WithNullIpv4AddressShouldThrowDomainException()
        {
            // Arrange
            PhysicalAddress computerValidMacAddress = PhysicalAddress.Parse("00-1A-2B-3C-4D-5E");
            IPAddress computerIpv4Address = null;
            Guid valid_id = Guid.NewGuid();

            // Act + Assert
            Assert.Throws<DomainException>(() =>
            {
                Computer computer = new(
                    valid_id,
                    valid_id,
                    valid_id,
                    computerValidMacAddress,
                    computerIpv4Address);
            });
        }

        [Theory]
        [InlineData("0.0.0.0")]
        [InlineData("127.0.0.1")]
        public void WithInvalidIpv4AddressDontShouldThrowException(string computerInvalidIpv4Address)
        {
            // Arrange
            PhysicalAddress computerValidMacAddress = PhysicalAddress.Parse("00-1A-2B-3C-4D-5E");
            Guid valid_id = Guid.NewGuid();

            // Act + Assert
            Assert.Throws<DomainException>(() =>
            {
                Computer computer = new(
                    valid_id,
                    valid_id,
                    valid_id,
                    computerValidMacAddress,
                    IPAddress.Parse(computerInvalidIpv4Address));
            });
        }


        [Theory]
        [InlineData("192.168.255.255")]
        [InlineData("192.168.255.0")]
        [InlineData("192.168.0.255")]
        [InlineData("192.168.0.0")]
        public void WithValidIpv4AddressDontShouldThrowException(string computerValidIpv4Address)
        {
            // Arrange
            PhysicalAddress computerValidMacAddress = PhysicalAddress.Parse("00-1A-2B-3C-4D-5E");
            Guid valid_id = Guid.NewGuid();

            // Act
            var result = Record.Exception(() =>
            {
                Computer computer = new(
                    valid_id,
                    valid_id,
                    valid_id,
                    computerValidMacAddress,
                    IPAddress.Parse(computerValidIpv4Address));
            });

            // Assert
            Assert.True(!(result is DomainException));            
        }       
    }
}
