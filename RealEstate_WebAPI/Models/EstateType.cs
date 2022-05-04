using System;
using System.Collections.Generic;

namespace RealEstate_WebAPI.Models
{
    public partial class EstateType
    {
        public EstateType()
        {
            Estates = new HashSet<Estate>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Estate> Estates { get; set; }
    }
}
