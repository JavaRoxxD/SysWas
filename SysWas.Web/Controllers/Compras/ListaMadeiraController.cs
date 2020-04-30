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
    public class ListaMadeiraController : Controller
    {
        private readonly IListaMadeiraRepository _listaMadeiraRepository;


        public ListaMadeiraController(IListaMadeiraRepository listaMadeiraRepository)
        {

            _listaMadeiraRepository = listaMadeiraRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_listaMadeiraRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ListaMadeira listaMadeira)
        {
            try
            {

                _listaMadeiraRepository.Adicionar(listaMadeira);

                return Created("api/ListaMadeira", listaMadeira);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
