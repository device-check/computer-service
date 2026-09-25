namespace domain.Entities
{
    public class ComputerPhysicalLocation
    {
        private Guid id_computer_physical_location;
        private Guid id_campus;
        private Guid id_building;
        private int _floorNumber;
        private Guid id_room;

        private Campus _campus;
        private Building _building;
        private Room _room;

        private ComputerPhysicalLocation()
        {
            // E.F Core
        }      

        public ComputerPhysicalLocation(Guid idCampus, Guid idBuilding, int floorNumber, Guid idRoom)
        {
            SetIdCampus(idCampus);
            SetIdBuilding(idBuilding);
            _floorNumber = floorNumber;
            SetIdRoom(idRoom);
        }

        public Campus GetCampus()
        {
            return _campus;
        }

        public Building GetBuilding()
        {
            return _building;
        }

        public int GetFloor()
        {
            return _floorNumber;
        }

        public Room GetRoom()
        {
            return _room;
        }
        private void SetIdCampus(Guid idCampus)
        {
            // Pré-contract
            if (Guid.Empty == idCampus)
                throw new DomainException($"Campus id must be valid.");

            id_campus = idCampus;
        }

        private void SetIdBuilding(Guid idBuilding)
        {
            // Pré-contract
            if (Guid.Empty == idBuilding)
                throw new DomainException($"Building id must be valid.");

            id_building = idBuilding;
        }

        private void SetIdRoom(Guid idRoom)
        {
            // Pré-contract
            if (Guid.Empty == idRoom)
                throw new DomainException($"Room id must be valid.");

            id_room = idRoom;
        }
    }
}