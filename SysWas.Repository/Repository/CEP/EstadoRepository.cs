using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.ICEP;
using SysWas.Domain.Entidades.CEP;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.CEP
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
