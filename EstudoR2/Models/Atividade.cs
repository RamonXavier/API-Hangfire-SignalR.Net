using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoR2.Models
{
    [Table("t_atividades")]
    public class Atividade
    {
        [Key, Column("id_atividade")] 
        public int IdAtividade { get; set; }
        public string descricao_atividade { get; set; }

        [ForeignKey("Turma"), Column("id_turma")]
        public int IdTurma { get; set; }
        public virtual Turma Turma { get; set; }

        [ForeignKey("Materia"), Column("id_materia")]
        public int IdMateria { get; set; }
        public virtual Materia Materia { get; set; }
    }
}