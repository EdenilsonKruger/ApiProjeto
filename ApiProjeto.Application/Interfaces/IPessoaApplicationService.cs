using ApiProjeto.Application.Models;
using System.Collections.Generic;

namespace ApiProjeto.Application.Interfaces
{
    public interface IPessoaApplicationService
    {
        IEnumerable<PessoaModel> GetAll();

        PessoaModel GetById(int id);

        PessoaModel Add(CreatePessoaModel obj);

        PessoaModel Update(UpdatePessoaModel obj);

        void Delete(int id);
    }
}