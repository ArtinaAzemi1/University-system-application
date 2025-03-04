using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Data;
using UniversityProject.Models;

namespace UniversityProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        private readonly UniversityDbContext _context;

        public SemesterController(UniversityDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semester>>> GetSemesters()
        {
            return await _context.Semester.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Semester>> GetSemesterById(int id)
        {
            var semester = await _context.Semester.FindAsync(id);

            if (semester == null)
            {
                return NotFound();
            }

            return semester;
        }

        [HttpPost]
        public async Task<ActionResult<Semester>> PostSemester(Semester semester)
        {
            _context.Semester.Add(semester);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCourseById", new { id = course.CourseId }, course);
            return CreatedAtAction(nameof(GetSemesterById), new { id = semester.SemesterID }, semester);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemester(int id, Semester semester)
        {
            if (id != semester.SemesterID)
            {
                return BadRequest();
            }

            _context.Entry(semester).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(int id)
        {
            var semester = await _context.Semester.FindAsync(id);
            if (semester == null)
            {
                return NotFound();
            }

            _context.Semester.Remove(semester);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("totalSemesters")]
        public async Task<IActionResult> GetTotalSemesters()
        {
            try
            {
                var totalSemesters = await _context.Semester.CountAsync();

                var total = new
                {
                    TotalSemesters = totalSemesters
                };

                return Ok(total);
            }
            catch (Exception ex)
            {
                // Handle errors (e.g., log and return a server error)
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
