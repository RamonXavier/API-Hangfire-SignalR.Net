using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using EstudoR2.Controllers;
using Hangfire;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace EstudoR2.Hubs
{
    public class ChatHub : Hub
    {
        CentralAvisoController ramonBot = new CentralAvisoController();
        public void EnviarMensagem(string nome, string mensagem, string imagem)
        {
            if (mensagem == "1")
            {
                BackgroundJob.Enqueue(() => RoboMensagemFaltas());
            }
            if (mensagem == "2")
            {
                BackgroundJob.Enqueue(() => RoboMensagemNota());
            }
            if (mensagem == "3")
            {
                BackgroundJob.Enqueue(() => RoboMensagemEsportes());
            }
            else
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
                context.Clients.All.publicarMensagem(nome, mensagem, imagem);
            }
        }

        public void RoboMensagemFaltas()
        {
            string nome = "Cpu";
            string mensagem = "Nosso aluno turista é o -> Evandro Siqueira, Você viu ele por ai?";
            string imagem = "https://image.freepik.com/vetores-gratis/robo-bonito-icon-ilustracao-conceito-de-icone-de-robo-de-tecnologia-isolado-estilo-cartoon-plana_138676-1220.jpg";
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.publicarMensagem(nome, mensagem, imagem);
            BackgroundJob.Enqueue(() => ramonBot.RamonBot());
        }
        public void RoboMensagemNota()
        {
            string nome = "Cpu";
            string mensagem = "O cara das notas é o -> Ramon Xavier, vai lá das os parabéns para ele.";
            string imagem = "https://image.freepik.com/vetores-gratis/robo-bonito-icon-ilustracao-conceito-de-icone-de-robo-de-tecnologia-isolado-estilo-cartoon-plana_138676-1220.jpg";
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.publicarMensagem(nome, mensagem, imagem);
            BackgroundJob.Enqueue(() => ramonBot.RamonBot());
        }
        public void RoboMensagemEsportes()
        {
            string nome = "Cpu";
            string mensagem = "Acho que estou com algum erro no sistema, o esportista é o Davi Loco!";
            string imagem = "https://image.freepik.com/vetores-gratis/robo-bonito-icon-ilustracao-conceito-de-icone-de-robo-de-tecnologia-isolado-estilo-cartoon-plana_138676-1220.jpg";
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.publicarMensagem(nome, mensagem, imagem);
            BackgroundJob.Enqueue(() => ramonBot.RamonBot());
        }
        public void RoboMensagem(string nome, string mensagem, string imagem)
        {
            mensagem += DateTime.Now.ToString();
            imagem = "https://images.squarespace-cdn.com/content/57c8a68a20099ef23fb19e90/1472905401720-XMAMEFKPVOO45VEAMZQS/pepper-robot-2.0.jpg?format=1500w&content-type=image%2Fjpeg";
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.publicarMensagem(nome, mensagem,imagem);
        }

    }
}