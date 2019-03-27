namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genretyperemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "GenreTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
        }
    }
}
