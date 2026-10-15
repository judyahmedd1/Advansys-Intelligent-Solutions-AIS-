using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ClassroomsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Classrooms> GetClassrooms()
    {
        return _context.Classrooms.ToList();
    }
}
