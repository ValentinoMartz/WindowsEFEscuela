namespace WindowsEFEscuela.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AulaYMateria : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Aulas", newName: "Aula");
            RenameTable(name: "dbo.Materias", newName: "Materia");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Materia", newName: "Materias");
            RenameTable(name: "dbo.Aula", newName: "Aulas");
        }
    }
}
