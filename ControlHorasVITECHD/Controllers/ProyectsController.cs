using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControlHorasVITECHD.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ControlHorasVITECHD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProyectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProyectsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: api/Proyects
        [HttpGet]
        public IEnumerable<Proyects> GetProyects()
        {
            

            return _context.Proyects.Include(p=>p.Tasks).ThenInclude(t=>t.Hours).Include(p=>p.Clients);
        }

        // GET: api/Proyects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProyects([FromRoute] int id)
        {
            var user = _context.Users.Where(u=>u.Email == User.Identity.Name).First();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proyects = await _context.Proyects.FindAsync(id);

            if (proyects == null)
            {
                return NotFound();
            }

            return Ok(proyects);
        }

        // PUT: api/Proyects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProyects([FromRoute] int id, [FromBody] Proyects proyects)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proyects.Id)
            {
                return BadRequest();
            }

            _context.Entry(proyects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProyectsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Proyects
        [HttpPost]
        public async Task<IActionResult> PostProyects([FromBody] Proyects proyects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Proyects.Add(proyects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProyects", new { id = proyects.Id }, proyects);
        }

        // DELETE: api/Proyects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProyects([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proyects = await _context.Proyects.FindAsync(id);
            if (proyects == null)
            {
                return NotFound();
            }

            _context.Proyects.Remove(proyects);
            await _context.SaveChangesAsync();

            return Ok(proyects);
        }

        private bool ProyectsExists(int id)
        {
            return _context.Proyects.Any(e => e.Id == id);
        }
    }
}