using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using SysWas.Domain.Contratos.IFretes;
using SysWas.Domain.Entidades.Fretes;

namespace SysWas.Web.Controllers.Fretes

{

    [Route("api/[Controller]")]
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepository _veiculoRepository;


        public VeiculoController(IVeiculoRepository veiculoRepository)
        {

            _veiculoRepository = veiculoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_veiculoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Veiculo veiculo)
        {
            try
            {

                _veiculoRepository.Adicionar(veiculo);

                return Created("api/Veiculo", veiculo);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
