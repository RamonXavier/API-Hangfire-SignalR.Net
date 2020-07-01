using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstudoR2.Context;
using EstudoR2.Models;

namespace EstudoR2.Controllers
{
    public class CursoController : Controller
    {
        // GET: Curso
        public ActionResult ListarCursos()
        {
            using (var db = new R2Context())
            {
                var listaCursos = db.Cursos.ToList();
                return View(listaCursos);
            }
        }

        public ActionResult InserirCurso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InserirCursoAction(string NomeCurso)
        {
            Curso c1 = new Curso();
            c1.NomeCurso = NomeCurso;

            using (var db = new R2Context())
            {
                db.Cursos.Add(c1);
                db.SaveChanges();
                return RedirectToAction("ListarCursos");
            }
        }

        [HttpGet]
        public ActionResult ApagaCurso(int idCurso)
        {
            Curso c1 = new Curso();
            c1.IdCurso = idCurso;
            using (var db = new R2Context())
            {
                db.Cursos.Attach(c1);
                db.Cursos.Remove(c1);
                db.SaveChanges();
                return RedirectToAction("ListarCursos");
            }
        }

        [HttpGet]
        public ActionResult EditarCurso(int idCurso)
        {
            using (var db = new R2Context())
            {
                var edicaoCurso = db.Cursos.Where(x => x.IdCurso == idCurso).First();
                return View(edicaoCurso);
            }
        }

        [HttpPost]
        public ActionResult Editar(int idCurso, string nomeCurso)
        {
            using (var db = new R2Context())
            {
                var edicaoCurso = db.Cursos.Where(x => x.IdCurso == idCurso).First();
                edicaoCurso.NomeCurso = nomeCurso;
                db.SaveChanges();
                return RedirectToAction("ListarCursos");
            }
        }
    }
}