using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstudoR2.Hubs;
using Hangfire;
using Microsoft.AspNet.SignalR;

namespace EstudoR2.Controllers
{
    public class CentralAvisoController : Controller
    {
        public ActionResult CentralAviso()
        {
            BackgroundJob.Schedule(() => RamonBot(), TimeSpan.FromMilliseconds(1));
            return View();
        }

        public void RamonBot()
        {
            var nome = "RamonBot";
            var mensagem = "Olá, Digite o número desejado para sua consulta:" +
                           "1 - Aluno que mais faltou." +
                           "2 - Aluno que tem a nota mais alta." +
                           "3 - Aluno que mais se destacou nos esportes." +
                           "4 - Ir para Chat com todos.";
            var imagem = "https://image.freepik.com/vetores-gratis/robo-bonito-icon-ilustracao-conceito-de-icone-de-robo-de-tecnologia-isolado-estilo-cartoon-plana_138676-1220.jpg";
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.publicarMensagem(nome, mensagem, imagem);
        }

        public void Escreve()
        {
            Console.WriteLine("Na index");
        }
    }
}