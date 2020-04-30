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

namespace SysWas.Web.Controllers.Insumos
{

    [Route("api/[Controller]")]
    public class InsumoController : Controller
    {

        private readonly IInsumoRepository _insumoRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public InsumoController(IInsumoRepository insumoRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _insumoRepository = insumoRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_insumoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Insumo insumo)
        {
            try
            {
                insumo.Validate();
                if (!insumo.isValidate)
                {

                    return BadRequest(insumo.GetMessageValidation());

                }
                if (insumo.Id > 0)
                {

                    _insumoRepository.Atualizar(insumo);

                }
                else
                {

                    insumo.Tipo = null;
                    insumo.Controle = null;

                    _insumoRepository.Adicionar(insumo);
                }

                return Created("api/insumo", insumo);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Insumo insumo)
        {
            try
            {

                _insumoRepository.Remover(insumo);

                return Json(_insumoRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



    }
}
