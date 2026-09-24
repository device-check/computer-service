namespace domain.Entities
{
    public class ComputerType
    {
        private Guid id_computer_type;
        private string _computerTypeName;

        private ComputerType()
        {
            // E.F Core
        }

        public Guid GetId()
        {
            return id_computer_type;
        }

        public string GetName()
        {
            return _computerTypeName;
        }
    }
}