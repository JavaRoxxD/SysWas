using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFornecedores;
using SysWas.Domain.Entidades.Fornecedores;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Fornecedores
{
    public class ListaContatoRepository : BaseRepository<ListaContato>, IListaContatoRepository
    {
        public ListaContatoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
