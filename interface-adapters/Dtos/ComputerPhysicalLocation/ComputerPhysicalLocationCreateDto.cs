using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.ComputerPhysicalLocation
{
    public class ComputerPhysicalLocationCreateDto
    {
        [Required(ErrorMessage="Id campus is required.")]
        public Guid IdCampus;

        [Required(ErrorMessage = "Id building is required.")]
        public Guid IdBuilding;

        [Required(ErrorMessage = "Floor number is required.")]
        public int FloorNumber;

        [Required(ErrorMessage = "Id room is required.")]
        public Guid IdRoom;
    }
}