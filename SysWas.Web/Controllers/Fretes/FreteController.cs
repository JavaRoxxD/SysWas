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
    public class FreteController : Controller
    {
        private readonly IFreteRepository _freteRepository;


        public FreteController(IFreteRepository freteRepository)
        {

            _freteRepository = freteRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_freteRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Frete frete)
        {
            try
            {

                _freteRepository.Adicionar(frete);

                return Created("api/Frete", frete);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
