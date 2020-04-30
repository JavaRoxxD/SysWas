using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Usuarios
{
    public class Usuario : Entidade
    {
        

        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }



        public Usuario(int id, string email, string senha, string nome, string sobreNome)
        {
            Id = id;
            Email = email;
            Senha = senha;
            Nome = nome;
            SobreNome = sobreNome;
        }

        public Usuario() { }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Senha))
                AddMessageValidation("Digite sua senha!!");

            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificada a referencia desse item!!");


            
        }
    }
}
