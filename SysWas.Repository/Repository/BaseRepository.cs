using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysWas.Domain.Contratos;
using SysWas.Repository.Context;

namespace SysWas.Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {


        protected readonly SysWasContext SysWasContext;

        public BaseRepository(SysWasContext sysWasContext)
        {
            SysWasContext = sysWasContext;
        }

     
        public void Adicionar(TEntity entity)
        {
            try
            {
                SysWasContext.Set<TEntity>().Add(entity);
                SysWasContext.SaveChanges();
            }
            catch (MySqlException exSql)
            {
                throw exSql;
            }

        }

        public void Atualizar(TEntity entity)
        {
            SysWasContext.Set<TEntity>().Update(entity);
            SysWasContext.SaveChanges();
        }

       public TEntity ObterPorId(int id)
        {
            return SysWasContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return SysWasContext.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            SysWasContext.Remove(entity);
            SysWasContext.SaveChanges();
        }

        public void Dispose()
        {
            SysWasContext.Dispose();
        }

    }
}
