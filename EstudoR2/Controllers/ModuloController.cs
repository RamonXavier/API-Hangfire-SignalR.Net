using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EstudoR2.Context;
using EstudoR2.Models;
using EstudoR2.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;

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
        public string Inserir(Modulo modulo)
        {
            using (var db = new R2Context())
            {
                db.Modulos.Add(modulo);
                db.SaveChanges(); 
                return $"{modulo.NomeModulo}";
            }

        }

        [HttpGet]
        public ActionResult Apagar(Modulo modulo)
        {
            using (var db = new R2Context())
            {
                db.Modulos.Attach(modulo);
                db.Modulos.Remove(modulo);
                db.SaveChanges();
                return RedirectToAction("ListarModulos");
            }
        }

        [HttpGet]
        public ActionResult EditarModulo(Modulo modulo)
        {

            using (var db = new R2Context())
            {
                var moduloParaEditar = db.Modulos.Where(x=>x.IdModulo == modulo.IdModulo).Select(x => new ListaCursosViewModel()
                {
                    IdModulo = x.IdModulo,
                    NomeModulo = x.NomeModulo,
                    IdCursoSelecionado = x.IdCurso,
                    CursosDisponiveis = db.Cursos.Select(y=> new IdValorViewModel()
                    {
                        Id = y.IdCurso,
                        Valor = y.NomeCurso
                    }).ToList()
                }).FirstOrDefault();
                return View(moduloParaEditar);
            }
        }

        [HttpPost]
        public ActionResult Editar(Modulo modulo)
        {
            using (var db = new R2Context())
            {
                var moduloEditado = db.Modulos.Where(x=>x.IdModulo == modulo.IdModulo).First();
                moduloEditado.IdCurso = modulo.IdCurso;
                moduloEditado.NomeModulo = modulo.NomeModulo;
                db.SaveChanges();
                return RedirectToAction("ListarModulos");
            }
        }

        public void PdfModulo(string s)
        {
            using (var db = new R2Context())
            {
            var listaModulos = db.Modulos.ToArray();                   

            var pdf = new Document(PageSize.A4, 10, 10, 10, 10);
            var caminhoPdf = AppDomain.CurrentDomain.BaseDirectory;
            PdfWriter.GetInstance(pdf, new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"\Pdf\pdfWeb-Modulos.pdf", FileMode.Create));
            pdf.Open();
            pdf.Add(new Paragraph("aaaaa"));

            PdfPTable tabela = new PdfPTable(3);

            PdfPCell cell = new PdfPCell(new Phrase("Módulos Cadastrados"));

            cell.Colspan = 3;

            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right

            tabela.AddCell(cell);

            PdfPCell headerId = new PdfPCell(new Phrase("Id Módulo"));
            PdfPCell headerNomeM = new PdfPCell(new Phrase("Nome Módulo"));
            PdfPCell headerNomeC = new PdfPCell(new Phrase("Curso do Módulo"));

            tabela.AddCell(headerId);
            tabela.AddCell(headerNomeM);
            tabela.AddCell(headerNomeC);

            foreach (var modulos in listaModulos)
            {
                tabela.AddCell($"{modulos.IdModulo}");

                tabela.AddCell($"{modulos.NomeModulo}");

                tabela.AddCell($"{modulos.Curso.NomeCurso}");
            }



            pdf.Add(tabela);

            pdf.Close();
            Response.Redirect($"/Pdf/pdfWeb-Modulos.pdf");

            }
        }
    }
}