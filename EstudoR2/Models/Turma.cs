using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudoR2.Models
{

    [Table("t_turmas")]
    public class Turma
    {
        [Key, Column("id_turma")]
        public int IdTurma { get; set; }

        [Column("descricao_turma")]
        public string NomeTurma{ get; set; }
        
        [ForeignKey("Modulo"), Column("id_modulo")]
        public int IdModulo { get; set; }
        public virtual Modulo Modulo { get; set; }

    }
}