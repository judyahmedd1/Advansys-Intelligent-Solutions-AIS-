using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;


[ApiController]
[Route("[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CoursesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Courses> GetCourses()
    {
        return _context.Courses.ToList();
    }

    [HttpGet("{id}")]   // only change to your existing code
    public Courses? GetCourses(int id)
    {
        return _context.Courses.FirstOrDefault(rowInDatabase => rowInDatabase.CourseID == id);
    }

    [HttpPost]
    public int AddCourse(Courses course)
    {
        _context.Courses.Add(course);
        _context.SaveChanges();
        return course.CourseID;   // course.CourseID is now filled by the database
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCourse(int id, Courses course)
    {
        Courses? existing = _context.Courses.FirstOrDefault(c => c.CourseID == id);
        if (existing == null)
            return NotFound();

        existing.CourseID = course.CourseID;
        existing.CourseDescription = course.CourseDescription;
        existing.CourseName = course.CourseName;

        _context.SaveChanges();
        return Ok(existing);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCourse(int id)
    {
        Courses? existing = _context.Courses.FirstOrDefault(c => c.CourseID == id);
        if (existing == null)
            return NotFound();

        _context.Courses.Remove(existing);
        _context.SaveChanges();
        return Ok();
    }
}
