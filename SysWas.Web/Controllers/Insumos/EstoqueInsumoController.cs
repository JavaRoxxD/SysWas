using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SysWas.Domain.Contratos.IInsumos;
using SysWas.Domain.Entidades.Insumos;

namespace SysWas.Web.Controllers.EstoqueInsumos
{

    [Route("api/[Controller]")]
    public class EstoqueInsumoController : Controller
    {

        private readonly IEstoqueInsumoRepository _estoqueInsumoRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public EstoqueInsumoController(IEstoqueInsumoRepository estoqueInsumoRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _estoqueInsumoRepository = estoqueInsumoRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_estoqueInsumoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]EstoqueInsumo estoqueInsumo)
        {
            try
            {
                estoqueInsumo.Validate();
                if (!estoqueInsumo.isValidate)
                {

                    return BadRequest(estoqueInsumo.GetMessageValidation());

                }
                if (estoqueInsumo.Id > 0)
                {

                    _estoqueInsumoRepository.Atualizar(estoqueInsumo);

                }
                else
                {

                    estoqueInsumo.Item = null;

                    _estoqueInsumoRepository.Adicionar(estoqueInsumo);
                }

                return Created("api/estoqueInsumo", estoqueInsumo);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]EstoqueInsumo estoqueInsumo)
        {
            try
            {

                _estoqueInsumoRepository.Remover(estoqueInsumo);

                return Json(_estoqueInsumoRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }





       
        
    }
}
