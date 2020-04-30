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

namespace SysWas.Web.Controllers.Madeiras
{

    [Route("api/[Controller]")]
    public class EspecieMadeiraController : Controller
    {

        private readonly IEspecieMadeiraRepository _especieMadeiraRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public EspecieMadeiraController(IEspecieMadeiraRepository especieMadeiraRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _especieMadeiraRepository = especieMadeiraRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_especieMadeiraRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]EspecieMadeira especieMadeira)
        {
            try
            {
                especieMadeira.Validate();
                if (!especieMadeira.isValidate)
                {

                    return BadRequest(especieMadeira.GetMessageValidation());

                }
                if (especieMadeira.Id > 0)
                {

                    _especieMadeiraRepository.Atualizar(especieMadeira);

                }
                else
                {

                    _especieMadeiraRepository.Adicionar(especieMadeira);
                }

                return Created("api/especieMadeira", especieMadeira);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]EspecieMadeira especieMadeira)
        {
            try
            {

                _especieMadeiraRepository.Remover(especieMadeira);

                return Json(_especieMadeiraRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }





       
    }
}
