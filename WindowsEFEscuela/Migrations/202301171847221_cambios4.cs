namespace WindowsEFEscuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Alumno", "Id", "dbo.Profesor");
            DropIndex("dbo.Alumno", new[] { "Id" });
            DropPrimaryKey("dbo.Alumno");
            AddColumn("dbo.Alumno", "ProfesorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Alumno", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Alumno", "Id");
            CreateIndex("dbo.Alumno", "ProfesorId");
            AddForeignKey("dbo.Alumno", "ProfesorId", "dbo.Profesor", "ProfesorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumno", "ProfesorId", "dbo.Profesor");
            DropIndex("dbo.Alumno", new[] { "ProfesorId" });
            DropPrimaryKey("dbo.Alumno");
            AlterColumn("dbo.Alumno", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.Alumno", "ProfesorId");
            AddPrimaryKey("dbo.Alumno", "Id");
            CreateIndex("dbo.Alumno", "Id");
            AddForeignKey("dbo.Alumno", "Id", "dbo.Profesor", "ProfesorId");
        }
    }
}
