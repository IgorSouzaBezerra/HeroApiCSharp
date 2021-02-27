using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroiController : ControllerBase
    {
        public readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var herois = _context.Herois;
                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
            
        }

        [HttpPost]
        public ActionResult Post([FromBody] Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }
    }
}
