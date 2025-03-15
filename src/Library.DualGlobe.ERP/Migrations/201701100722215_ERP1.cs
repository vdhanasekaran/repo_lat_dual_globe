namespace Library.DualGlobe.ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ERP1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotation", "ReferenceNumber", c => c.String());
            AddColumn("dbo.Quotation", "GSTType", c => c.String());
            DropColumn("dbo.Quotation", "IncludeGST");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quotation", "IncludeGST", c => c.Boolean(nullable: false));
            DropColumn("dbo.Quotation", "GSTType");
            DropColumn("dbo.Quotation", "ReferenceNumber");
        }
    }
}
