namespace domain.Entities
{
    public class Building
    {
        private Guid id_building = Guid.NewGuid();
        private string _buildingName;

        private Building()
        {
            // E.F Core
        }

        public Building(string buildingName)
        {
            SetName(buildingName);
        }

        public Guid GetId()
        {
            return id_building;
        }

        public string GetName()
        {
            return _buildingName;
        }

        public void SetName(string buildingName)
        {
            // Pré-Contract
            if (string.IsNullOrEmpty(buildingName))
                throw new DomainException("Building name cannot be null or empty.");

            // Domain constraint
            string buildingNameUpperCase = buildingName.Trim().ToUpper();

            _buildingName = buildingNameUpperCase;
        }
    }
}