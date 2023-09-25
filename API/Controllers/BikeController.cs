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
    public class BikeController : ControllerBase
    {
        private DataContext _datacontext;
        public BikeController(DataContext dataContext)
        {
            this._datacontext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bike>>> List()
        {
            return await _datacontext.Bikes.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Bike>> Get(int id)
        {
            return await _datacontext.Bikes.FindAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult<Bike>> Create(Bike bike)
        {
            if (ModelState.IsValid)
            {
                _datacontext.Bikes.Add(bike);
                try
                {
                    await _datacontext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return bike;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Bike>> Update(int id, Bike bike)
        {
            if (ModelState.IsValid)
            {
                var bikeToUpdate = await _datacontext.Bikes.SingleOrDefaultAsync(x => x.Id == id);
                if (bikeToUpdate == null)
                {
                    return BadRequest("This Bike does not exists!");
                }
                else
                {
                    bikeToUpdate.BikeNumber = bike.BikeNumber;
                    bikeToUpdate.BikeModel = bike.BikeModel;
                    bikeToUpdate.BikeChasis = bike.BikeChasis;
                    bikeToUpdate.MulkiyaNumber = bike.MulkiyaNumber;
                    bikeToUpdate.IssueCity = bike.IssueCity;
                    bikeToUpdate.BikeColor = bike.BikeColor;
                    bikeToUpdate.BikeOwner = bike.BikeOwner;
                    bikeToUpdate.ExpireDate = bike.ExpireDate;
                    bikeToUpdate.IssueDate = bike.IssueDate;
                    bikeToUpdate.BikeName = bike.BikeName;
                    try
                    {
                        await _datacontext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            return bike;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var bikeToDelete = _datacontext.Bikes.SingleOrDefault(x => x.Id == id);
            if (bikeToDelete == null)
            {
                return BadRequest("This bike does not exists!");
            }
            else
            {
                try
                {
                    _datacontext.Bikes.Remove(bikeToDelete);
                    await _datacontext.SaveChangesAsync();
                    return "Bike deleted successfully";
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}