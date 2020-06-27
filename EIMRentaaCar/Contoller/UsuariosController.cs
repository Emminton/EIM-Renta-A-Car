using System.Collections.Generic;
using EIMRentaaCar.BLL;
using EIMRentaaCar.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EIMRentaaCar.Contoller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/<UsuariosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public ActionResult<Usuarios> Get(int id)
        {
            return UsuarioBLL.Buscar(id);
        }

        // POST api/<UsuariosController>
        [HttpPost]
        public  ActionResult Post([FromBody] Usuarios usuarios)
        {
            

            UsuarioBLL.Guardar(usuarios);

            return Ok();
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
