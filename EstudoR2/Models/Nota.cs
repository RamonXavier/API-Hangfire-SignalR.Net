﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudoR2.Models
{
    [Table("t_notas")]
    public class Nota
    {
        [Key, Column("id_nota")] 
        public int IdNota { get; set; }

        [ForeignKey("Aluno"),Column("id_aluno")]
        public int IdAluno { get; set; }
        public virtual Aluno Aluno { get; set; }

        [ForeignKey("Atividade"), Column("id_atividade")]
        public int IdAtividade { get; set; }
        public virtual Atividade Atividade { get; set; }
    }
}