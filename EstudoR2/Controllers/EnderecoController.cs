using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

    }
}