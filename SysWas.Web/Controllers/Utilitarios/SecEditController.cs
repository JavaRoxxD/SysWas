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
    public class SecEditController : Controller
    {
        private readonly ISecEditRepository _secEditRepository;


        public SecEditController(ISecEditRepository secEditRepository)
        {

            _secEditRepository = secEditRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_secEditRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]SecEdit secEdit)
        {
            try
            {

                _secEditRepository.Adicionar(secEdit);

                return Created("api/SecEdit", secEdit);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
