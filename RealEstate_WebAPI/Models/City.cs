using System;
using System.Collections.Generic;

namespace RealEstate_WebAPI.Models
{
    public partial class City
    {
        public City()
        {
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string Postcode { get; set; } = null!;
        public int CountryId { get; set; }


    }
}
