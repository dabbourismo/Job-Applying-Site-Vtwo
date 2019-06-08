namespace JobApplicationSiteVtwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Jobs_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Job_Model",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        JobContent = c.String(),
                        JobImage = c.String(),
                        Categories_ModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories_Model", t => t.Categories_ModelId, cascadeDelete: true)
                .Index(t => t.Categories_ModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Job_Model", "Categories_ModelId", "dbo.Categories_Model");
            DropIndex("dbo.Job_Model", new[] { "Categories_ModelId" });
            DropTable("dbo.Job_Model");
        }
    }
}
