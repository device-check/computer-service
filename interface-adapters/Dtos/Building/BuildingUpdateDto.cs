using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.Building
{
    public class BuildingUpdateDto
    {

        [Required(ErrorMessage = "Building name is required.")]
        public required string Name { get; set; }
    }
}