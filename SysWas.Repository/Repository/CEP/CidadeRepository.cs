using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysWas.Domain.Contratos.ICEP;
using SysWas.Domain.Entidades.CEP;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.CEP
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }

        public IEnumerable<Cidade> Obter(int uf)
        {

            var cidades = SysWasContext.Cidade.Where(c => c.EstadoId == uf).ToList();

            return cidades;

        }

    }
}