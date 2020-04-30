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

namespace SysWas.Web.Controllers.ControleMadeiras
{

    [Route("api/[Controller]")]
    public class ControleMadeiraController : Controller
    {

        private readonly IControleMadeiraRepository _controleMadeiraRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public ControleMadeiraController(IControleMadeiraRepository controleMadeiraRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _controleMadeiraRepository = controleMadeiraRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_controleMadeiraRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]ControleMadeira controleMadeira)
        {
            try
            {
                controleMadeira.Validate();
                if (!controleMadeira.isValidate)
                {

                    return BadRequest(controleMadeira.GetMessageValidation());

                }
                if (controleMadeira.Id > 0)
                {

                    _controleMadeiraRepository.Atualizar(controleMadeira);

                }
                else
                {

                    _controleMadeiraRepository.Adicionar(controleMadeira);
                }

                return Created("api/controleMadeira", controleMadeira);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]ControleMadeira controleMadeira)
        {
            try
            {

                _controleMadeiraRepository.Remover(controleMadeira);

                return Json(_controleMadeiraRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }






    }
}
