using ApiProjeto.Domain.Entities;
using ApiProjeto.Domain.Interfaces;
using ApiProjeto.Infra.Data.Context;

namespace ApiProjeto.Infra.Data.Repository
{
    public class PessoaRepository<TEntity> : RepositoryEntityBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(ApiProjetoContext sqlContext) : base(sqlContext)
        {
        }
    }
}
