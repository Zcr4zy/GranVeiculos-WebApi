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
        private readonly AppDbContext _db = db;

        [HttpGet]
        public IActionResult Get()
        {
            List<Cor> cores = _db.Cores.ToList();
            return Ok(cores);
        }

        [HttpGet("{CodigoCor}")]
        public IActionResult GetById(int CodigoCor)
        {
            Cor cor = _db.Cores.Where(w => w.CodigoCor == CodigoCor).FirstOrDefault();
            if (cor == null)
                return NotFound();
            return Ok(cor);
        }

        [HttpPost]
        public IActionResult CreateCor([FromBody] Cor cor)
        {
            if (!ModelState.IsValid)
                return BadRequest("ERRO! Cor Informada Com Problemas");
            _db.Cores.Add(cor);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), cor.CodigoCor, new {cor});
        }

        [HttpPut("{CodigoCor}")]
        public IActionResult UpdateCor([FromBody] Cor cor, int CodigoCor)
        {
            if (!ModelState.IsValid || CodigoCor != cor.CodigoCor)
                return BadRequest("ERRO! Cor Informada Com Problemas");
            _db.Cores.Update(cor);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{CodigoCor}")]
        public IActionResult DeleteCor(int CodigoCor)
        {
            var cor = _db.Cores.Where(w => w.CodigoCor == CodigoCor).FirstOrDefault();
            if (cor == null)
                return NotFound("Cor Não Encontrada!");
            _db.Cores.Remove(cor);
            _db.SaveChanges();
            return NoContent();
        } 
    }
}