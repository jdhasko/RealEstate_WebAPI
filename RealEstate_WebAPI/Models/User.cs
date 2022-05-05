using System;
using System.Collections.Generic;

namespace RealEstate_WebAPI.Models
{
    public partial class User
    {
        public User()
        {
            //EstateAgents = new HashSet<Estate>();
            //EstateOwners = new HashSet<Estate>();
        }

        public int? Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? PhoneNr { get; set; }
        public string? Address { get; set; }
        public string? TaxNr { get; set; }
        public string? Ssn { get; set; }
        public int? CityId { get; set; }
        public int? RoleId { get; set; }
        public DateTime? DateOfCreation { get; set; }

        //public virtual City? City { get; set; }
        //public virtual Role? Role { get; set; }
        //public virtual Auth Auth { get; set; } = null!;
        //public virtual ICollection<Estate> EstateAgents { get; set; }
        //public virtual ICollection<Estate> EstateOwners { get; set; }
    }
}
