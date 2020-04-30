using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysWas.Domain.Contratos;
using SysWas.Domain.Contratos.IUsuarios;
using SysWas.Domain.Entidades.Usuarios;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository.Usuarios
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SysWasContext sysWasContext) : base(sysWasContext)
        {
        }


        public Usuario Obter(string email, string senha)
        {
            return SysWasContext
                .Usuario
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario Obter(string email)
        {
            return SysWasContext
                .Usuario
                .FirstOrDefault(u => u.Email == email);
        }
    }
}
