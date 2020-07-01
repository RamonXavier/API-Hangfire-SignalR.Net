using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoR2.Models
{
    [Table("t_cursos")]
    public class Curso
    {
        [Key, Column("id_curso")]
        public int IdCurso { get; set; }

        [Column("descricao_curso")]
        public string NomeCurso { get; set; }

    }
}