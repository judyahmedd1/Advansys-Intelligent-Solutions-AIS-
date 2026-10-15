using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;
[ApiController]
[Route("[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public EnrollmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Enrollments> GetEnrollments()
    {
        return _context.Enrollments.ToList();
    }
}
