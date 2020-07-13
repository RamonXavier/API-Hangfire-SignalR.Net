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
        public ActionResult InserirTelaPrincipal(Curso curso)
        {
            using (var db = new R2Context())
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("ListarCursos");
            }
        }

        [HttpPost]
        public JsonResult Inserir(Curso curso)
        {
            using (var db = new R2Context())
            {
                db.Cursos.Add(curso);
                db.SaveChanges();
                var novoCursoDropDown = db.Cursos.Select(item => new IdValorViewModel
                {
                    Id = item.IdCurso,
                    Valor = item.NomeCurso
                }).ToList();
                return Json(new SelectList(novoCursoDropDown, "id", "valor"));
            }

        }

        [HttpGet]
        public ActionResult Apagar(Curso curso)
        {
            using (var db = new R2Context())
            {
                db.Cursos.Attach(curso);
                db.Cursos.Remove(curso);
                db.SaveChanges();
                return RedirectToAction("ListarCursos");
            }
        }

        [HttpGet]
        public ActionResult EditarCurso(Curso curso)
        {
            using (var db = new R2Context())
            {
                var edicaoCurso = db.Cursos.Where(x => x.IdCurso == curso.IdCurso).First();
                return View(edicaoCurso);
            }
        }

        [HttpPost]
        public ActionResult Editar(Curso curso)
        {
            using (var db = new R2Context())
            {
                var edicaoCurso = db.Cursos.Where(x => x.IdCurso == curso.IdCurso).First();
                edicaoCurso.NomeCurso = curso.NomeCurso;
                db.SaveChanges();
                return RedirectToAction("ListarCursos");
            }
        }
    }
}