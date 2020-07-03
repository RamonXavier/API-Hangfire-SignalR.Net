using System.Collections.Generic;

namespace EstudoR2.ViewModels
{
    public class MateriasModulosProfessorViewModel
    {
        public MateriasModulosProfessorViewModel()
        {
            ModuloDisponivel = new List<IdValorViewModel>();
            ProfessorDisponivel = new List<IdValorViewModel>();
        }

        public int IdMateria { get; set; }
        public string NomeMateria { get; set; }
        public int IdModuloSelecionado { get; set; }
        public List<IdValorViewModel> ModuloDisponivel { get; set; }
        public string NomeModulo { get; set; }
        public int IdProfessorSelecionado { get; set; }
        public List<IdValorViewModel> ProfessorDisponivel { get; set; }
        public string NomeProfessor { get; set; }

        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }

    }
}