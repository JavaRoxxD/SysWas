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
    public class DreController : Controller
    {
        private readonly IDreRepository _dreRepository;


        public DreController(IDreRepository dreRepository)
        {

            _dreRepository = dreRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_dreRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Dre dre)
        {
            try
            {

                _dreRepository.Adicionar(dre);

                return Created("api/Dre", dre);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
