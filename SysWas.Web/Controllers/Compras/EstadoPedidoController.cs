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
    public class EstadoPedidoController : Controller
    {
        private readonly IEstadoPedidoRepository _estadoPedidoRepository;


        public EstadoPedidoController(IEstadoPedidoRepository estadoPedidoRepository)
        {

            _estadoPedidoRepository = estadoPedidoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estadoPedidoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]EstadoPedido estadoPedido)
        {
            try
            {

                _estadoPedidoRepository.Adicionar(estadoPedido);

                return Created("api/EstadoPedido", estadoPedido);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
