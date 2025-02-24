using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Data;
using UniversityProject.Models;

namespace UniversityProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly UniversityDbContext _context;

        public LocationController(UniversityDbContext context)
        {
            _context = context;
        }

        // GET: api/Location
        [HttpGet]
        public IActionResult GetLocations()
        {
            return Ok(_context.Location.ToList());
        }

        // GET: api/Location/5
        [HttpGet("{id}")]
        public IActionResult GetLocation(int id)
        {
            var location = _context.Location.FirstOrDefault(l => l.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        // POST: api/Location
        [HttpPost]
        public IActionResult CreateLocation([FromBody] Location location)
        {
            if (location == null)
            {
                return BadRequest();
            }
            _context.Location.Add(location);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLocation), new { id = location.LocationId }, location);
        }

        // PUT: api/Location/5
        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id, [FromBody] Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }
            _context.Entry(location).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Location/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            var location = _context.Location.FirstOrDefault(l => l.LocationId == id);
            if (location == null)
            {
                return NotFound();
            }
            _context.Location.Remove(location);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
