using System;
using System.Collections.Generic;

namespace RealEstate_WebAPI.Models
{
    public partial class EstateType
    {
        public EstateType()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}
