using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Data;
using UniversityProject.Models;

namespace UniversityProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private UniversityDbContext _context;

        public HallController(UniversityDbContext context)
        {
            _context = context;
        }

        // GET: api/Hall
        [HttpGet]
        public IActionResult GetHalls()
        {
            var halls = _context.Hall.Include(h => h.Location).ToList();
            return Ok(halls);
        }

        // GET: api/Hall/5
        [HttpGet("{id}")]
        public IActionResult GetHall(int id)
        {
            var hall = _context.Hall.Include(h => h.Location).FirstOrDefault(h => h.HallID == id);
            if (hall == null)
            {
                return NotFound();
            }
            return Ok(hall);
        }

        // POST: api/Hall
        [HttpPost]
        public IActionResult CreateHall([FromBody] Hall hall)
        {
            if (hall == null)
            {
                return BadRequest();
            }
            _context.Hall.Add(hall);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetHall), new { id = hall.HallID }, hall);
        }

        // PUT: api/Hall/5
        [HttpPut("{id}")]
        public IActionResult UpdateHall(int id, [FromBody] Hall hall)
        {
            if (id != hall.HallID)
            {
                return BadRequest();
            }
            _context.Entry(hall).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Hall/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHall(int id)
        {
            var hall = _context.Hall.FirstOrDefault(h => h.HallID == id);
            if (hall == null)
            {
                return NotFound();
            }
            _context.Hall.Remove(hall);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
