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
    public class ControleSaldoController : Controller
    {
        private readonly IControleSaldoRepository _controleSaldoRepository;


        public ControleSaldoController(IControleSaldoRepository controleSaldoRepository)
        {

            _controleSaldoRepository = controleSaldoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_controleSaldoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ControleSaldo controleSaldo)
        {
            try
            {

                _controleSaldoRepository.Adicionar(controleSaldo);

                return Created("api/ControleSaldo", controleSaldo);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
