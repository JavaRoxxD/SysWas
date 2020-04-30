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
    public class MadeiraController : Controller
    {
        
        private readonly IMadeiraRepository _madeiraRepository;

        private IHttpContextAccessor _httpContextAccessor;

        private IHostingEnvironment _hostingEnvironment;

        public MadeiraController(IMadeiraRepository madeiraRepository, 
                                 IHttpContextAccessor httpContextAccessor,
                                 IHostingEnvironment hostingEnvironment)
        {

            _madeiraRepository = madeiraRepository;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_madeiraRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Madeira madeira)
        {
            try
            {
                madeira.Validate();
                if (!madeira.isValidate) {

                    return BadRequest(madeira.GetMessageValidation());
                
                }
                if(madeira.Id > 0)
                {
                    
                    _madeiraRepository.Atualizar(madeira);

                }
                else
                {

                    madeira.Tipo = null;
                    madeira.Especie = null;
                    madeira.Controle = null;

                    _madeiraRepository.Adicionar(madeira);
                }

                return Created("api/madeira", madeira);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }



        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Madeira madeira)
        {
            try
            {

                _madeiraRepository.Remover(madeira);

                return Json(_madeiraRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }





        [HttpPost("enviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {

                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];

                var nomeArquivo = formFile.FileName;

                string novoNomeArquivo = GerarNovoNomeArquivo(nomeArquivo);

                var pastaArquivos = _hostingEnvironment.WebRootPath + "\\notafiscal\\";


                //nome final com a extensao 
                var nomeCompleto = pastaArquivos + novoNomeArquivo;

                using (var streamArquivo = new FileStream(nomeCompleto, FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }

                return Json(novoNomeArquivo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        private static string GerarNovoNomeArquivo(string nomeArquivo)
        {
            var extensao = nomeArquivo.Split(".").Last();

            //var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();

            //var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-");

            var novoNomeArquivo = $"{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}_{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}{DateTime.Now.Millisecond}.{extensao}";
            return novoNomeArquivo;
        }
    }
}
