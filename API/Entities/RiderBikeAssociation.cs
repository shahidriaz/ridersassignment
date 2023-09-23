using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class RiderBikeAssociation
    {
        [Key]
        public int Id { get; set; }
        public int RiderId { get; set; }
        public int BikeId { get; set; }

        public Rider Rider { get; set; }
        public Bike Bike { get; set; }
    }
}