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
    public class LogRegController : Controller
    {
        private readonly ILogRegRepository _logRegRepository;


        public LogRegController(ILogRegRepository logRegRepository)
        {

            _logRegRepository = logRegRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_logRegRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]LogReg logReg)
        {
            try
            {

                _logRegRepository.Adicionar(logReg);

                return Created("api/LogReg", logReg);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
