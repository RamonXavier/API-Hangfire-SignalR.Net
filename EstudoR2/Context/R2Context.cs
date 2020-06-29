using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EstudoR2.Models;

namespace EstudoR2.Context
{
    public class R2Context : DbContext
    {
        public R2Context() 
            : base("R2")
        {
        }

        private DbSet<Aluno> Alunos { get; set; }
        private DbSet<Atividade> Atividades { get; set; }
        private DbSet<Curso> Cursos { get; set; }
        private DbSet<Materia> Materias { get; set; }
        private DbSet<Modulo> Modulos{ get; set; }
        private DbSet<Nota> Notas { get; set; }
        private DbSet<Presenca> Presencas{ get; set; }
        private DbSet<Professor> Professores{ get; set; }
        private DbSet<Turma> Turmas { get; set; }

    }
}