using ApiProjeto.Domain.Entities;
using ApiProjeto.Domain.Interfaces;
using ApiProjeto.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjeto.Infra.Data.Repository
{
    public class RepositoryEntityBase<TEntity> : IRepositoryEntityBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ApiProjetoContext _sqlContext;

        public RepositoryEntityBase(ApiProjetoContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IList<TEntity> GetAll() =>
            _sqlContext.Set<TEntity>().ToList();

        public TEntity GetById(int id) =>
            _sqlContext.Set<TEntity>().Find(id);

        public void Add(TEntity obj)
        {
            _sqlContext.Set<TEntity>().Add(obj);
            _sqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _sqlContext.Set<TEntity>().Remove(GetById(id));
            _sqlContext.SaveChanges();
        }

    }
}
