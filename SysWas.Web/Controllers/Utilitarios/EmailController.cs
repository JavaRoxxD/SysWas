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

namespace SysWas.Web.Controllers.Emails
{

    [Route("api/[Controller]")]
    public class EmailController : Controller
    {

        private readonly IEmailRepository _emailRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public EmailController(IEmailRepository emailRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _emailRepository = emailRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_emailRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Email email)
        {
            try
            {
                email.Validate();
                if (!email.isValidate)
                {

                    return BadRequest(email.GetMessageValidation());

                }
                if (email.Id > 0)
                {

                    _emailRepository.Atualizar(email);

                }
                else
                {

                   

                    _emailRepository.Adicionar(email);
                }

                return Created("api/email", email);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Email email)
        {
            try
            {

                _emailRepository.Remover(email);

                return Json(_emailRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



    }
}
