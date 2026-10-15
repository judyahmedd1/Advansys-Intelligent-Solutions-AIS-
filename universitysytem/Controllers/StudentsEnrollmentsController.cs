using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;
[ApiController]
[Route("[controller]")]
public class Students_EnrollmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public Students_EnrollmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Students_Enrollments> GetStudents_Enrollments()
    {
        return _context.Students_Enrollments.ToList();
    }
}
