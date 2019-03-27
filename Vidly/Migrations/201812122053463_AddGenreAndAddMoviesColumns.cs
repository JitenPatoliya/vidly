namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreAndAddMoviesColumns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "GenreType_Id", c => c.Short(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Movies", "GenreType_Id");
            AddForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreType_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreType_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "GenreType_Id");
            DropColumn("dbo.Movies", "GenreTypeId");
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "AddedDate");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.Genres");
        }
    }
}
