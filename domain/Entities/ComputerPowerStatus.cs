namespace domain.Entities
{
    public class ComputerPowerStatus
    {
        private Guid id_computer_power_status;
        private string _statusName;

        private ComputerPowerStatus()
        {
            // E.F Core
        }

        public Guid GetId()
        {
            return id_computer_power_status;
        }

        public string GetStatus()
        {
            return _statusName;
        }
    }
}