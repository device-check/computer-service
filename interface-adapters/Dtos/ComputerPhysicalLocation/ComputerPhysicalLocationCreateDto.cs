using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.ComputerPhysicalLocation
{
    public class ComputerPhysicalLocationCreateDto
    {
        [Required(ErrorMessage="Id campus is required.")]
        public required Guid IdCampus { get; set; }

        [Required(ErrorMessage = "Id building is required.")]
        public required Guid IdBuilding { get; set; }

        [Required(ErrorMessage = "Floor number is required.")]
        public required int FloorNumber { get; set; }

        [Required(ErrorMessage = "Id room is required.")]
        public required Guid IdRoom { get; set; }
    }
}