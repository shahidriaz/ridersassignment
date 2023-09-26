using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Rider
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? CompanyNumber { get; set; }
        public string? PersonalNumber { get; set; }
        public string? Email { get; set; }
        [Required]
        public string EmirateId { get; set; } = string.Empty;
        [Required]
        public string PassportNumber { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string RriderId { get; set; } = string.Empty;
        public DateTime? EmIssuedate { get; set; }
        public DateTime? EmExpiredate { get; set; }
        public string LabourCard { get; set; } = string.Empty;
        public DateTime? LbIssuedate { get; set; }
        public DateTime? LbExpiredate { get; set; }
        public string? WorkingCity { get; set; }
        public string? WorkingStatus { get; set; }
        public string? VisaSponsor { get; set; }
        public string? VisaCategory { get; set; }

        public RiderBikeAssociation? RiderBikeAssociation { get; set; }

    }
}