using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstudoR2.Context;
using EstudoR2.Models;
using EstudoR2.ViewModels;

namespace EstudoR2.Controllers
{
    public class ModuloController : Controller
    {
        public ActionResult ListarModulos()
        {

            using (var db = new R2Context())
            {
                var listaModulos = db.Modulos.ToList();
                return View(listaModulos);
            }

        }

        public ActionResult InserirModulo()
        {
            using (var db = new R2Context())
            {
                var listaCursosDisponiveis = db.Cursos.Select(x => new IdValorViewModel()
                {
                    Id = x.IdCurso,
                    Valor = x.NomeCurso
                }).ToList();

                var mooduloViewModel = new ListaCursosViewModel()
                {
                    CursosDisponiveis = listaCursosDisponiveis
                };
                return View(mooduloViewModel);
            }
        }

        [HttpPost]
        public ActionResult InserirModuloAction(string nomeModulo, int IdCursoSelecionado)
        {
            Modulo m1 = new Modulo();
            m1.NomeModulo = nomeModulo;
            m1.IdCurso = IdCursoSelecionado;

            using (var db = new R2Context())
            {
                db.Modulos.Add(m1);
                db.SaveChanges(); 
                return RedirectToAction("ListarModulos");
            }

        }

        public ActionResult ApagarModulo(string s)
        {
            throw new NotImplementedException();
        }

        public ActionResult EditarModulo(string s)
        {
            throw new NotImplementedException();
        }
    }
}