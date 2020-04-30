using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IUtilitarios;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Web.Controllers.Utilitarios
{

    [Route("api/[Controller]")]
    public class EstadoAprovacaoController : Controller
    {
        private readonly IEstadoAprovacaoRepository _estadoAprovacaoRepository;


        public EstadoAprovacaoController(IEstadoAprovacaoRepository estadoAprovacaoRepository)
        {

            _estadoAprovacaoRepository = estadoAprovacaoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estadoAprovacaoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]EstadoAprovacao estadoAprovacao)
        {
            try
            {

                _estadoAprovacaoRepository.Adicionar(estadoAprovacao);

                return Created("api/EstadoAprovacao", estadoAprovacao);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
