using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.ICEP;
using SysWas.Domain.Entidades.CEP;

namespace SysWas.Web.Controllers.CEP
{

    [Route("api/[Controller]")]
    public class EstadoController : Controller
    {
        private readonly IEstadoRepository _estadoRepository;


        public EstadoController(IEstadoRepository estadoRepository)
        {

            _estadoRepository = estadoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_estadoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Estado estado)
        {
            try
            {

                _estadoRepository.Adicionar(estado);

                return Created("api/Estado", estado);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
