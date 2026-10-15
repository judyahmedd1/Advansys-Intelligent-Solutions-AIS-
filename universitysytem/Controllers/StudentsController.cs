using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;
[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public StudentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Students> GetStudents()
    {
        return _context.Students.ToList();
    }
}