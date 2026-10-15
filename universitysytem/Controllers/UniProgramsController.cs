using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;
[ApiController]
[Route("[controller]")]
public class UniProgramsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public UniProgramsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<UniPrograms> GetUniPrograms()
    {
        return _context.UniPrograms.ToList();
    }
}
