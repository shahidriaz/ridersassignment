using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;

namespace API.Extensions
{
    public static class Extensions
    {
        public static RiderDTO ToRiderDTO(this Rider rider)
        {
            RiderDTO riderDTO = new RiderDTO()
            {
                CompanyNumber = rider.CompanyNumber,
                Email = rider.Email,
                EmExpiredate = rider.EmExpiredate,
                EmirateId = rider.EmirateId,
                EmIssuedate = rider.EmIssuedate,
                Id = rider.Id,
                LabourCard = rider.LabourCard,
                LbExpiredate = rider.LbExpiredate,
                LbIssuedate = rider.LbIssuedate,
                LicenseNumber = rider.LicenseNumber,
                Name = rider.Name,
                PassportNumber = rider.PassportNumber,
                PersonalNumber = rider.PersonalNumber,
                RriderId = rider.RriderId,
                VisaCategory = rider.VisaCategory,
                VisaSponsor = rider.VisaSponsor,
                WorkingCity = rider.WorkingCity,
                WorkingStatus = rider.WorkingStatus,
            };
            return riderDTO;
        }
        public static Rider ToRider(this RiderDTO rider)
        {
            Rider originalRider = new Rider()
            {
                CompanyNumber = rider.CompanyNumber,
                Email = rider.Email,
                EmExpiredate = rider.EmExpiredate,
                EmirateId = rider.EmirateId,
                EmIssuedate = rider.EmIssuedate,
                Id = rider.Id,
                LabourCard = rider.LabourCard,
                LbExpiredate = rider.LbExpiredate,
                LbIssuedate = rider.LbIssuedate,
                LicenseNumber = rider.LicenseNumber,
                Name = rider.Name,
                PassportNumber = rider.PassportNumber,
                PersonalNumber = rider.PersonalNumber,
                RriderId = rider.RriderId,
                VisaCategory = rider.VisaCategory,
                VisaSponsor = rider.VisaSponsor,
                WorkingCity = rider.WorkingCity,
                WorkingStatus = rider.WorkingStatus,
            };
            return originalRider;
        }
    }
}