using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GranVeiculos.Data;
using GranVeiculos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GranVeiculos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoresController(AppDbContext db) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Cor> cores = db.Cores.ToList();
            return Ok(cores);
        }

        [HttpGet("{CodigoCor}")]
        public IActionResult GetById(int codigoCor)
        {
            Cor cor = db.Cores.Where(w => w.CodigoCor == codigoCor).FirstOrDefault();
            if (cor == null)
                return NotFound();
            return Ok(cor);
        }

        [HttpPost]
        public IActionResult CreateCor([FromBody] Cor cor)
        {
            if (!ModelState.IsValid)
                return BadRequest("ERRO!");
            db.Cores.Add(cor);
            db.SaveChanges();
            return Ok(cor);
        }

        [HttpPut("{CodigoCor}")]
        public IActionResult UpdateCor([FromBody] Cor cor, int CodigoCor)
        {
            if (!ModelState.IsValid || CodigoCor != cor.CodigoCor)
                return BadRequest("ERRO!");
            db.Cores.Update(cor);
            db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{CodigoCor}")]
        public IActionResult DeleteCor(int CodigoCor)
        {
            var cor = db.Cores.Where(w => w.CodigoCor == CodigoCor).FirstOrDefault();
            db.Cores.Remove(cor);
            db.SaveChanges();
            return NoContent();
        } 
    }
}