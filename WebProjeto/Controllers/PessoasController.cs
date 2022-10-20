using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using WebProjeto.Models;

namespace WebProjeto.Controllers
{
    public class PessoasController : Controller
    {
        // GET: Pessoas
        public IActionResult Index()
        {
            var requisicao = new RestRequest(Method.GET);
            var resultado = ConsumirApi("", requisicao);
            var listaPessoa = JsonConvert.DeserializeObject<List<Pessoa>>(resultado);

            var pessoaVM = new PessoaViewModel
            {
                Pessoas = listaPessoa
            };

            return View(pessoaVM);
        }

        // GET: Pessoas/Details/5
        public IActionResult Details(int id)
        {
            var requisicao = new RestRequest(Method.GET);
            var servico = id.ToString();

            var resultado = ConsumirApi(servico, requisicao);
            var pessoa = JsonConvert.DeserializeObject<Pessoa>(resultado);

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                var requisicao = new RestRequest(Method.POST);
                requisicao.AddHeader("accept", "text/plain");
                requisicao.AddHeader("Content-Type", "application/json");

                var json = JsonConvert.SerializeObject(pessoa);
                requisicao.AddParameter("application/json", json, ParameterType.RequestBody);

                var resultado = ConsumirApi("", requisicao);

                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public IActionResult Edit(int id)
        {
            var requisicao = new RestRequest(Method.GET);
            var servico = id.ToString();

            var resultado = ConsumirApi(servico, requisicao);
            var pessoa = JsonConvert.DeserializeObject<Pessoa>(resultado);

            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                var requisicao = new RestRequest(Method.PUT);
                requisicao.AddHeader("accept", "*/*");
                requisicao.AddHeader("Content-Type", "application/json");

                var json = JsonConvert.SerializeObject(pessoa);
                requisicao.AddParameter("application/json", json, ParameterType.RequestBody);

                var resultado = ConsumirApi("", requisicao);

                return RedirectToAction(nameof(Index));
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public IActionResult Delete(int id)
        {
            var requisicao = new RestRequest(Method.GET);
            var servico = id.ToString();

            var resultado = ConsumirApi(servico, requisicao);
            var pessoa = JsonConvert.DeserializeObject<Pessoa>(resultado);

            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var requisicao = new RestRequest(Method.DELETE);
            requisicao.AddHeader("accept", "text/plain");
            var servico = id.ToString();

            var resultado = ConsumirApi(servico, requisicao);

            return RedirectToAction(nameof(Index));
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
            catch (Exception e)
            {

                throw e;
            }

            return resultado;
        }

    }
}
