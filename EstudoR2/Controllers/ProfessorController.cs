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


        // GET: Professor
        public ActionResult Index()
        {
            return View("InsereProfessor");
        }

        [HttpPost]
        public ActionResult SalvaProfessor(string nomeProfessor)
        {
            Professor p1 = new Professor();
            p1.NomeProfessor = nomeProfessor;

            using (var db = new R2Context())
            {
                db.Professores.Add(p1);
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
        public ActionResult ApagaProfessor(int idProfessor)
        {
            Professor p1 = new Professor();
            p1.IdProfessor = idProfessor;
            using (var db = new R2Context())
            {
                db.Professores.Attach(p1);
                db.Professores.Remove(p1);
                db.SaveChanges();
                return RedirectToAction("ListarProfessores");
            }
        }

        [HttpGet]
        public ActionResult EditarProfessor(int idprofessor)
        {
            Professor p = new Professor();
            p.IdProfessor = idprofessor;
            using (var db = new R2Context())
            {
             var professorEditar = db.Professores.Where(x=>x.IdProfessor == idprofessor).First();
             return View(professorEditar);
            }
        }

        [HttpPost]
        public ActionResult Editar(string NomeProfessor, int IdProfessor)
        {
            using (var db = new R2Context())
            {
                var professorEditar = db.Professores.Where(x => x.IdProfessor == IdProfessor).First();
                professorEditar.NomeProfessor = NomeProfessor;
                db.SaveChanges();
                return RedirectToAction("ListarProfessores");
            }
        }
    }
}