namespace NDP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        tc = c.String(nullable: false, maxLength: 128),
                        ad = c.String(),
                        soyad = c.String(),
                        dtarihi = c.String(),
                        telno = c.String(),
                        sifre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tc);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanicis");
        }
    }
}
