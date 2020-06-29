using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudoR2.Models
{
    [Table("t_alunos")]
    public class Aluno
    {
        [Key, Column("id_aluno")] 
        public int IdAluno { get; set; }
        public string NomeAluno { get; set; }

        [ForeignKey("Curso"), Column("id_curso")]
        public int IdCurso { get; set; }
        public virtual Curso Curso { get; set; }

        [ForeignKey("Turma"), Column("id_turma")]
        public int IdTurma { get; set; }
        public virtual Turma Turma { get; set; }
    }
}