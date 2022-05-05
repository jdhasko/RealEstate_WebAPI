using System;
using System.Collections.Generic;

namespace RealEstate_WebAPI.Models
{
    public partial class Auth
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }

        //public virtual User IdNavigation { get; set; } = null!;
    }
}
