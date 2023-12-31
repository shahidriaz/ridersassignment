using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO;
using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiderController : ControllerBase
    {
        private DataContext _dataContext;

        public RiderController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiderDTO>>> List()
        {
            var allRiders = await _dataContext.Riders.Include(x => x.RiderBikeAssociation).ToListAsync();
            List<RiderDTO> allRidersDTO = new List<RiderDTO>();
            foreach (Rider r in allRiders)
            {
                var riderDTO = r.ToRiderDTO();
                if (r != null && r.RiderBikeAssociation != null)
                {
                    var bikeInfo = await _dataContext.Bikes.FirstAsync(x => x.Id == r.RiderBikeAssociation.BikeId);
                    if (bikeInfo != null)
                    {
                        riderDTO.BikeId = bikeInfo.Id;
                        riderDTO.BikeInfo = bikeInfo.BikeModel + "-" + bikeInfo.BikeName + "-" + bikeInfo.BikeNumber;
                    }
                }
                allRidersDTO.Add(riderDTO);
            }
            return allRidersDTO;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RiderDTO>> GetUser(int id)
        {
            var rider = await _dataContext.Riders.Include(x => x.RiderBikeAssociation).FirstAsync(x => x.Id == id);
            RiderDTO riderDTO = rider.ToRiderDTO();
            if (rider != null && rider.RiderBikeAssociation != null)
            {
                var bikeInfo = await _dataContext.Bikes.FirstAsync(x => x.Id == rider.RiderBikeAssociation.BikeId);
                if (bikeInfo != null)
                {
                    riderDTO.BikeId = bikeInfo.Id;
                    riderDTO.BikeInfo = bikeInfo.BikeModel + "-" + bikeInfo.BikeName + "-" + bikeInfo.BikeNumber;
                }
            }
            return riderDTO;
        }
        [HttpPost]
        public async Task<ActionResult<RiderDTO>> Create(RiderDTO rider)
        {
            if (ModelState.IsValid)
            {
                Rider r = rider.ToRider();
                await _dataContext.Riders.AddAsync(r);
                _dataContext.SaveChanges();
                if (rider.BikeId != null)
                {
                    _dataContext.RiderBikeAssociations.Add(new RiderBikeAssociation()
                    {
                        BikeId = rider.BikeId,
                        RiderId = r.Id
                    });
                    await _dataContext.SaveChangesAsync();

                }
                return rider;
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Rider>> Update(int id, Rider rider)
        {
            var targetedRider = await _dataContext.Riders.SingleOrDefaultAsync(e => e.Id == id);
            if (targetedRider != null)
            {
                if (ModelState.IsValid)
                {
                    targetedRider.PersonalNumber = rider.PersonalNumber;
                    targetedRider.LicenseNumber = rider.LicenseNumber;
                    targetedRider.CompanyNumber = rider.CompanyNumber;
                    targetedRider.PassportNumber = rider.PassportNumber;
                    targetedRider.Email = rider.Email;
                    targetedRider.EmirateId = rider.EmirateId;
                    targetedRider.Name = rider.Name;
                    targetedRider.LabourCard = rider.LabourCard;
                    targetedRider.EmExpiredate = rider.EmExpiredate;
                    targetedRider.LbExpiredate = rider.LbExpiredate;
                    targetedRider.LbIssuedate = rider.LbIssuedate;
                    targetedRider.EmIssuedate = rider.EmIssuedate;
                    targetedRider.RriderId = rider.RriderId;
                    targetedRider.WorkingCity = rider.WorkingCity;
                    targetedRider.WorkingStatus = rider.WorkingStatus;
                    targetedRider.VisaSponsor = rider.VisaSponsor;
                    targetedRider.VisaCategory = rider.VisaCategory;
                    try
                    {
                        await _dataContext.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        // Handle concurrency exception if needed
                        return BadRequest(new Exception("Concurrency error occurred."));
                    }
                    return targetedRider;
                }
            }
            else
            {
                return BadRequest("This rider does not exists");
            }
            return rider;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var deleteRider = await _dataContext.Riders.FindAsync(id);
            if (deleteRider == null)
            {
                return BadRequest("This Rider does not exists");
            }
            else
            {
                _dataContext.Riders.Remove(deleteRider);
            }
            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "User deleted successfully";
        }
    }
}