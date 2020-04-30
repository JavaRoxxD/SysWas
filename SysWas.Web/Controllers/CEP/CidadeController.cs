using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SysWas.Domain.Contratos.ICEP;
using SysWas.Domain.Entidades.CEP;

namespace SysWas.Web.Controllers.CEP
{

    [Route("api/[Controller]")]
    public class CidadeController : Controller
    {
        private readonly ICidadeRepository _cidadeRepository;


        public CidadeController(ICidadeRepository cidadeRepository)
        {

            _cidadeRepository = cidadeRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_cidadeRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }
        
        [HttpPost("VerificarEstado")]
        public IActionResult VerificarEstado([FromBody]int uf)
        {
            try
            {
                
                return Json(_cidadeRepository.Obter(uf));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]Cidade cidade)
        {
            try
            {

                _cidadeRepository.Adicionar(cidade);

                return Created("api/Cidade", cidade);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
