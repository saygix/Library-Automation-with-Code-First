namespace NDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateKullaniciAdiColumnInKitapAlsTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.KitapAls");
            AddColumn("dbo.KitapAls", "KullaniciAdi", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.KitapAls", "KitapAdi", c => c.String());
            AddPrimaryKey("dbo.KitapAls", "KullaniciAdi");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.KitapAls");
            AlterColumn("dbo.KitapAls", "KitapAdi", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.KitapAls", "KullaniciAdi");
            AddPrimaryKey("dbo.KitapAls", "KitapAdi");
        }
    }
}
