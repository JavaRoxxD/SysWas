using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using SysWas.Domain.Contratos.IFretes;
using SysWas.Domain.Entidades.Fretes;

namespace SysWas.Web.Controllers.Fretes

{

    [Route("api/[Controller]")]
    public class TransportadoraController : Controller
    {
        private readonly ITransportadoraRepository _transportadoraRepository;


        public TransportadoraController(ITransportadoraRepository transportadoraRepository)
        {

            _transportadoraRepository = transportadoraRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_transportadoraRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Transportadora transportadora)
        {
            try
            {

                _transportadoraRepository.Adicionar(transportadora);

                return Created("api/Transportadora", transportadora);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
