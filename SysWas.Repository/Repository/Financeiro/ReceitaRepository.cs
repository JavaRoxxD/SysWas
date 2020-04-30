using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFinanceiro;
using SysWas.Domain.Entidades.Financeiro;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Financeiro
{
    public class ReceitaRepository : BaseRepository<Receita>, IReceitaRepository
    {
        public ReceitaRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
