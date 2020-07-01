namespace EstudoR2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.t_alunos",
                c => new
                    {
                        id_aluno = c.Int(nullable: false, identity: true),
                        NomeAluno = c.String(),
                        id_curso = c.Int(nullable: false),
                        id_turma = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_aluno)
                .ForeignKey("dbo.t_cursos", t => t.id_curso, cascadeDelete: false)
                .ForeignKey("dbo.t_turmas", t => t.id_turma, cascadeDelete: false)
                .Index(t => t.id_curso)
                .Index(t => t.id_turma);
            
            CreateTable(
                "dbo.t_cursos",
                c => new
                    {
                        id_curso = c.Int(nullable: false, identity: true),
                        descricao_curso = c.String(),
                    })
                .PrimaryKey(t => t.id_curso);
            
            CreateTable(
                "dbo.t_modulos",
                c => new
                    {
                        id_modulo = c.Int(nullable: false, identity: true),
                        descricao_modulo = c.String(),
                        id_curso = c.Int(),
                    })
                .PrimaryKey(t => t.id_modulo)
                .ForeignKey("dbo.t_cursos", t => t.id_curso, cascadeDelete:false)
                .Index(t => t.id_curso);
            
            CreateTable(
                "dbo.t_turmas",
                c => new
                    {
                        id_turma = c.Int(nullable: false, identity: true),
                        descricao_turma = c.String(),
                        id_modulo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_turma)
                .ForeignKey("dbo.t_modulos", t => t.id_modulo, cascadeDelete: true)
                .Index(t => t.id_modulo);
            
            CreateTable(
                "dbo.t_atividades",
                c => new
                    {
                        id_atividade = c.Int(nullable: false, identity: true),
                        descricao_atividade = c.String(),
                        id_turma = c.Int(nullable: false),
                        id_materia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_atividade)
                .ForeignKey("dbo.t_materias", t => t.id_materia, cascadeDelete: false)
                .ForeignKey("dbo.t_turmas", t => t.id_turma, cascadeDelete: false)
                .Index(t => t.id_turma)
                .Index(t => t.id_materia);
            
            CreateTable(
                "dbo.t_materias",
                c => new
                    {
                        id_materia = c.Int(nullable: false, identity: true),
                        descricao_materia = c.String(),
                        id_modulo = c.Int(nullable: false),
                        id_professor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_materia)
                .ForeignKey("dbo.t_modulos", t => t.id_modulo, cascadeDelete: false)
                .ForeignKey("dbo.t_professores", t => t.id_professor, cascadeDelete: false)
                .Index(t => t.id_modulo)
                .Index(t => t.id_professor);
            
            CreateTable(
                "dbo.t_professores",
                c => new
                    {
                        id_professor = c.Int(nullable: false, identity: true),
                        nome_professor = c.String(),
                    })
                .PrimaryKey(t => t.id_professor);
            
            CreateTable(
                "dbo.t_notas",
                c => new
                    {
                        id_nota = c.Int(nullable: false, identity: true),
                        id_aluno = c.Int(nullable: false),
                        id_atividade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_nota)
                .ForeignKey("dbo.t_alunos", t => t.id_aluno, cascadeDelete: false)
                .ForeignKey("dbo.t_atividades", t => t.id_atividade, cascadeDelete: false)
                .Index(t => t.id_aluno)
                .Index(t => t.id_atividade);
            
            CreateTable(
                "dbo.t_aluno_presencas",
                c => new
                    {
                        id_aluno_presenca = c.Int(nullable: false, identity: true),
                        id_aluno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_aluno_presenca)
                .ForeignKey("dbo.t_alunos", t => t.id_aluno, cascadeDelete: false)
                .Index(t => t.id_aluno);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.t_aluno_presencas", "id_aluno", "dbo.t_alunos");
            DropForeignKey("dbo.t_notas", "id_atividade", "dbo.t_atividades");
            DropForeignKey("dbo.t_notas", "id_aluno", "dbo.t_alunos");
            DropForeignKey("dbo.t_atividades", "id_turma", "dbo.t_turmas");
            DropForeignKey("dbo.t_atividades", "id_materia", "dbo.t_materias");
            DropForeignKey("dbo.t_materias", "id_professor", "dbo.t_professores");
            DropForeignKey("dbo.t_materias", "id_modulo", "dbo.t_modulos");
            DropForeignKey("dbo.t_alunos", "id_turma", "dbo.t_turmas");
            DropForeignKey("dbo.t_turmas", "id_modulo", "dbo.t_modulos");
            DropForeignKey("dbo.t_alunos", "id_curso", "dbo.t_cursos");
            DropForeignKey("dbo.t_modulos", "id_curso", "dbo.t_cursos");
            DropIndex("dbo.t_aluno_presencas", new[] { "id_aluno" });
            DropIndex("dbo.t_notas", new[] { "id_atividade" });
            DropIndex("dbo.t_notas", new[] { "id_aluno" });
            DropIndex("dbo.t_materias", new[] { "id_professor" });
            DropIndex("dbo.t_materias", new[] { "id_modulo" });
            DropIndex("dbo.t_atividades", new[] { "id_materia" });
            DropIndex("dbo.t_atividades", new[] { "id_turma" });
            DropIndex("dbo.t_turmas", new[] { "id_modulo" });
            DropIndex("dbo.t_modulos", new[] { "id_curso" });
            DropIndex("dbo.t_alunos", new[] { "id_turma" });
            DropIndex("dbo.t_alunos", new[] { "id_curso" });
            DropTable("dbo.t_aluno_presencas");
            DropTable("dbo.t_notas");
            DropTable("dbo.t_professores");
            DropTable("dbo.t_materias");
            DropTable("dbo.t_atividades");
            DropTable("dbo.t_turmas");
            DropTable("dbo.t_modulos");
            DropTable("dbo.t_cursos");
            DropTable("dbo.t_alunos");
        }
    }
}
