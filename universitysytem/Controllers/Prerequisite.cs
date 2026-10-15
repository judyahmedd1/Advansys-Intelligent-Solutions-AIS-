using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;

[ApiController]
[Route("[controller]")]
public class PrerequisiteController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PrerequisiteController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Prerequisite> GetCoursePrerequisite()
    {
        return _context.Prerequisites.ToList();
    }
}
