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
    public class ItemTabelaFreteController : Controller
    {
        private readonly IItemTabelaFreteRepository _itemTabelaFreteRepository;


        public ItemTabelaFreteController(IItemTabelaFreteRepository itemTabelaFreteRepository)
        {

            _itemTabelaFreteRepository = itemTabelaFreteRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_itemTabelaFreteRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ItemTabelaFrete itemTabelaFrete)
        {
            try
            {

                _itemTabelaFreteRepository.Adicionar(itemTabelaFrete);

                return Created("api/ItemTabelaFrete", itemTabelaFrete);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
