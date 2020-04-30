using System;
using System.Collections.Generic;
using System.Text;
using SysWas.Domain.Contratos.IUtilitarios;
using SysWas.Domain.Entidades.Utilitarios;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Utilitarios
{
    public class EmailRepository : BaseRepository<Email>, IEmailRepository
    {
        public EmailRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }
    }
}
