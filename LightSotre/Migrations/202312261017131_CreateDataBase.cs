namespace LightSotre.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fatura",
                c => new
                    {
                        FaturaNO = c.Int(nullable: false),
                        Tatuar = c.Double(nullable: false),
                        SiparisNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FaturaNO)
                .ForeignKey("dbo.Siparis", t => t.SiparisNo)
                .Index(t => t.SiparisNo);
            
            CreateTable(
                "dbo.Odeme",
                c => new
                    {
                        OdemeId = c.String(nullable: false, maxLength: 50),
                        SepetNO = c.Int(nullable: false),
                        OdemeSecenek = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        FauraNO = c.Int(nullable: false),
                        Tutar = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OdemeId)
                .ForeignKey("dbo.Sepet", t => t.SepetNO)
                .ForeignKey("dbo.Fatura", t => t.FauraNO)
                .Index(t => t.SepetNO)
                .Index(t => t.FauraNO);
            
            CreateTable(
                "dbo.Sepet",
                c => new
                    {
                        SepetNO = c.Int(nullable: false, identity: true),
                        SepetTutar = c.Double(nullable: false),
                        Urun_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SepetNO)
                .ForeignKey("dbo.Urun", t => t.Urun_ID)
                .Index(t => t.Urun_ID);
            
            CreateTable(
                "dbo.Urun",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunIsim = c.String(nullable: false, maxLength: 50),
                        Kategore_ID = c.Int(nullable: false),
                        urunFiyat = c.Double(nullable: false),
                        urunOzellikler = c.String(),
                        urunImage = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.UrunId)
                .ForeignKey("dbo.Kategore", t => t.Kategore_ID)
                .Index(t => t.Kategore_ID);
            
            CreateTable(
                "dbo.Kategore",
                c => new
                    {
                        KatagoreId = c.Int(nullable: false, identity: true),
                        KategoreIsim = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.KatagoreId);
            
            CreateTable(
                "dbo.Satici",
                c => new
                    {
                        SaticiNo = c.Int(nullable: false),
                        SaticiIsim = c.String(nullable: false, maxLength: 50),
                        Saticitel = c.String(maxLength: 11, fixedLength: true),
                        SaticiAdres = c.String(),
                        UyeNo = c.Int(nullable: false),
                        Login_AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SaticiNo)
                .ForeignKey("dbo.Login", t => t.Login_AdminID)
                .Index(t => t.Login_AdminID);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Passowrd = c.String(nullable: false, maxLength: 50),
                        Eposta = c.String(maxLength: 25),
                        Role = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Musteri",
                c => new
                    {
                        musteriId = c.Int(nullable: false),
                        MusteriIsim = c.String(nullable: false, maxLength: 50, unicode: false),
                        MusteriTel = c.String(maxLength: 11, fixedLength: true),
                        MusteriAdres = c.String(),
                        UyeNO = c.Int(nullable: false),
                        Login_AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.musteriId)
                .ForeignKey("dbo.Login", t => t.Login_AdminID)
                .Index(t => t.Login_AdminID);
            
            CreateTable(
                "dbo.Siparis",
                c => new
                    {
                        SiparisNo = c.Int(nullable: false),
                        MusteriId = c.Int(nullable: false),
                        SaticiNo = c.Int(nullable: false),
                        KaregoId = c.String(nullable: false, maxLength: 50),
                        SiparisTarih = c.DateTime(nullable: false),
                        SiparisDurum = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        FiyatTutar = c.Double(nullable: false),
                        UlastirmaZamani = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SiparisNo)
                .ForeignKey("dbo.Musteri", t => t.MusteriId)
                .ForeignKey("dbo.Satici", t => t.SaticiNo)
                .Index(t => t.MusteriId)
                .Index(t => t.SaticiNo);
            
            CreateTable(
                "dbo.SiparisAdres",
                c => new
                    {
                        SipAdreID = c.Int(nullable: false),
                        il = c.String(nullable: false, maxLength: 50),
                        ilce = c.String(nullable: false, maxLength: 50),
                        Mahalle = c.String(nullable: false, maxLength: 50),
                        Ev = c.String(nullable: false, maxLength: 50),
                        SiparisNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SipAdreID)
                .ForeignKey("dbo.Siparis", t => t.SiparisNo)
                .Index(t => t.SiparisNo);
            
            CreateTable(
                "dbo.MusteriSatici",
                c => new
                    {
                        MusteriId = c.Int(nullable: false),
                        SaticiNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MusteriId, t.SaticiNo })
                .ForeignKey("dbo.Musteri", t => t.MusteriId, cascadeDelete: true)
                .ForeignKey("dbo.Satici", t => t.SaticiNo, cascadeDelete: true)
                .Index(t => t.MusteriId)
                .Index(t => t.SaticiNo);
            
            CreateTable(
                "dbo.SiparisUrun",
                c => new
                    {
                        SiparisNo = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SiparisNo, t.UrunId })
                .ForeignKey("dbo.Siparis", t => t.SiparisNo, cascadeDelete: true)
                .ForeignKey("dbo.Urun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.SiparisNo)
                .Index(t => t.UrunId);
            
            CreateTable(
                "dbo.SaticiUrun",
                c => new
                    {
                        SaticiNo = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SaticiNo, t.UrunId })
                .ForeignKey("dbo.Satici", t => t.SaticiNo, cascadeDelete: true)
                .ForeignKey("dbo.Urun", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.SaticiNo)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Odeme", "FauraNO", "dbo.Fatura");
            DropForeignKey("dbo.Sepet", "Urun_ID", "dbo.Urun");
            DropForeignKey("dbo.SaticiUrun", "UrunId", "dbo.Urun");
            DropForeignKey("dbo.SaticiUrun", "SaticiNo", "dbo.Satici");
            DropForeignKey("dbo.Siparis", "SaticiNo", "dbo.Satici");
            DropForeignKey("dbo.Satici", "Login_AdminID", "dbo.Login");
            DropForeignKey("dbo.Musteri", "Login_AdminID", "dbo.Login");
            DropForeignKey("dbo.Siparis", "MusteriId", "dbo.Musteri");
            DropForeignKey("dbo.SiparisUrun", "UrunId", "dbo.Urun");
            DropForeignKey("dbo.SiparisUrun", "SiparisNo", "dbo.Siparis");
            DropForeignKey("dbo.SiparisAdres", "SiparisNo", "dbo.Siparis");
            DropForeignKey("dbo.Fatura", "SiparisNo", "dbo.Siparis");
            DropForeignKey("dbo.MusteriSatici", "SaticiNo", "dbo.Satici");
            DropForeignKey("dbo.MusteriSatici", "MusteriId", "dbo.Musteri");
            DropForeignKey("dbo.Urun", "Kategore_ID", "dbo.Kategore");
            DropForeignKey("dbo.Odeme", "SepetNO", "dbo.Sepet");
            DropIndex("dbo.SaticiUrun", new[] { "UrunId" });
            DropIndex("dbo.SaticiUrun", new[] { "SaticiNo" });
            DropIndex("dbo.SiparisUrun", new[] { "UrunId" });
            DropIndex("dbo.SiparisUrun", new[] { "SiparisNo" });
            DropIndex("dbo.MusteriSatici", new[] { "SaticiNo" });
            DropIndex("dbo.MusteriSatici", new[] { "MusteriId" });
            DropIndex("dbo.SiparisAdres", new[] { "SiparisNo" });
            DropIndex("dbo.Siparis", new[] { "SaticiNo" });
            DropIndex("dbo.Siparis", new[] { "MusteriId" });
            DropIndex("dbo.Musteri", new[] { "Login_AdminID" });
            DropIndex("dbo.Satici", new[] { "Login_AdminID" });
            DropIndex("dbo.Urun", new[] { "Kategore_ID" });
            DropIndex("dbo.Sepet", new[] { "Urun_ID" });
            DropIndex("dbo.Odeme", new[] { "FauraNO" });
            DropIndex("dbo.Odeme", new[] { "SepetNO" });
            DropIndex("dbo.Fatura", new[] { "SiparisNo" });
            DropTable("dbo.SaticiUrun");
            DropTable("dbo.SiparisUrun");
            DropTable("dbo.MusteriSatici");
            DropTable("dbo.SiparisAdres");
            DropTable("dbo.Siparis");
            DropTable("dbo.Musteri");
            DropTable("dbo.Login");
            DropTable("dbo.Satici");
            DropTable("dbo.Kategore");
            DropTable("dbo.Urun");
            DropTable("dbo.Sepet");
            DropTable("dbo.Odeme");
            DropTable("dbo.Fatura");
        }
    }
}
