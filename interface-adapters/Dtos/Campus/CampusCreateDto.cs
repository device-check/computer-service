using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.Campus
{
    public class CampusCreateDto
    {
        [Required(ErrorMessage="Campus name is required.")]
        public required string Name { get; set; }
    }
}