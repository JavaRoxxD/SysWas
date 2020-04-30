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
    public class FornecedorController : Controller
    {
        private readonly IFornecedorRepository _fornecedorRepository;


        public FornecedorController(IFornecedorRepository fornecedorRepository)
        {

            _fornecedorRepository = fornecedorRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_fornecedorRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Fornecedor fornecedor)
        {
            try
            {

                _fornecedorRepository.Adicionar(fornecedor);

                return Created("api/Fornecedor", fornecedor);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
