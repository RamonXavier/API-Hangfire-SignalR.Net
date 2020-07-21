using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstudoR2.Controllers
{
    public class ArquivosController : Controller
    {
        // GET: Arquivos
        public ActionResult ListarArquivos()
        {
            return View();
        }
    }
}