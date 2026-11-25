using System.ComponentModel.DataAnnotations;

namespace interface_adapters.Dtos.ComputerPhysicalLocation
{
    public class ComputerPhysicalLocationUpdateDto
    {
        public Guid? IdCampus { get; set; }
        public Guid? IdBuilding { get; set; }
        public int? FloorNumber { get; set; }
        public Guid? IdRoom { get; set; }
    }
}
