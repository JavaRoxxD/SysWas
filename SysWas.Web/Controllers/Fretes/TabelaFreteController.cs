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
    public class TabelaFreteController : Controller
    {
        private readonly ITabelaFreteRepository _tabelaFreteRepository;


        public TabelaFreteController(ITabelaFreteRepository tabelaFreteRepository)
        {

            _tabelaFreteRepository = tabelaFreteRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tabelaFreteRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]TabelaFrete tabelaFrete)
        {
            try
            {

                _tabelaFreteRepository.Adicionar(tabelaFrete);

                return Created("api/TabelaFrete", tabelaFrete);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
