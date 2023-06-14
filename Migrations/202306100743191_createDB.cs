namespace AlirezaAbasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        members_RegisterCode = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.members_RegisterCode)
                .Index(t => t.members_RegisterCode);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Code = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100, unicode: false),
                        Writer = c.String(nullable: false, maxLength: 50, unicode: false),
                        AssignedBooks_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.AssignedBooks", t => t.AssignedBooks_Id)
                .Index(t => t.AssignedBooks_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        RegisterCode = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50, unicode: false),
                        RegisterDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.RegisterCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedBooks", "members_RegisterCode", "dbo.Members");
            DropForeignKey("dbo.Books", "AssignedBooks_Id", "dbo.AssignedBooks");
            DropIndex("dbo.Books", new[] { "AssignedBooks_Id" });
            DropIndex("dbo.AssignedBooks", new[] { "members_RegisterCode" });
            DropTable("dbo.Members");
            DropTable("dbo.Books");
            DropTable("dbo.AssignedBooks");
        }
    }
}
