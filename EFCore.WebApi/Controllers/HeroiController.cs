using EFCore.Domain;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public ActionResult Post()
        {
            try
            {
                var heroi = new Heroi
                {
                    Nome = "Batman",
                    Armas = new List<Arma>
                    {
                        new Arma { Nome = "Kunai" },
                    }
                };

                _context.Herois.Add(heroi);
                _context.SaveChanges();

                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }
    }
}
