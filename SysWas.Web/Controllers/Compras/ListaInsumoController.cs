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
    public class ListaInsumoController : Controller
    {
        private readonly IListaInsumoRepository _listaInsumoRepository;


        public ListaInsumoController(IListaInsumoRepository listaInsumoRepository)
        {

            _listaInsumoRepository = listaInsumoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_listaInsumoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ListaInsumo listaInsumo)
        {
            try
            {

                _listaInsumoRepository.Adicionar(listaInsumo);

                return Created("api/ListaInsumo", listaInsumo);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
