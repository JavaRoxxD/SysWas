using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IFinanceiro;
using SysWas.Domain.Entidades.Financeiro;

namespace SysWas.Web.Controllers.Financeiro
{

    [Route("api/[Controller]")]
    public class ListaBancoEmpresaController : Controller
    {
        private readonly IListaBancoEmpresaRepository _listaBancoEmpresaRepository;


        public ListaBancoEmpresaController(IListaBancoEmpresaRepository listaBancoEmpresaRepository)
        {

            _listaBancoEmpresaRepository = listaBancoEmpresaRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_listaBancoEmpresaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ListaBancoEmpresa listaBancoEmpresa)
        {
            try
            {

                _listaBancoEmpresaRepository.Adicionar(listaBancoEmpresa);

                return Created("api/ListaBancoEmpresa", listaBancoEmpresa);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
