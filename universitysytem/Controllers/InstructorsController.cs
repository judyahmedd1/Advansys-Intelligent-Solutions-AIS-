using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;
[ApiController]
[Route("[controller]")]
public class InstructorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public InstructorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Instructors> GetInstructors()
    {
        return _context.Instructors.ToList();
    }
}