using APIGSCSWEBMEXICO.Service;
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
    public class TransportadoraController : ControllerBase
    {
        public readonly ITransportadoraService _transportadoraService;

        public TransportadoraController(ITransportadoraService transportadoraService)
        {
            _transportadoraService = transportadoraService;
        }


        // GET: api/<TransportadoraController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TransportadoraController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Transportadoras))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
            public IActionResult Get(int id)
            {
                var transportadora = _transportadoraService.GetTransportadoraById(id);

                if (transportadora == null)
                {
                    var msg = new Mensagem()
                    {
                        Msg = "Transportadora não encontrada"
                    };
                    return NotFound(msg);
                }

                return Ok(transportadora.Result);
            }
           

            // POST api/<TransportadoraController>
            [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TransportadoraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransportadoraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
