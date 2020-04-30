using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IUsuarios;
using SysWas.Domain.Entidades.Usuarios;

namespace SysWas.Web.Controllers.Usuarios
{

    [Route("api/[Controller]")]
    public class HistoricoController : Controller
    {
        private readonly IHistoricoRepository _historicoRepository;


        public HistoricoController(IHistoricoRepository historicoRepository)
        {

            _historicoRepository = historicoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_historicoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Historico historico)
        {
            try
            {

                _historicoRepository.Adicionar(historico);

                return Created("api/Historico", historico);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
