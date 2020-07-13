using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstudoR2.Context;
using EstudoR2.Models;

namespace EstudoR2.Controllers
{
    public class ProfessorController : Controller
    {


        public ActionResult Index()
        {
            return View("InsereProfessor");
        }

        [HttpPost]
        public ActionResult Salvar(Professor professor)
        {
            using (var db = new R2Context())
            {
                db.Professores.Add(professor);
                db.SaveChanges();
            }
            return View("InsereProfessor");
        }

        public ActionResult ListarProfessores()
        {
            using (var db = new R2Context())
            {
              var professores = db.Professores.ToList();
              return View(professores);
            }
        }

        [HttpGet]
        public ActionResult Apagar(Professor professor)
        {
            using (var db = new R2Context())
            {
                db.Professores.Attach(professor);
                db.Professores.Remove(professor);
                db.SaveChanges();
                return RedirectToAction("ListarProfessores");
            }
        }

        [HttpGet]
        public ActionResult EditarProfessor(Professor professor)
        {
            using (var db = new R2Context())
            {
             var professorEditar = db.Professores.Where(x=>x.IdProfessor == professor.IdProfessor).First();
             return View(professorEditar);
            }
        }

        [HttpPost]
        public ActionResult Editar(Professor professor)
        {
            using (var db = new R2Context())
            {
                var professorEditar = db.Professores.Where(x => x.IdProfessor == professor.IdProfessor).First();
                professorEditar.NomeProfessor = professor.NomeProfessor;
                db.SaveChanges();
                return RedirectToAction("ListarProfessores");
            }
        }
    }
}