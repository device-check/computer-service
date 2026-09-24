using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Entities
{
    public class Campus
    {
        private Guid id_campus = Guid.NewGuid();
        private string _campusName;

        private Campus()
        {
            // E.F Core
        }

        public Campus(string campusName)
        {
            SetName(campusName);
        }

        public Guid GetId()
        {
            return id_campus;
        }

        public string GetName()
        {
            return _campusName;
        }

        public void SetName(string campusName)
        {
            // Pré-contract           
            if (string.IsNullOrEmpty(campusName))
                throw new DomainException($"Campus name cannot be null or empty.");

            // Domain constraint
            string campusNameUpperCase = campusName.Trim().ToUpper();
            _campusName = campusNameUpperCase;
        }
    }
}
