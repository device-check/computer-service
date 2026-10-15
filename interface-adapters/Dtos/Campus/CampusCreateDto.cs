using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.Campus
{
    public class CampusCreateDto
    {
        [Required(ErrorMessage="Campus name is required.")]
        public string Name { get; set; }
    }
}