using System;
using System.Collections.Generic;

namespace RealEstate_WebAPI.Models
{
    public partial class Role
    {
        public Role()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}
