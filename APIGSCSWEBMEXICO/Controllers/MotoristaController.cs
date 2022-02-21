using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGSCSWEBMEXICO.Models;
using Microsoft.AspNetCore.Http;
using APIGSCSWEBMEXICO.Service.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using APIGSCSWEBMEXICO.Util;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIGSCSWEBMEXICO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoristaController : ControllerBase
    {
        public readonly IMotoristaService _motoristaService;

        public  MotoristaController(IMotoristaService motoristaService)
        {
            _motoristaService = motoristaService;
        }

        //// GET: api/<MotoristaController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<MotoristaController>/5
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Motoristas))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
     
        public IActionResult Get([FromQuery] int id, string nome)
        {
            var motorista = _motoristaService.GetMotoristaById(id, nome);

            if (motorista.Result == null)
            {
                var msg = new Mensagem()
                {
                    Msg = "Motorista não encontrado"
                };
                return NotFound(msg);
            }

            return Ok(motorista.Result);
        }
        
        // POST api/<MotoristaController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Motoristas))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public string PostMotorista([FromBody] Models.MotoristaModel value)
        {
            int id = value.IdMotorista;
            string nome = value.Nome;
            string cpf = value.Cpf;
            string telefone = value.Telefone;
            bool ativo = value.Ativo;
            string codPais = value.CodPais;
            int fingerPrint = value.Fingerprint;
            int signature = value.Signature;
            int driver = value.driver;
            DateTime driverDate = value.DriverDate;
            string status = value.StatusMotorista;
            string dataCad = value.DataCadastro;
            

            var inserir = new Service.InserirMotoristaService();
            var retorno = inserir.PostMotorista(nome, cpf, telefone, ativo, codPais, fingerPrint.ToString(), signature.ToString(), driver.ToString(), driverDate.ToString());

            return retorno;

        }

        // PUT api/<MotoristaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MotoristaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
