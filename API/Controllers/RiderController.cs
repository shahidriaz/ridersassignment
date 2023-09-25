using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
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
        public async Task<ActionResult<IEnumerable<Rider>>> List()
        {
            return await _dataContext.Riders.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Rider>> GetUser(int id)
        {
            var rider = await _dataContext.Riders.FindAsync(id);
            return rider;
        }
        [HttpPost]
        public async Task<ActionResult<Rider>> Create(Rider rider)
        {
            if (ModelState.IsValid)
            {
                await _dataContext.Riders.AddAsync(rider);
                _dataContext.SaveChanges();
            }
            else
            {
                return BadRequest("Bad Request");
            }
            return rider;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Rider>> Update(int id, Rider rider)
        {
            var targetedRider = await _dataContext.Riders.SingleOrDefaultAsync(e => e.Id == id);
            if (targetedRider != null)
            {
                if (ModelState.IsValid)
                {
                    // targetedRider.PersonalNumber = rider.PersonalNumber;
                    // targetedRider.LicenseNumber = rider.LicenseNumber;
                    // targetedRider.CompanyNumber = rider.CompanyNumber;
                    // targetedRider.PassportNumber = rider.PassportNumber;
                    // targetedRider.Email = rider.Email;
                    // targetedRider.EmirateId = rider.EmirateId;
                    // targetedRider.Name = rider.Name;
                    // targetedRider.LabourCard = rider.LabourCard;
                    targetedRider = rider;
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