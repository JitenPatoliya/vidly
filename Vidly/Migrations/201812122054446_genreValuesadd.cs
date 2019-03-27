namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreValuesadd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreType_Id" });
            DropColumn("dbo.Movies", "GenreTypeId");
            RenameColumn(table: "dbo.Movies", name: "GenreType_Id", newName: "GenreTypeId");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres", "Id", cascadeDelete: true);

            Sql("INSERT INTO Genres ( Name) VALUES ( 'Comedy')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Action')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Family')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Romance')");
            Sql("INSERT INTO Genres ( Name) VALUES ( 'Horror')");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "GenreTypeId", c => c.Short(nullable: false));
            AlterColumn("dbo.Genres", "Name", c => c.String());
            AlterColumn("dbo.Genres", "Id", c => c.Short(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "Id");
            RenameColumn(table: "dbo.Movies", name: "GenreTypeId", newName: "GenreType_Id");
            AddColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreType_Id");
            AddForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
