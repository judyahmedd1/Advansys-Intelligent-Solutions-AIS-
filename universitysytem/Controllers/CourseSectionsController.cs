using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseSectionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CourseSectionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<CourseSections> GetCourseSections()
    {
        return _context.CourseSections.ToList();
    }
}
