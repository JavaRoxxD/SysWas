using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysWas.Domain.Contratos.ICEP;
using SysWas.Domain.Entidades.CEP;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.CEP
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }


        public Endereco Obter(string cep)
        {
            return SysWasContext
                .Endereco.Where(w => String.Compare(w.Cep, cep, true) == 0).FirstOrDefault();
                //.FirstOrDefault(e =>  string.Compare(e.Cep, cep, true) == 0);
        }

        //public bool Duplicidade(string cep)
        //{
        //    return SysWasContext.Endereco
        //}

    }
}
