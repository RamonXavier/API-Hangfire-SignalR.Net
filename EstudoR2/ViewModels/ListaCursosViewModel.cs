using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EstudoR2.ViewModels
{
    public class ListaCursosViewModel
    {

        public ListaCursosViewModel()
        {
            CursosDisponiveis = new List<IdValorViewModel>();
        }

        [DisplayName("Curso")]
        public int? IdCursoSelecionado { get; set; }
        public IList<IdValorViewModel> CursosDisponiveis{ get; set; }

        public int IdModulo { get; set; }
        public string nomeModulo { get; set; }

        public int IdCurso { get; set; }

    }
}