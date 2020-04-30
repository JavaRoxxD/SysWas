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
    public class ReceitaController : Controller
    {
        private readonly IReceitaRepository _receitaRepository;


        public ReceitaController(IReceitaRepository receitaRepository)
        {

            _receitaRepository = receitaRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_receitaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Receita receita)
        {
            try
            {

                _receitaRepository.Adicionar(receita);

                return Created("api/Receita", receita);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
