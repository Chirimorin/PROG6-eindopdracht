namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupBaseModels1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlternatePrices", "RoomNumber", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "RoomNumber", "dbo.Rooms");
            DropIndex("dbo.AlternatePrices", new[] { "RoomNumber" });
            DropIndex("dbo.Reservations", new[] { "RoomNumber" });
            DropPrimaryKey("dbo.Rooms");
            DropColumn("dbo.Rooms", "RoomNumber" );
            AddColumn("dbo.Rooms", "RoomNumber", c=> c.Int(nullable: false));
            AddColumn("dbo.AlternatePrices", "Room_Id", c => c.Int());
            AddColumn("dbo.Rooms", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Reservations", "Room_Id", c => c.Int());
            AlterColumn("dbo.Rooms", "RoomNumber", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Rooms", "Id");
            CreateIndex("dbo.AlternatePrices", "Room_Id");
            CreateIndex("dbo.Reservations", "Room_Id");
            AddForeignKey("dbo.AlternatePrices", "Room_Id", "dbo.Rooms", "Id");
            AddForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservations", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.AlternatePrices", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "Room_Id" });
            DropIndex("dbo.AlternatePrices", new[] { "Room_Id" });
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "RoomNumber", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Reservations", "Room_Id");
            DropColumn("dbo.Rooms", "Id");
            DropColumn("dbo.AlternatePrices", "Room_Id");
            AddPrimaryKey("dbo.Rooms", "RoomNumber");
            CreateIndex("dbo.Reservations", "RoomNumber");
            CreateIndex("dbo.AlternatePrices", "RoomNumber");
            AddForeignKey("dbo.Reservations", "RoomNumber", "dbo.Rooms", "RoomNumber", cascadeDelete: true);
            AddForeignKey("dbo.AlternatePrices", "RoomNumber", "dbo.Rooms", "RoomNumber", cascadeDelete: true);
        }
    }
}
