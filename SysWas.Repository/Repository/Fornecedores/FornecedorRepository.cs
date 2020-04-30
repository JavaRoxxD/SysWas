using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IFornecedores;
using SysWas.Domain.Entidades.Fornecedores;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Fornecedores
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
