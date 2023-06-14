namespace AlirezaAbasi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignedBooks", "members_RegisterCode", "dbo.Members");
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Members");
            AlterColumn("dbo.Books", "Code", c => c.Int(nullable: false));
            AlterColumn("dbo.Members", "RegisterCode", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Books", "Code");
            AddPrimaryKey("dbo.Members", "RegisterCode");
            AddForeignKey("dbo.AssignedBooks", "members_RegisterCode", "dbo.Members", "RegisterCode");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedBooks", "members_RegisterCode", "dbo.Members");
            DropPrimaryKey("dbo.Members");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Members", "RegisterCode", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Books", "Code", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Members", "RegisterCode");
            AddPrimaryKey("dbo.Books", "Code");
            AddForeignKey("dbo.AssignedBooks", "members_RegisterCode", "dbo.Members", "RegisterCode");
        }
    }
}
