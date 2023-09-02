namespace NDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateIdColumnInİadeTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.İade");
            DropPrimaryKey("dbo.KitapAls");
            AddColumn("dbo.İade", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.İade", "KullaniciAdi", c => c.String());
            AlterColumn("dbo.KitapAls", "KullaniciAdi", c => c.String());
            AlterColumn("dbo.KitapAls", "KitapAdi", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.İade", "Id");
            AddPrimaryKey("dbo.KitapAls", "KitapAdi");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.KitapAls");
            DropPrimaryKey("dbo.İade");
            AlterColumn("dbo.KitapAls", "KitapAdi", c => c.String());
            AlterColumn("dbo.KitapAls", "KullaniciAdi", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.İade", "KullaniciAdi", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.İade", "Id");
            AddPrimaryKey("dbo.KitapAls", "KullaniciAdi");
            AddPrimaryKey("dbo.İade", "KullaniciAdi");
        }
    }
}
