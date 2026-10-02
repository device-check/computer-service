using interface_adapters.Dtos.Building;
using interface_adapters.Dtos.Campus;
using interface_adapters.Dtos.Room;

namespace interface_adapters.Dtos.ComputerPhysicalLocation
{
    public class ComputerPhysicalLocationReadDto
    {
        public CampusReadDto Campus { get; set; }
        public BuildingReadDto Building { get; set; }
        public int Floor { get; set; }
        public RoomReadDto Room { get; set; }
    }
}