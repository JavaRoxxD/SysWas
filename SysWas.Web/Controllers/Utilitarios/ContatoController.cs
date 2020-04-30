using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SysWas.Domain.Contratos.IUtilitarios;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Web.Controllers.Contatos
{

    [Route("api/[Controller]")]
    public class ContatoController : Controller
    {

        private readonly IContatoRepository _contatoRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public ContatoController(IContatoRepository contatoRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _contatoRepository = contatoRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_contatoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Contato contato)
        {
            try
            {
                contato.Validate();
                if (!contato.isValidate)
                {

                    return BadRequest(contato.GetMessageValidation());

                }
                if (contato.Id > 0)
                {

                    _contatoRepository.Atualizar(contato);

                }
                else
                {

                    contato.Lista = null;

                    _contatoRepository.Adicionar(contato);
                }

                return Created("api/contato", contato);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Contato contato)
        {
            try
            {

                _contatoRepository.Remover(contato);

                return Json(_contatoRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



    }
}
