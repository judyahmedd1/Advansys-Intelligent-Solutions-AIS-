using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers;
[ApiController]
[Route("[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public PaymentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Payments> GetPayments()
    {
        return _context.Payments.ToList();
    }
}