using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IFornecedores;
using SysWas.Domain.Entidades.Fornecedores;

namespace SysWas.Web.Controllers.Fornecedores
{

    [Route("api/[Controller]")]
    public class ListaContatoController : Controller
    {
        private readonly IListaContatoRepository _listaContatoRepository;


        public ListaContatoController(IListaContatoRepository listaContatoRepository)
        {

            _listaContatoRepository = listaContatoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_listaContatoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ListaContato listaContato)
        {
            try
            {

                _listaContatoRepository.Adicionar(listaContato);

                return Created("api/ListaContato", listaContato);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
