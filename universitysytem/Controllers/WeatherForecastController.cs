using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace universitysytem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDbContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        
        public List<Departments> GetAll()
        {
            return _context.Departments.ToList();
            
        }
        [HttpPost]
        public int Sum()
        {
            return 1 + 2;
        }
    }
}
