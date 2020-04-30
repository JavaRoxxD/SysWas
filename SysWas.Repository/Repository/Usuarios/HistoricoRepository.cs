using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IUsuarios;
using SysWas.Domain.Entidades.Usuarios;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Usuarios
{
    public class HistoricoRepository : BaseRepository<Historico>, IHistoricoRepository
    {
        public HistoricoRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
