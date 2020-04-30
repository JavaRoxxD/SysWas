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
    public class PermissaoController : Controller
    {
        private readonly IPermissaoRepository _permissaoRepository;


        public PermissaoController(IPermissaoRepository permissaoRepository)
        {

            _permissaoRepository = permissaoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_permissaoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Permissao permissao)
        {
            try
            {

                _permissaoRepository.Adicionar(permissao);

                return Created("api/Permissao", permissao);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
