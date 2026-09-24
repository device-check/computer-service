namespace domain.Entities
{
    public class ComputerPhysicalLocation
    {
        private Guid id_computer_physical_location;
        private Guid id_campus;
        private Guid id_building;
        private Campus _campus;
        private Building _building;

        private ComputerPhysicalLocation()
        {
            // E.F Core
        }      

        public ComputerPhysicalLocation(Guid idCampus)
        {
            SetIdCampus(idCampus);
        }

        public Campus GetCampus()
        {
            return _campus;
        }

        private void SetIdCampus(Guid idCampus)
        {
            // Pré-contract
            if (Guid.Empty == idCampus)
                throw new DomainException($"Campus id must be valid.");

            id_campus = idCampus;
        }
    }
}