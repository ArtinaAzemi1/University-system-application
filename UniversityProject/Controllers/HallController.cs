using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using UniversityProject.Data;
using UniversityProject.Models;

namespace UniversityProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly UniversityDbContext _context;

        public HallController(UniversityDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetHalls()
        {
            var halls = _context.Hall.Include(h => h.Location).ToList();
            return Ok(halls);
        }

        /*[HttpGet]
        public async Task<IActionResult> GetHalls()
        {
            if (_context.Hall == null)
            {
                return NotFound();
            }

            var Halls = await _context.Hall.Include(x => x.Location).Select(x => new
            {
                x.HallID,
                x.HallCode,
                x.Type,
                x.HallCapacity,
                x.LocationID
            }).ToListAsync();
            return Ok(Halls);
        }*/

        [HttpGet("{id}")]

        public async Task<IActionResult> GetHall(int id)
        {
            if (_context.Hall == null)
            {
                return NotFound();
            }
            var hall = await _context.Hall.Include(x => x.Location).Where(s => s.HallID == id).Select(x => new
            {
                x.HallID,
                x.HallCode,
                x.Type,
                x.HallCapacity,
                x.LocationID
            }).FirstOrDefaultAsync();
            if (hall == null)
            {
                return NotFound();
            }
            return Ok(hall);
        }


        [HttpPost]
        public async Task<IActionResult> PostHall([FromBody] Hall hall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Hall.AddAsync(hall);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHall), new { id = hall.HallID }, hall);
        }

        // GET: api/Hall
        /*[HttpGet]
        public IActionResult GetHalls()
        {
            var halls = _context.Hall.Include(h => h.Location).ToList();
            return Ok(halls);
        }

        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetHall(int id)
        {
            if (_context.Hall == null)
            {
                return NotFound();
            }
            var hall = await _context.Hall.Include(x => x.Location).Where(h => h.HallID == id).Select(x => new
            {
                x.HallID,
                x.HallCode,
                x.Type,
                x.HallCapacity,
                x.LocationID,
                x.Location.Address
            }).FirstOrDefaultAsync();
            if (hall == null)
            {
                return NotFound();
            }
            return Ok(hall);
        }


        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] Hall hall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Hall.AddAsync(hall);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHall), new { id = hall.HallID }, hall);
        }*/

        // GET: api/Hall/5
        /*[HttpGet("{id}")]
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

            if (!hall.LocationID.HasValue)
            {
                return BadRequest("Location ID is required.");
            }

            Console.WriteLine($"Received: HallCode={hall?.HallCode}, Type={hall?.Type}, HallCapacity={hall?.HallCapacity}, LocationID={hall?.LocationID}");

            _context.Hall.Add(hall);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetHall), new { id = hall.HallID }, hall);
        }*/

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
