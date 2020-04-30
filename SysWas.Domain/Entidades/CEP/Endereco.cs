using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.CEP
{
    public class Endereco : Entidade
    {

        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        

        public override void Validate()
        {
            //if (this.Cep == 0)
            //    AddMessageValidation("Não foi identificado esse CEP!");
        }
    }
}
