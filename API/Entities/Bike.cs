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
        public string? BikeModel { get; set; }
        public string? EnginePower { get; set; }
        [Required]
        public string BikeNumber { get; set; } = string.Empty;
        public RiderBikeAssociation? RiderBikeAssociation { get; set; }
    }
}