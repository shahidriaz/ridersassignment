using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RiderBikeController : ControllerBase
    {
        private DataContext _dataContext;
        public RiderBikeController(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiderBikeAssociation>>> List()
        {
            return await _dataContext.RiderBikeAssociations.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RiderBikeAssociation>> Get(int id)
        {
            return await _dataContext.RiderBikeAssociations.FindAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<RiderBikeAssociation>> Create(RiderBikeAssociation riderBikeAssociation)
        {
            if (ModelState.IsValid)
            {
                _dataContext.RiderBikeAssociations.Add(riderBikeAssociation);
                try
                {
                    await _dataContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return riderBikeAssociation;
            }
            else
            {
                return BadRequest("Data is not Valid");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<RiderBikeAssociation>> Update(int id, RiderBikeAssociation riderBikeAssociation)
        {
            var updateRecord = await _dataContext.RiderBikeAssociations.SingleOrDefaultAsync(x => x.Id == id);
            if (updateRecord == null)
            {
                return BadRequest("This record does not exists");
            }
            if (ModelState.IsValid)
            {
                updateRecord.RiderId = riderBikeAssociation.RiderId;
                updateRecord.BikeId = riderBikeAssociation.BikeId;
                try
                {
                    await _dataContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Data is not correct!");
            }
            return riderBikeAssociation;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var toDelete = await _dataContext.RiderBikeAssociations.FindAsync(id);
            if (toDelete == null)
            {
                return BadRequest("This record does not exists");
            }
            _dataContext.RiderBikeAssociations.Remove(toDelete);
            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return "Deleted Successfully!";
        }
    }
}