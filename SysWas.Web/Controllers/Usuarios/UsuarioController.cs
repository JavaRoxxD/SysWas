using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IUsuarios;
using SysWas.Domain.Entidades.Usuarios;

namespace SysWas.Web.Controllers.Usuarios
{

    [Route("api/[Controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepository;


        public UsuarioController(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_usuarioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }


        [HttpPost("VerificarUsuario")]
        public IActionResult VerificarUsuario([FromBody] Usuario usuario)
        {
            try
            {

                var usuarioReturn = _usuarioRepository.Obter(usuario.Email, usuario.Senha);


                if (usuarioReturn != null)
                {
                    
                    return Ok(usuarioReturn);
                }
                return BadRequest("Usuario ou senha invalido!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }


        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioCadastrado = _usuarioRepository.Obter(usuario.Email);

                if(usuarioCadastrado != null)
                {

                    return BadRequest("Usuário já cadastrado!!");

                }

                _usuarioRepository.Adicionar(usuario);

                return Ok();
               // return Created("api/Usuario", usuario);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }




    }
}
