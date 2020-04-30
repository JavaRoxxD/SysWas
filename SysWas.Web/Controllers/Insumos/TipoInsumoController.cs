using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IInsumos;
using SysWas.Domain.Entidades.Insumos;

namespace SysWas.Web.Controllers.Insumos
{

    [Route("api/[Controller]")]
    public class TipoInsumoController : Controller
    {
        private readonly ITipoInsumoRepository _tipoInsumoRepository;


        public TipoInsumoController(ITipoInsumoRepository tipoInsumoRepository)
        {

            _tipoInsumoRepository = tipoInsumoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoInsumoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]TipoInsumo tipoInsumo)
        {
            try
            {

                _tipoInsumoRepository.Adicionar(tipoInsumo);

                return Created("api/TipoInsumo", tipoInsumo);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
