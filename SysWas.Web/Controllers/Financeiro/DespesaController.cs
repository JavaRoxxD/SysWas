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
    public class DespesaController : Controller
    {
        private readonly IDespesaRepository _despesaRepository;


        public DespesaController(IDespesaRepository despesaRepository)
        {

            _despesaRepository = despesaRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_despesaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Despesa despesa)
        {
            try
            {

                _despesaRepository.Adicionar(despesa);

                return Created("api/Despesa", despesa);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
