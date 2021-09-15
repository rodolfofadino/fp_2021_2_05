using fiapweb.core.Contexts;
using fiapweb.core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fiapweb.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("Default")]
    public class PaisesController : Controller
    {
        private DataContext _context;
        public PaisesController(DataContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public List<Pais> Get()
        //{
        //    if (1 != 2)
        //    {
        //        //return NotFound();
        //         //throw new Exception();
        //    }

        //    return _context.Paises.ToList();
        //}


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    //use unanuth
        //    if (1 != 2)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_context.Paises.ToList());
        //}

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Pais>))]
        //[ProducesResponseType(404)]
        //public IActionResult Get()
        //{
        //    ////use unanuth
        //    //if (1 != 2)
        //    //{
        //    //    return NotFound();
        //    //}
        //    return Ok(_context.Paises.ToList());
        //}

        [HttpGet]
        public ActionResult<List<Pais>> Get()
        {
            return Ok(_context.Paises.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Pais> Get(int id)
        {
            var pais = _context.Paises.FirstOrDefault(a => a.Id == id);

            //var pais = _context.Paises.First(a => a.Id == id);
            //var pais = _context.Paises.Single(a => a.Id == id);
            ////select top 2 * from paises 
            //var pais = _context.Paises.SingleOrDefault(a => a.Id == id);

            if (pais == null)
                return NotFound();

            return pais;
        }

        [HttpPost]
        public ActionResult<Pais> Post(Pais pais)
        {
            //if (ModelState.IsValid)
            //{
                _context.Paises.Add(pais);
                _context.SaveChanges();
                return Created($"/api/paises/{pais.Id}", pais);
            //}
            //return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult<Pais> Put(int id, Pais pais)
        {
            if (ModelState.IsValid)
            {
                _context.Attach(pais);
                _context.SaveChanges();
                return Ok(pais);
            }
            return BadRequest(ModelState);
        }


        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var pais = _context.Paises.FirstOrDefault(t => t.Id == id);
            if (pais == null)
                return NotFound();

            _context.Paises.Remove(pais);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
