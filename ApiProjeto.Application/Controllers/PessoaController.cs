using ApiProjeto.Application.Models;
using ApiProjeto.Domain.Entities;
using ApiProjeto.Domain.Interfaces;
using ApiProjeto.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiProjeto.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PessoaController : ControllerBase
    {
        private IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _pessoaService.GetAll<PessoaModel>());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _pessoaService.GetById<PessoaModel>(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] CreatePessoaModel pessoa)
        {
            if (pessoa == null)
                return NotFound();

            return Execute(() => _pessoaService.Add<CreatePessoaModel, PessoaModel, ValidatorPessoa>(pessoa));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePessoaModel pessoa)
        {
            if (pessoa == null)
                return NotFound();

            return Execute(() => _pessoaService.Update<UpdatePessoaModel, PessoaModel, ValidatorPessoa>(pessoa));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _pessoaService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
