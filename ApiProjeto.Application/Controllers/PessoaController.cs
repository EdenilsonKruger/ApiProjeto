using ApiProjeto.Application.Interfaces;
using ApiProjeto.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiProjeto.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaApplicationService _pessoaApplicationService;

        public PessoaController(IPessoaApplicationService pessoaApplicationService)
        {
            _pessoaApplicationService = pessoaApplicationService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _pessoaApplicationService.GetAll());
        }
        
        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _pessoaApplicationService.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] CreatePessoaModel pessoa)
        {
            if (pessoa == null)
                return NotFound();

            return Execute(() => _pessoaApplicationService.Add(pessoa));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Update([FromBody] UpdatePessoaModel pessoa)
        {
            if (pessoa == null)
                return NotFound();

            return Execute(() => _pessoaApplicationService.Update(pessoa));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _pessoaApplicationService.Delete(id);
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
