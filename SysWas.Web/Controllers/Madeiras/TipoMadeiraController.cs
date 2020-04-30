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

namespace SysWas.Web.Controllers.TipoMadeiras
{

    [Route("api/[Controller]")]
    public class TipoMadeiraController : Controller
    {

        private readonly ITipoMadeiraRepository _tipoMadeiraRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public TipoMadeiraController(ITipoMadeiraRepository tipoMadeiraRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _tipoMadeiraRepository = tipoMadeiraRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_tipoMadeiraRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]TipoMadeira tipoMadeira)
        {
            try
            {
                tipoMadeira.Validate();
                if (!tipoMadeira.isValidate)
                {

                    return BadRequest(tipoMadeira.GetMessageValidation());

                }
                if (tipoMadeira.Id > 0)
                {

                    _tipoMadeiraRepository.Atualizar(tipoMadeira);

                }
                else
                {

                    _tipoMadeiraRepository.Adicionar(tipoMadeira);
                }

                return Created("api/tipoMadeira", tipoMadeira);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]TipoMadeira tipoMadeira)
        {
            try
            {

                _tipoMadeiraRepository.Remover(tipoMadeira);

                return Json(_tipoMadeiraRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }






    }
}
