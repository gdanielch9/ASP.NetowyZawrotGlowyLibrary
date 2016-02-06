namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Titlerequiredinbookmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Title", c => c.String());
        }
    }
}
