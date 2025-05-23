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
    public class ModelosController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ModelosController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Modelo> modelos = _db.Modelos.Include(i => i.Marca).ToList();
            return Ok(modelos);
        }

        [HttpGet("{CodigoModelo}")]
        public IActionResult GetById(int CodigoModelo)
        {
            Modelo modelo = _db.Modelos.Include(i => i.Marca).FirstOrDefault(f => f.CodigoModelo == CodigoModelo);
            if (modelo == null)
                return NotFound();
            return Ok(modelo);
        }

        [HttpPost]
        public IActionResult CreateModelo([FromBody] Modelo modelo)
        {
            if (!ModelState.IsValid)
                return BadRequest("ERRO! Modelo Informado Com Problemas");
            _db.Modelos.Add(modelo);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), modelo.CodigoModelo, new {modelo});
        }

        [HttpPut("{CodigoModelo}")]
        public IActionResult UpdateModelo([FromBody] Modelo modelo, int CodigoModelo)
        {
            if (!ModelState.IsValid || CodigoModelo != modelo.CodigoModelo)
                return BadRequest("ERRO! Modelo Informado Com Problemas");
            _db.Modelos.Update(modelo);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{CodigoModelo}")]
        public IActionResult DeleteModelo(int CodigoModelo)
        {
            Modelo modelo = _db.Modelos.Where(w => w.CodigoModelo == CodigoModelo).FirstOrDefault();
            if (modelo == null)
                return NotFound("Modelo Não Encontrado!");
            _db.Modelos.Remove(modelo);
            _db.SaveChanges();
            return NoContent();
        } 
    }
}