namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Users : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "UserId");
            AddForeignKey("dbo.Books", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "UserId" });
            DropColumn("dbo.Books", "UserId");
        }
    }
}
