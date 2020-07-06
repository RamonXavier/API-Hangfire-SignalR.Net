using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EstudoR2.Context;
using EstudoR2.Models;
using EstudoR2.ViewModels;

namespace EstudoR2.Controllers
{
    public class ModuloController : Controller
    {
        public ModuloController()
        {
        }

        IMapper _mapper;
        public ModuloController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ActionResult ListarModulos()
        {
            using (var db = new R2Context())
            {
                var listaModulos = db.Modulos.Select(x => new ListaModulosViewModel()
                {
                    NomeModulo = x.NomeModulo,
                    IdModulo = x.IdModulo,
                    NomeCurso = db.Cursos.Where(c=>c.IdCurso == x.IdCurso).Select(c=>c.NomeCurso).FirstOrDefault()
                }).ToList();
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
        public ActionResult InserirModuloAction(Modulo modulo)
        {
           
            using (var db = new R2Context())
            {
                db.Modulos.Add(modulo);
                db.SaveChanges(); 
                return RedirectToAction("ListarModulos");
            }

        }

        [HttpGet]
        public ActionResult ApagarModulo(int idModulo)
        {
            Modulo modulo = new Modulo();
            modulo.IdModulo = idModulo;

            using (var db = new R2Context())
            {
                db.Modulos.Attach(modulo);
                db.Modulos.Remove(modulo);
                db.SaveChanges();
                return RedirectToAction("ListarModulos");
            }
        }

        [HttpGet]
        public ActionResult EditarModulo(int idModulo)
        {

            using (var db = new R2Context())
            {
                var moduloEditar = db.Modulos.Where(x=>x.IdModulo == idModulo).Select(x => new ListaCursosViewModel()
                {
                    IdModulo = x.IdModulo,
                    nomeModulo = x.NomeModulo,
                    IdCursoSelecionado = x.IdCurso,
                    CursosDisponiveis = db.Cursos.Select(y=> new IdValorViewModel()
                    {
                        Id = y.IdCurso,
                        Valor = y.NomeCurso
                    }).ToList()
                }).FirstOrDefault();
                return View(moduloEditar);
            }
            //return RedirectToAction("ListarModulos");
        }

        [HttpPost]
        public ActionResult Editar(int idModulo, int IdCursoSelecionado, string nomeModulo)
        {
            using (var db = new R2Context())
            {
                var moduloEditar = db.Modulos.Where(x=>x.IdModulo == idModulo).First();
                moduloEditar.IdCurso = IdCursoSelecionado;
                moduloEditar.NomeModulo = nomeModulo;
                db.SaveChanges();
                return RedirectToAction("ListarModulos");
            }
        }
    }
}