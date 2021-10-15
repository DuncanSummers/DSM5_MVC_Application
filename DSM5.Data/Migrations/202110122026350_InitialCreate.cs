namespace DSM5.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comorbidity",
                c => new
                    {
                        BaseID = c.Int(nullable: false),
                        ComorbidityID = c.Int(nullable: false),
                        Disorder_DisorderID = c.Int(),
                    })
                .PrimaryKey(t => t.BaseID)
                .ForeignKey("dbo.Disorder", t => t.Disorder_DisorderID)
                .ForeignKey("dbo.Disorder", t => t.ComorbidityID, cascadeDelete: true)
                .ForeignKey("dbo.Disorder", t => t.BaseID)
                .Index(t => t.BaseID)
                .Index(t => t.ComorbidityID)
                .Index(t => t.Disorder_DisorderID);
            
            CreateTable(
                "dbo.Disorder",
                c => new
                    {
                        DisorderID = c.Int(nullable: false, identity: true),
                        ICD = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        DisorderName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DisorderID);
            
            CreateTable(
                "dbo.DisorderSymptom",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DisorderID = c.Int(nullable: false),
                        SymptomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Disorder", t => t.DisorderID, cascadeDelete: true)
                .ForeignKey("dbo.Symptom", t => t.SymptomID, cascadeDelete: true)
                .Index(t => t.DisorderID)
                .Index(t => t.SymptomID);
            
            CreateTable(
                "dbo.Symptom",
                c => new
                    {
                        SymptomID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SymptomID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Comorbidity", "BaseID", "dbo.Disorder");
            DropForeignKey("dbo.Comorbidity", "ComorbidityID", "dbo.Disorder");
            DropForeignKey("dbo.DisorderSymptom", "SymptomID", "dbo.Symptom");
            DropForeignKey("dbo.DisorderSymptom", "DisorderID", "dbo.Disorder");
            DropForeignKey("dbo.Comorbidity", "Disorder_DisorderID", "dbo.Disorder");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.DisorderSymptom", new[] { "SymptomID" });
            DropIndex("dbo.DisorderSymptom", new[] { "DisorderID" });
            DropIndex("dbo.Comorbidity", new[] { "Disorder_DisorderID" });
            DropIndex("dbo.Comorbidity", new[] { "ComorbidityID" });
            DropIndex("dbo.Comorbidity", new[] { "BaseID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Symptom");
            DropTable("dbo.DisorderSymptom");
            DropTable("dbo.Disorder");
            DropTable("dbo.Comorbidity");
            DropTable("dbo.Category");
        }
    }
}
