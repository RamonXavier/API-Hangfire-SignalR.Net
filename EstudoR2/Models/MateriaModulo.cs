using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EstudoR2.Models
{
    [Table("t_materias_modulos")]
    public class MateriaModulo
    {
        [Key, Column("id_materia_modulo")]
        public int IdMateriaModulo { get; set; }

        [ForeignKey("Materia"), Column("id_materia")]
        public int idMateria { get; set; }

        public virtual Materia Materia { get; set; }

        [ForeignKey("Modulo"), Column("id_modulo")]
        public int IdModulo { get; set; }

        public virtual Modulo Modulo { get; set; }
    }
}