using ApiProjeto.Domain.Entities;
using System.Collections.Generic;

namespace ApiProjeto.Domain.Interfaces
{
    public interface IRepositoryEntityBase<TEntity> where TEntity : EntityBase
    {
        IList<TEntity> GetAll();

        TEntity GetById(int id);

        void Add(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);
    }
}