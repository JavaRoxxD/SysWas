using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SysWas.Domain.Contratos.IMadeiras;
using SysWas.Domain.Entidades.Madeiras;

namespace SysWas.Web.Controllers.Lotes
{

    [Route("api/[Controller]")]
    public class LoteController : Controller
    {

        private readonly ILoteRepository _loteRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public LoteController(ILoteRepository loteRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _loteRepository = loteRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_loteRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Lote lote)
        {
            try
            {
                lote.Validate();
                if (!lote.isValidate)
                {

                    return BadRequest(lote.GetMessageValidation());

                }
                if (lote.Id > 0)
                {
                    lote.Pedido = null;
                    _loteRepository.Atualizar(lote);

                }
                else
                {

                    _loteRepository.Adicionar(lote);
                }

                return Created("api/lote", lote);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Lote lote)
        {
            try
            {

                _loteRepository.Remover(lote);

                return Json(_loteRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }






    }
}
