namespace FestivalMarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_News", "MAIN_KEYWORD", c => c.String());
            AddColumn("dbo.tb_FilmsView", "MAIN_KEYWORD", c => c.String());
            AddColumn("dbo.tb_Events", "MAIN_KEYWORD", c => c.String());
            AddColumn("dbo.tb_Product", "MAIN_KEYWORD", c => c.String());
            AddColumn("dbo.tb_Sales", "MAIN_KEYWORD", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Sales", "MAIN_KEYWORD");
            DropColumn("dbo.tb_Product", "MAIN_KEYWORD");
            DropColumn("dbo.tb_Events", "MAIN_KEYWORD");
            DropColumn("dbo.tb_FilmsView", "MAIN_KEYWORD");
            DropColumn("dbo.tb_News", "MAIN_KEYWORD");
        }
    }
}
