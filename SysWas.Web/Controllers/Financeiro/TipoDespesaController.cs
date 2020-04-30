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
    public class TipoDespesaController : Controller
    {
        private readonly ITipoDespesaRepository _tipoDespesaRepository;


        public TipoDespesaController(ITipoDespesaRepository tipoDespesaRepository)
        {

            _tipoDespesaRepository = tipoDespesaRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoDespesaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]TipoDespesa tipoDespesa)
        {
            try
            {

                _tipoDespesaRepository.Adicionar(tipoDespesa);

                return Created("api/TipoDespesa", tipoDespesa);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
