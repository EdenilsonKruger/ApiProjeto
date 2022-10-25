using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace WebProjetoReact.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;
        }

        // GET: Pessoas
        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            var requisicao = new RestRequest(Method.GET);
            var resultado = ConsumirApi("", requisicao);
            var listaPessoa = JsonConvert.DeserializeObject<List<Pessoa>>(resultado);
            return listaPessoa;
        }

        private string ConsumirApi(string servico, RestRequest requisicao)
        {
            var resultado = "";
            var url = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["UrlApiProjeto"];

            try
            {
                var ws = new RestClient(url + servico);
                resultado = ws.Execute(requisicao).Content;
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }

    }
}