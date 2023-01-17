namespace WindowsEFEscuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambios3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Alumno");
            AlterColumn("dbo.Alumno", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Alumno", "Id");
            CreateIndex("dbo.Alumno", "Id");
            AddForeignKey("dbo.Alumno", "Id", "dbo.Profesor", "ProfesorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alumno", "Id", "dbo.Profesor");
            DropIndex("dbo.Alumno", new[] { "Id" });
            DropPrimaryKey("dbo.Alumno");
            AlterColumn("dbo.Alumno", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Alumno", "Id");
        }
    }
}
