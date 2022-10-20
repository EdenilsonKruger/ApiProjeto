using ApiProjeto.Domain.Entities;
using ApiProjeto.Domain.Interfaces;
using AutoMapper;

namespace ApiProjeto.Service.Services
{
    public class PessoaService : ServiceEntityBase<Pessoa>, IPessoaService
    {
        public PessoaService(IPessoaRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
