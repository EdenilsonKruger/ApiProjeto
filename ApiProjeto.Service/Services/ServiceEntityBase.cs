using ApiProjeto.Domain.Entities;
using ApiProjeto.Domain.Interfaces;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjeto.Service.Services
{
    public class ServiceEntityBase<TEntity> : IServiceEntityBase<TEntity> where TEntity : EntityBase
    {
        private readonly IRepositoryEntityBase<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public ServiceEntityBase(IRepositoryEntityBase<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public IEnumerable<TOutputModel> GetAll<TOutputModel>() where TOutputModel : class
        {
            var entities = _baseRepository.GetAll();

            var outputModels = entities.Select(s => _mapper.Map<TOutputModel>(s));

            return outputModels;
        }

        public TOutputModel GetById<TOutputModel>(int id) where TOutputModel : class
        {
            var entity = _baseRepository.GetById(id);

            var outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Add(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        public void Delete(int id) => _baseRepository.Delete(id);

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel inputModel)
            where TValidator : AbstractValidator<TEntity>
            where TInputModel : class
            where TOutputModel : class
        {
            TEntity entity = _mapper.Map<TEntity>(inputModel);

            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);

            TOutputModel outputModel = _mapper.Map<TOutputModel>(entity);

            return outputModel;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
