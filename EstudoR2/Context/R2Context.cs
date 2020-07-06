using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Modulo> Modulos{ get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Presenca> Presencas{ get; set; }
        public DbSet<Professor> Professores{ get; set; }
        private DbSet<Turma> Turmas { get; set; }
        public DbSet<MateriaModulo> MateriasModulos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
             modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

    }
}