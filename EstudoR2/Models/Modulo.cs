using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoR2.Models
{
    [Table("t_modulos")]
    public class Modulo
    {
        [Key, Column("id_modulo")]
        public int  IdModulo { get; set; }

        [Column("descricao_modulo")]
        public string NomeModulo { get; set; }

        [ForeignKey("Curso"), Column("id_curso")]
        public int? IdCurso { get; set; }
        public virtual Curso Curso { get; set; }
    }
}