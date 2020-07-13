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
        public JsonResult TestarRegex(string valor = "")
        {
            var regex = new Regex("[^\\d]");
            var numerosNormalizados = regex.Replace(valor, "");
            var retorno = new { Text = $"{numerosNormalizados}", Id = "cpf" };
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> BuscaEndereco(string cep)
        {
            var regex = new Regex("[^\\d]");
            var cepNormalizado = regex.Replace(cep, "");

            HttpResponseMessage response = await client.GetAsync($"http://viacep.com.br/ws/{cepNormalizado}/json/");
            string retornoHttp = await response.Content.ReadAsStringAsync();
            return Json(retornoHttp, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<JsonResult> TestaPostHttp()
        {
            var valoresTestePost = new Dictionary<string, string>
            {
                { "title", "Post Ramon" },
                { "body", "texto" },
                { "userId", "101" }
            };

            var valoresNormalizados = new FormUrlEncodedContent(valoresTestePost);
            var response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", valoresNormalizados);

            var retornoHttp = await response.Content.ReadAsStringAsync();
            return Json(retornoHttp, JsonRequestBehavior.AllowGet);
        }

        //[HttpPut]
        public async Task<JsonResult> TestaPutHttp()
        {

            var valoresTestePut = new Dictionary<string, string>()
            {
                { "title", "Post Ramon - X" },
                { "body", "texto - X" },
                { "userId", "101" },
                { "id", "1" },
            };

            var valoresNormalizados = new FormUrlEncodedContent(valoresTestePut);
            var response = await client.PutAsync("https://jsonplaceholder.typicode.com/posts/1}", valoresNormalizados);
            var retornoHttp = await response.Content.ReadAsStringAsync();
            return Json(retornoHttp, JsonRequestBehavior.AllowGet);
        }
    }
}