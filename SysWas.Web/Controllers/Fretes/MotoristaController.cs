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
    public class MotoristaController : Controller
    {
        private readonly IMotoristaRepository _motoristaRepository;


        public MotoristaController(IMotoristaRepository motoristaRepository)
        {

            _motoristaRepository = motoristaRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_motoristaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Motorista motorista)
        {
            try
            {

                _motoristaRepository.Adicionar(motorista);

                return Created("api/Motorista", motorista);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
