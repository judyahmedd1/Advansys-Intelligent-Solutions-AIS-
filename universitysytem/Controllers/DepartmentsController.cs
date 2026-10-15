using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;
[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public DepartmentsController(ApplicationDbContext context) { 
        _context = context;
    }

    [HttpGet]
    public List<Departments> GetDepartments()
    {
        return _context.Departments.ToList() ;
    }
}
