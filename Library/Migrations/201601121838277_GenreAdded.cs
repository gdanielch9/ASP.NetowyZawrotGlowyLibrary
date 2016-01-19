namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "GenreId", c => c.Int());
            CreateIndex("dbo.Books", "GenreId");
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropColumn("dbo.Books", "GenreId");
            DropTable("dbo.Genres");
        }
    }
}
