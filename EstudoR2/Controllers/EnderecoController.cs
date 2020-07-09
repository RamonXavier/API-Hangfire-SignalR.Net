using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EstudoR2.Models;


namespace EstudoR2.Controllers
{
    public class EnderecoController : Controller
    {
        static readonly HttpClient client = new HttpClient();
        private static readonly HttpClient HttpClient;

        static EnderecoController()
        {
            HttpClient = new HttpClient();
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult testaRegex(string cep = "")
        {
            Endereco endereco = new Endereco();
            var r = new Regex("[^\\d]");
            var cpfLimpo = r.Replace(cep, "");
            var retorno = new { Text = $"{cpfLimpo}", Id = "cpf" };
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> buscaEndereco(string cep)
        {
            var r = new Regex("[^\\d]");
            var cepLimpo = r.Replace(cep, "");

            HttpResponseMessage response = await client.GetAsync($"http://viacep.com.br/ws/{cepLimpo}/json/");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return Json(responseBody, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> postHttp()
        {
            var values = new Dictionary<string, string>
            {
                { "title", "hello" },
                { "body", "hello" },
                { "userId", "212" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", content);

            var responseString = await response.Content.ReadAsStringAsync();
            return Json(responseString, JsonRequestBehavior.AllowGet);
        }
        public async Task getHttp()
        {
            // GET CEP 
            var cepLimpo = "36071240";
            var teste = HttpClientFactory.Create();
            var url = ($"http://viacep.com.br/ws/{cepLimpo}/json/");
            var req = await HttpClient.GetStringAsync(url);

            // POST API
            var values = new Dictionary<string, string>
            {
                { "title", "hello" },
                { "body", "hello" },
                { "userId", "212" }
            }.ToString();

            var urlPost = ($"https://jsonplaceholder.typicode.com/posts");

            using (var client = new HttpClient())
            {
                var req2 = await client.PostAsync("https://jsonplaceholder.typicode.com/posts",
                    new StringContent(values));
                req2.EnsureSuccessStatusCode();
                var ag = "";
            }

            var a = "a";

        }

    }
}