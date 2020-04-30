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
    public class TipoFornecedorController : Controller
    {
        private readonly ITipoFornecedorRepository _tipoFornecedorRepository;


        public TipoFornecedorController(ITipoFornecedorRepository tipoFornecedorRepository)
        {

            _tipoFornecedorRepository = tipoFornecedorRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tipoFornecedorRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]TipoFornecedor tipoFornecedor)
        {
            try
            {

                _tipoFornecedorRepository.Adicionar(tipoFornecedor);

                return Created("api/TipoFornecedor", tipoFornecedor);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
