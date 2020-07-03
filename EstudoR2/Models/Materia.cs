using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudoR2.Models
{
    [Table("t_materias")]
    public class Materia
    {
        [Key, Column("id_materia")]
        public int IdMateria { get; set; }

        [Column("descricao_materia")] 
        public string NomeMateria { get; set; }
        
        [ForeignKey("Professor"), Column("id_professor")]
        public int IdProfessor { get; set; }
        public virtual Professor Professor{ get; set; }

    }
}