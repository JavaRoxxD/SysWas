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

namespace SysWas.Web.Controllers.Bancos
{

    [Route("api/[Controller]")]
    public class BancoController : Controller
    {

        private readonly IBancoRepository _bancoRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public BancoController(IBancoRepository bancoRepository,
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _bancoRepository = bancoRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_bancoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Banco banco)
        {
            try
            {
                banco.Validate();
                if (!banco.isValidate)
                {

                    return BadRequest(banco.GetMessageValidation());

                }
                if (banco.Id > 0)
                {

                    _bancoRepository.Atualizar(banco);

                }
                else
                {

                    

                    _bancoRepository.Adicionar(banco);
                }

                return Created("api/banco", banco);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Banco banco)
        {
            try
            {

                _bancoRepository.Remover(banco);

                return Json(_bancoRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



    }
}
