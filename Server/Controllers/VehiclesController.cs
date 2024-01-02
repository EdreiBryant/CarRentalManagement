using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        //Refactor
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactor
        //public VehiclesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public VehiclesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Vehicles
        [HttpGet]
        //Refactor
        //public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        //{
        //  if (_context.Vehicles == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Vehicles.ToListAsync();
        //}

        public async Task<ActionResult> GetVehicles()
        {
            var Vehicles = await _unitOfWork.Vehicles.GetAll();
            return Ok(Vehicles);
        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        //Refactor/Changed
        //public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        //{
        //  if (_context.Vehicles == null)
        //  {
        //      return NotFound();
        //  }
        //    var Vehicle = await _context.Vehicles.FindAsync(id);

        //    if (Vehicle == null)
        //    {
        //        return NotFound();
        //    }

        //    return Vehicle;
        //}

        public async Task<ActionResult> GetVehicle(int id)
        {
            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);

            if (Vehicle == null)
            {
                return NotFound();
            }

            return Ok(Vehicle);
        }

        // PUT: api/Vehicles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicle(int id, Vehicle Vehicle)
        {
            if (id != Vehicle.Id)
            {
                return BadRequest();
            }
            //Refactor/Changed
            //_context.Entry(Vehicle).State = EntityState.Modified;
            _unitOfWork.Vehicles.Update(Vehicle);

            try
            {
                //Refactor/Change
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            //{
            //    if (!VehicleExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            {
                if (!await VehicleExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Vehicles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle Vehicle)
        {
            //if (_context.Vehicles == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            //}
            //  _context.Vehicles.Add(Vehicle);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Vehicles.Insert(Vehicle);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetVehicle", new { id = Vehicle.Id }, Vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            //if (_context.Vehicles == null)
            //{
            //    return NotFound();
            //}
            //var Vehicle = await _context.Vehicles.FindAsync(id);
            //if (Vehicle == null)
            //{
            //    return NotFound();
            //}

            //_context.Vehicles.Remove(Vehicle);
            //await _context.SaveChangesAsync();

            //return NoContent();

            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            if (Vehicle == null)
            {
                return NotFound();
            }

            await _unitOfWork.Vehicles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();

        }

        //private bool VehicleExists(int id)
        //{
        //    return (_context.Vehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        private async Task<bool> VehicleExists(int id)
        {
            var Vehicle = await _unitOfWork.Vehicles.Get(q => q.Id == id);
            return Vehicle != null;
        }
    }
}
