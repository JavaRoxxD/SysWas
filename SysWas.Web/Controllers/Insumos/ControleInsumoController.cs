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
    public class ControleInsumoController : Controller
    {
        private readonly IControleInsumoRepository _controleInsumoRepository;


        public ControleInsumoController(IControleInsumoRepository controleInsumoRepository)
        {

            _controleInsumoRepository = controleInsumoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_controleInsumoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ControleInsumo controleInsumo)
        {
            try
            {

                _controleInsumoRepository.Adicionar(controleInsumo);

                return Created("api/ControleInsumo", controleInsumo);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
