namespace VendasBeck.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.eventos",
                c => new
                    {
                        idEvento = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        data = c.DateTime(),
                    })
                .PrimaryKey(t => t.idEvento);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.eventos");
        }
    }
}
