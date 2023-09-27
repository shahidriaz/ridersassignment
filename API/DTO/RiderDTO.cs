using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.DTO
{
    public class RiderDTO : BaseRider
    {
        public int BikeId { get; set; }
        public string BikeInfo { get; set; }
    }
}