using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudoR2.Models
{
    [Table("t_aluno_presencas")]
    public class Presenca
    {
        [Key, Column("id_aluno_presenca")]
        public int IdAlunoPresenca { get; set; }

        [ForeignKey("Aluno"), Column("id_aluno")]
        public int IdAluno { get; set; }
        public virtual Aluno Aluno { get; set; }
    }
}