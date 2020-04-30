using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.ICompras;
using SysWas.Domain.Entidades.Compras;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Compras
{
    public class ListaMadeiraRepository : BaseRepository<ListaMadeira>, IListaMadeiraRepository
    {
        public ListaMadeiraRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
