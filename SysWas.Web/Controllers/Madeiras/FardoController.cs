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

namespace SysWas.Web.Controllers.FardoMadeiras
{

    [Route("api/[Controller]")]
    public class FardoMadeiraController : Controller
    {

        private readonly IFardoRepository _fardoMadeiraRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public FardoMadeiraController(IFardoRepository fardoMadeiraRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _fardoMadeiraRepository = fardoMadeiraRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_fardoMadeiraRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Fardo fardoMadeira)
        {
            try
            {
                fardoMadeira.Validate();
                if (!fardoMadeira.isValidate)
                {

                    return BadRequest(fardoMadeira.GetMessageValidation());

                }
                if (fardoMadeira.Id > 0)
                {

                    _fardoMadeiraRepository.Atualizar(fardoMadeira);

                }
                else
                {

                    _fardoMadeiraRepository.Adicionar(fardoMadeira);
                }

                return Created("api/fardoMadeira", fardoMadeira);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Fardo fardoMadeira)
        {
            try
            {

                _fardoMadeiraRepository.Remover(fardoMadeira);

                return Json(_fardoMadeiraRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }






    }
}
