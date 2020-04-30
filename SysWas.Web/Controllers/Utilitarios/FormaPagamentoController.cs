using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IUtilitarios;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Web.Controllers.Utilitarios
{

    [Route("api/[Controller]")]
    public class FormaPagamentoController : Controller
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;


        public FormaPagamentoController(IFormaPagamentoRepository formaPagamentoRepository)
        {

            _formaPagamentoRepository = formaPagamentoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_formaPagamentoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]FormaPagamento formaPagamento)
        {
            try
            {

                _formaPagamentoRepository.Adicionar(formaPagamento);

                return Created("api/FormaPagamento", formaPagamento);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
