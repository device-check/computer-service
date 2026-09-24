namespace domain.Entities
{
    public class Building
    {
        private Guid id_building = Guid.NewGuid();
        private string BuildingName;

        private Building()
        {
            // E.F Core
        }

        public Building(string buildingName)
        {
            SetName(buildingName);
        }

        private void SetName(string buildingName)
        {
            throw new NotImplementedException();
        }
    }
}