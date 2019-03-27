namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contexchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreTypeId" });
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            CreateIndex("dbo.Movies", "GenreTypeId");
            AddForeignKey("dbo.Movies", "GenreTypeId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
