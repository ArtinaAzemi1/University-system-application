using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityProject.Data;
using UniversityProject.Models;
using Microsoft.EntityFrameworkCore;

namespace UniversityProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly UniversityDbContext _context;

        public GroupController(UniversityDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            var halls = _context.Groups.Include(h => h.Schedule).ToList();
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

        public async Task<IActionResult> GetGroup(int id)
        {
            if (_context.Groups == null)
            {
                return NotFound();
            }
            var group = await _context.Groups.Include(x => x.Schedule).Where(s => s.GroupId == id).Select(x => new
            {
                x.GroupId,
                x.GroupName,
                x.Capacity,
                x.ScheduleId
            }).FirstOrDefaultAsync();
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }


        [HttpPost]
        public async Task<IActionResult> PostHall([FromBody] Group group)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Validation Errors:");
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"{error.Key}: {string.Join(",", error.Value.Errors.Select(e => e.ErrorMessage))}");
                }
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(group.GroupName) || string.IsNullOrEmpty(group.Capacity) || group.ScheduleId <= 0)
            {
                return BadRequest("Të gjitha fushat janë të detyrueshme dhe duhet të kenë vlera valide.");
            }

            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGroup), new { id = group.GroupId }, group);
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
        public IActionResult UpdateHall(int id, [FromBody] Group group)
        {
            if (id != group.GroupId)
            {
                return BadRequest();
            }
            _context.Entry(group).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Hall/5
        [HttpDelete("{id}")]
        public IActionResult DeleteHall(int id)
        {
            var group = _context.Groups.FirstOrDefault(h => h.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
