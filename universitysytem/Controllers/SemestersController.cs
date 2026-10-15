using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;
[ApiController]
[Route("[controller]")]
public class SemestersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public SemestersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Semesters> GetSemesters()
    {
        return _context.Semesters.ToList();
    }
}
