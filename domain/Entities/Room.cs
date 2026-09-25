namespace domain.Entities
{
    public class Room
    {
        private Guid id_room = Guid.NewGuid();
        private string RoomName;

        private Room()
        {
            // E.F Core
        }
        public Room(string roomName)
        {
            SetName(roomName);
        }

        public Guid GetId()
        {
            return id_room;
        }

        public string GetName()
        {
            return RoomName;
        }

        public void SetName(string roomName)
        {
            // Pré-contract
            if (string.IsNullOrEmpty(roomName))
                throw new DomainException("Room name cannot be null or empty.");

            // Domain constraint
            string roomNameUpperCase = roomName.Trim().ToUpper();

            RoomName = roomNameUpperCase;
        }
    }
}