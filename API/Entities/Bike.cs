using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Bike
    {
        public int Id { get; set; }
        public string BikeName { get; set; } = string.Empty;

        public string BikeColor { get; set; } = string.Empty;
        public string? BikeModel { get; set; }
        public string BikeChasis { get; set; } = string.Empty;
        public string BikeNumber { get; set; } = string.Empty;
        public string MulkiyaNumber { get; set; } = string.Empty;

        public string IssueCity { get; set; } = string.Empty;
        public DateTime? IssueDate { get; set; }

        public DateTime? ExpireDate { get; set; }

        public string BikeOwner { get; set; } = string.Empty;

        public RiderBikeAssociation? RiderBikeAssociation { get; set; }
    }
}