using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SysWas.Domain.Contratos.IEmpresas;
using SysWas.Domain.Entidades.Empresas;

namespace SysWas.Web.Controllers.Empresas
{

    [Route("api/[Controller]")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaRepository _empresaRepository;


        public EmpresaController(IEmpresaRepository empresaRepository)
        {

            _empresaRepository = empresaRepository;

        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_empresaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

        [HttpPost]
        public IActionResult Post([FromBody]Empresa empresa)
        {
            try
            {


                empresa.Validate();
                if (!empresa.isValidate)
                {

                    return BadRequest(empresa.GetMessageValidation());

                }
                if (empresa.Id > 0)
                {

                    _empresaRepository.Atualizar(empresa);

                }
                else
                {
                    var endereco = empresa.Endereco;
                    empresa.Endereco = null;
                    empresa.EnderecoId = endereco.Id;
                    
                    _empresaRepository.Adicionar(empresa);
                }


                return Created("api/Empresa", empresa);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody]Empresa empresa)
        {
            try
            {


                empresa.Validate();
                if (!empresa.isValidate)
                {

                    return BadRequest(empresa.GetMessageValidation());

                }
                if (empresa.Id > 0)
                {

                    _empresaRepository.Atualizar(empresa);

                }
                else
                {
                    var endereco = empresa.Endereco;
                    empresa.Endereco = null;
                    empresa.EnderecoId = endereco.Id;

                    _empresaRepository.Adicionar(empresa);
                }


                return Created("api/Empresa", empresa);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }


        }

    }
}
