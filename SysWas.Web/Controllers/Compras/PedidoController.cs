using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.ICompras;
using SysWas.Domain.Entidades.Compras;

namespace SysWas.Web.Controllers.Compras
{

    [Route("api/[Controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;


        public PedidoController(IPedidoRepository pedidoRepository)
        {

            _pedidoRepository = pedidoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_pedidoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            try
            {

                _pedidoRepository.Adicionar(pedido);

                return Created("api/Pedido", pedido);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
