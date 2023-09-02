namespace NDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIdColumnInKitapAlsTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.KitapAls");
            AddColumn("dbo.KitapAls", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.KitapAls", "KitapAdi", c => c.String());
            AddPrimaryKey("dbo.KitapAls", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.KitapAls");
            AlterColumn("dbo.KitapAls", "KitapAdi", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.KitapAls", "Id");
            AddPrimaryKey("dbo.KitapAls", "KitapAdi");
        }
    }
}
