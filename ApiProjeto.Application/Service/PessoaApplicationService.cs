using ApiProjeto.Application.Interfaces;
using ApiProjeto.Application.Models;
using ApiProjeto.Domain.Interfaces;
using ApiProjeto.Service.Validators;
using System.Collections.Generic;

namespace ApiProjeto.Application.Service
{
    public class PessoaApplicationService : IPessoaApplicationService
    {
        private readonly IPessoaService _pessoaService;

        public PessoaApplicationService(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        public IEnumerable<PessoaModel> GetAll()
        {
            var objPessoa = _pessoaService.GetAll<PessoaModel>();
            return objPessoa;
        }

        public PessoaModel GetById(int id)
        {
            var objPessoa = _pessoaService.GetById<PessoaModel>(id);
            return objPessoa;
        }

        public PessoaModel Add(CreatePessoaModel obj)
        {
            var objPessoa = _pessoaService.Add<CreatePessoaModel, PessoaModel, ValidatorPessoa>(obj);
            return objPessoa;
        }

        public PessoaModel Update(UpdatePessoaModel obj)
        {
            var objPessoa = _pessoaService.Update<UpdatePessoaModel, PessoaModel, ValidatorPessoa>(obj);
            return objPessoa;
        }

        public void Delete(int id)
        {
            _pessoaService.Delete(id);
        }
    }
}
