using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFornecedores;
using SysWas.Domain.Entidades.Fornecedores;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Fornecedores
{
    public class TipoFornecedorRepository : BaseRepository<TipoFornecedor>, ITipoFornecedorRepository
    {
        public TipoFornecedorRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
