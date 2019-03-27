namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customercolumnrenamed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribeToNewsLetter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribeToNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
        }
    }
}
