using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Model;


namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents(int page = 1, int pageSize = 10)
        {
            var students = await _context.Students
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;
            await _context.SaveChangesAsync();

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            student.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Ok("Deleted successfully");
        }
    }
}
