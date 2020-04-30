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
    public class ListaBancariaController : Controller
    {
        private readonly IListaBancariaRepository _listaBancariaRepository;


        public ListaBancariaController(IListaBancariaRepository listaBancariaRepository)
        {

            _listaBancariaRepository = listaBancariaRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_listaBancariaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ListaBancaria listaBancaria)
        {
            try
            {

                _listaBancariaRepository.Adicionar(listaBancaria);

                return Created("api/ListaBancaria", listaBancaria);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
