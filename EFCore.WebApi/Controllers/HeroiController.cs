using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HeroiController : ControllerBase
    {
        public readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult Post()
        {
            var heroi = new Heroi { Nome = "Homem de Ferro" };
            _context.Herois.Add(heroi);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult Get()
        {
            var herois = _context.Herois;
            return Ok(herois);
        }
    }
}
