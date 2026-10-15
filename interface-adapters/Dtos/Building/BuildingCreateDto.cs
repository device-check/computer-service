using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.Building
{
    public class BuildingCreateDto
    {
        [Required(ErrorMessage="Building name is required.")]
        public string Name { get; set; }
    }
}
