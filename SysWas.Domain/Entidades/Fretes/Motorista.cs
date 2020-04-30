using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Entidades.Utilitarios;

namespace SysWas.Domain.Entidades.Fretes
{
    public class Motorista : Entidade
    {
        

        public int Id { get; set; }
        public string Nome { get; set; }
        public string NumCnh { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public int SexoId { get; set; }
        public virtual Sexo Sexo { get; set; }


        public Motorista() { }

        public Motorista(int id, string nome, string numCnh, string cpf, string rg, DateTime dataNascimento, Sexo tipoSexo)
        {
            Id = id;
            Nome = nome;
            NumCnh = numCnh;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
            Sexo = tipoSexo;
        }



        public override void Validate()
        {
            //if (this.Id == 0)
            //    AddMessageValidation("Não foi identificado qual a referencia desse item!");
        }

    }
}
