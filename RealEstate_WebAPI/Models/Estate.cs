using System;
using System.Collections.Generic;

namespace RealEstate_WebAPI.Models
{
    public partial class Estate
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string? Address { get; set; }
        public decimal? PlotSize { get; set; }
        public decimal? BuildingSize { get; set; }
        public int Rooms { get; set; }
        public string? Comment { get; set; }
        public int? TargetPrice { get; set; }
        public int? MinimumPrice { get; set; }
        public int EstateTypeId { get; set; }
        public bool? ForRent { get; set; }
        public bool? ForSale { get; set; }
        public decimal? Deposit { get; set; }
        public bool? RentPrice { get; set; }
        public int OwnerId { get; set; }
        public int AgentId { get; set; }

        public virtual User Agent { get; set; } = null!;
        public virtual EstateType EstateType { get; set; } = null!;
        public virtual User Owner { get; set; } = null!;
    }
}
