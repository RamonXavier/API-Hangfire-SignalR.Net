using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudoR2.Models
{
    [Table("t_professores")]
    public class Professor
    {
        [Key, Column("id_professor")]
        public int IdProfessor { get; set; }

        [Column("nome_professor")]
        public string NomeProfessor { get; set; }
    }
}