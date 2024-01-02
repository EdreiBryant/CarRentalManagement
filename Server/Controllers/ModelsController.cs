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
    public class ModelsController : ControllerBase
    {
        //Refactor
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactor
        //public ModelsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public ModelsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Models
        [HttpGet]
        //Refactor
        //public async Task<ActionResult<IEnumerable<Model>>> GetModels()
        //{
        //  if (_context.Models == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Models.ToListAsync();
        //}

        public async Task<ActionResult> GetModels()
        {
            var Models = await _unitOfWork.Models.GetAll();
            return Ok(Models);
        }

        // GET: api/Models/5
        [HttpGet("{id}")]
        //Refactor/Changed
        //public async Task<ActionResult<Model>> GetModel(int id)
        //{
        //  if (_context.Models == null)
        //  {
        //      return NotFound();
        //  }
        //    var Model = await _context.Models.FindAsync(id);

        //    if (Model == null)
        //    {
        //        return NotFound();
        //    }

        //    return Model;
        //}

        public async Task<ActionResult> GetModel(int id)
        {
            var Model = await _unitOfWork.Models.Get(q => q.Id == id);

            if (Model == null)
            {
                return NotFound();
            }

            return Ok(Model);
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model Model)
        {
            if (id != Model.Id)
            {
                return BadRequest();
            }
            //Refactor/Changed
            //_context.Entry(Model).State = EntityState.Modified;
            _unitOfWork.Models.Update(Model);

            try
            {
                //Refactor/Change
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            //{
            //    if (!ModelExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            {
                if (!await ModelExists(id))
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(Model Model)
        {
            //if (_context.Models == null)
            //{
            //    return Problem("Entity set 'ApplicationDbContext.Models'  is null.");
            //}
            //  _context.Models.Add(Model);
            //  await _context.SaveChangesAsync();
            await _unitOfWork.Models.Insert(Model);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetModel", new { id = Model.Id }, Model);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            //if (_context.Models == null)
            //{
            //    return NotFound();
            //}
            //var Model = await _context.Models.FindAsync(id);
            //if (Model == null)
            //{
            //    return NotFound();
            //}

            //_context.Models.Remove(Model);
            //await _context.SaveChangesAsync();

            //return NoContent();

            var Model = await _unitOfWork.Models.Get(q => q.Id == id);
            if (Model == null)
            {
                return NotFound();
            }

            await _unitOfWork.Models.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();

        }

        //private bool ModelExists(int id)
        //{
        //    return (_context.Models?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        private async Task<bool> ModelExists(int id)
        {
            var Model = await _unitOfWork.Models.Get(q => q.Id == id);
            return Model != null;
        }
    }
}
