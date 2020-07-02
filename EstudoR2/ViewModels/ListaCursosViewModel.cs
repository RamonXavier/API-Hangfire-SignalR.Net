using System;
using System.Collections.Generic;
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

        public int IdCursoSelecionado { get; set; }
        public IList<IdValorViewModel> CursosDisponiveis{ get; set; }

    }
}