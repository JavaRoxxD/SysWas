using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFinanceiro;
using SysWas.Domain.Entidades.Financeiro;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Financeiro
{
    public class TipoDespesaRepository : BaseRepository<TipoDespesa>, ITipoDespesaRepository
    {
        public TipoDespesaRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
