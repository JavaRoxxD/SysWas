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
    public class TipoCustoController : Controller
    {
        private readonly ITipoCustoRepository _tipoCustoRepository;


        public TipoCustoController(ITipoCustoRepository tipoCustoRepository)
        {

            _tipoCustoRepository = tipoCustoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoCustoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]TipoCusto tipoCusto)
        {
            try
            {

                _tipoCustoRepository.Adicionar(tipoCusto);

                return Created("api/TipoCusto", tipoCusto);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
