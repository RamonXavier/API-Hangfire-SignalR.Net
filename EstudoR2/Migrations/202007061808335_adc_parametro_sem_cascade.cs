namespace EstudoR2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adc_parametro_sem_cascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.t_alunos", "id_curso", "dbo.t_cursos");
            DropForeignKey("dbo.t_alunos", "id_turma", "dbo.t_turmas");
            DropForeignKey("dbo.t_turmas", "id_modulo", "dbo.t_modulos");
            DropForeignKey("dbo.t_atividades", "id_materia", "dbo.t_materias");
            DropForeignKey("dbo.t_atividades", "id_turma", "dbo.t_turmas");
            DropForeignKey("dbo.t_materias", "id_professor", "dbo.t_professores");
            DropForeignKey("dbo.t_materias_modulos", "id_materia", "dbo.t_materias");
            DropForeignKey("dbo.t_materias_modulos", "id_modulo", "dbo.t_modulos");
            DropForeignKey("dbo.t_notas", "id_aluno", "dbo.t_alunos");
            DropForeignKey("dbo.t_notas", "id_atividade", "dbo.t_atividades");
            DropForeignKey("dbo.t_aluno_presencas", "id_aluno", "dbo.t_alunos");
            AddForeignKey("dbo.t_alunos", "id_curso", "dbo.t_cursos", "id_curso");
            AddForeignKey("dbo.t_alunos", "id_turma", "dbo.t_turmas", "id_turma");
            AddForeignKey("dbo.t_turmas", "id_modulo", "dbo.t_modulos", "id_modulo");
            AddForeignKey("dbo.t_atividades", "id_materia", "dbo.t_materias", "id_materia");
            AddForeignKey("dbo.t_atividades", "id_turma", "dbo.t_turmas", "id_turma");
            AddForeignKey("dbo.t_materias", "id_professor", "dbo.t_professores", "id_professor");
            AddForeignKey("dbo.t_materias_modulos", "id_materia", "dbo.t_materias", "id_materia");
            AddForeignKey("dbo.t_materias_modulos", "id_modulo", "dbo.t_modulos", "id_modulo");
            AddForeignKey("dbo.t_notas", "id_aluno", "dbo.t_alunos", "id_aluno");
            AddForeignKey("dbo.t_notas", "id_atividade", "dbo.t_atividades", "id_atividade");
            AddForeignKey("dbo.t_aluno_presencas", "id_aluno", "dbo.t_alunos", "id_aluno");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_aluno_presencas", "id_aluno", "dbo.t_alunos");
            DropForeignKey("dbo.t_notas", "id_atividade", "dbo.t_atividades");
            DropForeignKey("dbo.t_notas", "id_aluno", "dbo.t_alunos");
            DropForeignKey("dbo.t_materias_modulos", "id_modulo", "dbo.t_modulos");
            DropForeignKey("dbo.t_materias_modulos", "id_materia", "dbo.t_materias");
            DropForeignKey("dbo.t_materias", "id_professor", "dbo.t_professores");
            DropForeignKey("dbo.t_atividades", "id_turma", "dbo.t_turmas");
            DropForeignKey("dbo.t_atividades", "id_materia", "dbo.t_materias");
            DropForeignKey("dbo.t_turmas", "id_modulo", "dbo.t_modulos");
            DropForeignKey("dbo.t_alunos", "id_turma", "dbo.t_turmas");
            DropForeignKey("dbo.t_alunos", "id_curso", "dbo.t_cursos");
            AddForeignKey("dbo.t_aluno_presencas", "id_aluno", "dbo.t_alunos", "id_aluno", cascadeDelete: true);
            AddForeignKey("dbo.t_notas", "id_atividade", "dbo.t_atividades", "id_atividade", cascadeDelete: true);
            AddForeignKey("dbo.t_notas", "id_aluno", "dbo.t_alunos", "id_aluno", cascadeDelete: true);
            AddForeignKey("dbo.t_materias_modulos", "id_modulo", "dbo.t_modulos", "id_modulo", cascadeDelete: true);
            AddForeignKey("dbo.t_materias_modulos", "id_materia", "dbo.t_materias", "id_materia", cascadeDelete: true);
            AddForeignKey("dbo.t_materias", "id_professor", "dbo.t_professores", "id_professor", cascadeDelete: true);
            AddForeignKey("dbo.t_atividades", "id_turma", "dbo.t_turmas", "id_turma", cascadeDelete: true);
            AddForeignKey("dbo.t_atividades", "id_materia", "dbo.t_materias", "id_materia", cascadeDelete: true);
            AddForeignKey("dbo.t_turmas", "id_modulo", "dbo.t_modulos", "id_modulo", cascadeDelete: true);
            AddForeignKey("dbo.t_alunos", "id_turma", "dbo.t_turmas", "id_turma", cascadeDelete: true);
            AddForeignKey("dbo.t_alunos", "id_curso", "dbo.t_cursos", "id_curso", cascadeDelete: true);
        }
    }
}
