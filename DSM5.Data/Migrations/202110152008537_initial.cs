namespace DSM5.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comorbidity", "BaseID", "dbo.Disorder");
            DropPrimaryKey("dbo.Comorbidity");
            AddColumn("dbo.Comorbidity", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Comorbidity", "ID");
            AddForeignKey("dbo.Comorbidity", "BaseID", "dbo.Disorder", "DisorderID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comorbidity", "BaseID", "dbo.Disorder");
            DropPrimaryKey("dbo.Comorbidity");
            DropColumn("dbo.Comorbidity", "ID");
            AddPrimaryKey("dbo.Comorbidity", "BaseID");
            AddForeignKey("dbo.Comorbidity", "BaseID", "dbo.Disorder", "DisorderID");
        }
    }
}
