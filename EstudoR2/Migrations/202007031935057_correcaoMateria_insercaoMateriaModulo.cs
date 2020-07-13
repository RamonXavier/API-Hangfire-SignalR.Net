namespace EstudoR2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoMateria_insercaoMateriaModulo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.t_materias", "id_modulo", "dbo.t_modulos");
            DropIndex("dbo.t_materias", new[] { "id_modulo" });
            CreateTable(
                "dbo.t_materias_modulos",
                c => new
                    {
                        id_materia_modulo = c.Int(nullable: false, identity: true),
                        id_materia = c.Int(nullable: false),
                        id_modulo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_materia_modulo)
                .ForeignKey("dbo.t_materias", t => t.id_materia, cascadeDelete: false)
                .ForeignKey("dbo.t_modulos", t => t.id_modulo, cascadeDelete: false)
                .Index(t => t.id_materia)
                .Index(t => t.id_modulo);
            
            DropColumn("dbo.t_materias", "id_modulo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.t_materias", "id_modulo", c => c.Int(nullable: false));
            DropForeignKey("dbo.t_materias_modulos", "id_modulo", "dbo.t_modulos");
            DropForeignKey("dbo.t_materias_modulos", "id_materia", "dbo.t_materias");
            DropIndex("dbo.t_materias_modulos", new[] { "id_modulo" });
            DropIndex("dbo.t_materias_modulos", new[] { "id_materia" });
            DropTable("dbo.t_materias_modulos");
            CreateIndex("dbo.t_materias", "id_modulo");
            AddForeignKey("dbo.t_materias", "id_modulo", "dbo.t_modulos", "id_modulo", cascadeDelete: true);
        }
    }
}
