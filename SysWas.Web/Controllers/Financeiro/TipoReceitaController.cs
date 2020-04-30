using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IFinanceiro;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Web.Controllers.Financeiro
{

    [Route("api/[Controller]")]
    public class TipoReceitaController : Controller
    {
        private readonly ITipoReceitaRepository _tipoReceitaRepository;


        public TipoReceitaController(ITipoReceitaRepository tipoReceitaRepository)
        {

            _tipoReceitaRepository = tipoReceitaRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoReceitaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]TipoReceita tipoReceita)
        {
            try
            {

                _tipoReceitaRepository.Adicionar(tipoReceita);

                return Created("api/TipoReceita", tipoReceita);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
