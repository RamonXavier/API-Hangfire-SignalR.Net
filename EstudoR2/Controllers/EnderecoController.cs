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
            string retornoHttp = await response.Content.ReadAsStringAsync();
            return Json(retornoHttp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> postHttp()
        {
            var valoresTestePost = new Dictionary<string, string>
            {
                { "title", "Post Ramon" },
                { "body", "texto" },
                { "userId", "101" }
            };

            var conteudoPost = new FormUrlEncodedContent(valoresTestePost);
            var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", conteudoPost);

            var retornoHttp = await response.Content.ReadAsStringAsync();
            return Json(retornoHttp, JsonRequestBehavior.AllowGet);
        }

        //[HttpPut]
        public async Task<JsonResult> putHttp()
        {

            var valoresTestePut = new Dictionary<string, string>()
            {
                { "title", "Post Ramon - X" },
                { "body", "texto - X" },
                { "userId", "101" },
                { "id", "1" },
            };

            var conteudoPut = new FormUrlEncodedContent(valoresTestePut);
            var response = await client.PutAsync("https://jsonplaceholder.typicode.com/posts/1}", conteudoPut);
            var retornoHttp = await response.Content.ReadAsStringAsync();
            return Json(retornoHttp, JsonRequestBehavior.AllowGet);
        }

        public async Task getHttp()
        {
            var cepLimpo = "36071240";
            var teste = HttpClientFactory.Create();
            var url = ($"http://viacep.com.br/ws/{cepLimpo}/json/");
            var req = await HttpClient.GetStringAsync(url);
            var a = "a";

        }

    }
}