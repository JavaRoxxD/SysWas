using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IEmpresas;
using SysWas.Domain.Entidades.Empresas;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Empresas
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
