using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFinanceiro;
using SysWas.Domain.Entidades.Financeiro;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Financeiro
{
    public class TipoCustoRepository : BaseRepository<TipoCusto>, ITipoCustoRepository
    {
        public TipoCustoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
