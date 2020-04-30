using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.ICEP;
using SysWas.Domain.Entidades.CEP;

namespace SysWas.Web.Controllers.CEP
{

    [Route("api/[Controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;


        public EnderecoController(IEnderecoRepository enderecoRepository)
        {

            _enderecoRepository = enderecoRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_enderecoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost("Deletar")]
        public IActionResult Deletar([FromBody]Endereco endereco)
        {
            try
            {

                _enderecoRepository.Remover(endereco);

                return Json(_enderecoRepository.ObterTodos());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost("VerificarEndereco")]
        public IActionResult VerificarEndereco([FromBody]string cep)
        {
            try
            {
                var enderecoCadastro = _enderecoRepository.Obter(cep);


                return Json(_enderecoRepository.Obter(cep));


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]Endereco endereco)
        {
            try
            {
                var enderecoCadastro = _enderecoRepository.Obter(endereco.Cep);

                if (enderecoCadastro != null)
                {


                    return Ok(enderecoCadastro);


                }
                else
                {
                    _enderecoRepository.Adicionar(endereco);

                    //return Created("api/endereco", endereco);
                    
                    return Ok(endereco);
                    
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
