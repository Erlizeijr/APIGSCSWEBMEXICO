using APIGSCSWEBMEXICO.Service.Interfaces;
using APIGSCSWEBMEXICO.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIGSCSWEBMEXICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        public readonly IUnidadeService _unidadeService;

        public UnidadeController(IUnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }


        // GET: api/<UnidadeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UnidadeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Unidades))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var unidade = _unidadeService.GetUnidadeId(id);

            if (unidade == null)
            {
                var msg = new Mensagem()
                {
                    Msg = "Unidade não encontrada"
                };
                return NotFound(msg);
            }

            return Ok(unidade.Result);
        }
        
            // POST api/<UnidadeController>
            [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UnidadeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnidadeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
