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
    public class MateriaController : Controller
    {
        public ActionResult ListarMaterias()
        {
            //using (var db = new R2Context())
            //{
            //    var viewModel = db.Materias.Select(x => new MateriasModulosProfessorViewModel()
            //    {
            //        NomeMateria = x.NomeMateria,

            //        NomeProfessor = db.Professores.Where(p => p.IdProfessor == x.IdProfessor)
            //            .Select(p => p.NomeProfessor).FirstOrDefault(),

            //        NomeModulo = db.Modulos.Where(m => m.IdModulo == x.IdModulo).Select(m => m.NomeModulo)
            //            .FirstOrDefault(),

            //        IdMateria = x.IdMateria,

            //        NomeCurso = (from cursos in db.Cursos
            //                    join modulos in db.Modulos on cursos.IdCurso equals modulos.IdCurso
            //                    where modulos.IdModulo == x.IdModulo
            //                    select cursos.NomeCurso).FirstOrDefault(),
            //    }).ToList();
            //    return View(viewModel);
            //}
            return RedirectToAction("ListarCursos", "Curso");
        }

        public ActionResult InserirMaterias()
        {
            using (var db = new R2Context())
            {
                var professores = db.Professores.Select(p => new IdValorViewModel()
                {
                    Id = p.IdProfessor,
                    Valor = p.NomeProfessor
                }).ToList();

                var modulos = db.Modulos.Select(m => new IdValorViewModel()
                {
                    Id = m.IdModulo,
                    Valor = m.NomeModulo
                }).ToList();

                var viewModel = new MateriasModulosProfessorViewModel()
                {
                    ProfessorDisponivel = professores,
                    ModuloDisponivel = modulos
                };

                return View(viewModel);
            }

        }

        [HttpPost]
        public ActionResult Inserir(int IdModuloSelecionado, int IdProfessorSelecionado, string nomeMateria)
        {
            using (var db = new R2Context())
            {
                Materia m = new Materia();
                m.NomeMateria = nomeMateria;
                m.IdProfessor = IdProfessorSelecionado;

                db.Materias.Add(m);
                db.SaveChanges();

                MateriaModulo mm = new MateriaModulo();
                mm.IdModulo = IdModuloSelecionado;
                mm.IdMateria = m.IdMateria;

                db.MateriasModulos.Add(mm);
                db.SaveChanges();

                return RedirectToAction("ListarMaterias");
            }
        }

        public ActionResult Apagar(int idmodulo)
        {
            throw new NotImplementedException();
        }

        public ActionResult Editar(int idmodulo)
        {
            throw new NotImplementedException();
        }
    }
}