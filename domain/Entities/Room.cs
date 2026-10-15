using domain.Exceptions;

namespace domain.Entities
{
    public class Room
    {
        private Guid id_room = Guid.NewGuid();
        private string _roomName;

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
            return _roomName;
        }

        public void SetName(string roomName)
        {
            // Pré-contract
            if (string.IsNullOrEmpty(roomName))
                throw new DomainLayerException("Room name cannot be null or empty.");

            // Domain constraint
            string roomNameUpperCase = roomName.Trim().ToUpper();

            _roomName = roomNameUpperCase;
        }
    }
}