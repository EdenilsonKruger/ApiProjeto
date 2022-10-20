using ApiProjeto.Domain.Entities;
using FluentValidation;
using System.Collections.Generic;

namespace ApiProjeto.Domain.Interfaces
{
    public interface IServiceEntityBase<TEntity> where TEntity : EntityBase
    {
        IEnumerable<TOutputModel> GetAll<TOutputModel>() where TOutputModel : class;

        TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class;

        TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class;

        void Delete(int id);
    }
}
