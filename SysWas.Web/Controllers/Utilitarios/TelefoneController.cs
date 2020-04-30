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
    public class TelefoneController : Controller
    {
        private readonly ITelefoneRepository _telefoneRepository;


        public TelefoneController(ITelefoneRepository telefoneRepository)
        {

            _telefoneRepository = telefoneRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_telefoneRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Telefone telefone)
        {
            try
            {

                _telefoneRepository.Adicionar(telefone);

                return Created("api/Telefone", telefone);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
