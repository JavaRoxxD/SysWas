using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IUtilitarios;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Web.Controllers.Compras
{

    [Route("api/[Controller]")]
    public class NotaFiscalController : Controller
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;


        public NotaFiscalController(INotaFiscalRepository notaFiscalRepository)
        {

            _notaFiscalRepository = notaFiscalRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_notaFiscalRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]NotaFiscal notaFiscal)
        {
            try
            {

                _notaFiscalRepository.Adicionar(notaFiscal);

                return Created("api/NotaFiscal", notaFiscal);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
