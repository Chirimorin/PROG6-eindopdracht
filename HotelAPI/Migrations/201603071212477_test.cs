namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlternatePrices", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            RenameColumn(table: "dbo.AlternatePrices", name: "RoomId", newName: "RoomNumber");
            RenameColumn(table: "dbo.Reservations", name: "RoomId", newName: "RoomNumber");
            RenameIndex(table: "dbo.AlternatePrices", name: "IX_RoomId", newName: "IX_RoomNumber");
            RenameIndex(table: "dbo.Reservations", name: "IX_RoomId", newName: "IX_RoomNumber");
            DropPrimaryKey("dbo.Rooms", new[] { "Id" });
            DropColumn("dbo.Rooms", "Id");
            AddColumn("dbo.Rooms", "RoomNumber", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Rooms", "RoomNumber");
            AlterColumn("dbo.AlternatePrices", "NewPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Rooms", "MinPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddForeignKey("dbo.AlternatePrices", "RoomNumber", "dbo.Rooms", "RoomNumber", cascadeDelete: true);
            AddForeignKey("dbo.Reservations", "RoomNumber", "dbo.Rooms", "RoomNumber", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Reservations", "RoomNumber", "dbo.Rooms");
            DropForeignKey("dbo.AlternatePrices", "RoomNumber", "dbo.Rooms");
            DropPrimaryKey("dbo.Rooms");
            AlterColumn("dbo.Rooms", "MinPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.AlternatePrices", "NewPrice", c => c.Int(nullable: false));
            DropColumn("dbo.Rooms", "RoomNumber");
            AddPrimaryKey("dbo.Rooms", "Id");
            RenameIndex(table: "dbo.Reservations", name: "IX_RoomNumber", newName: "IX_RoomId");
            RenameIndex(table: "dbo.AlternatePrices", name: "IX_RoomNumber", newName: "IX_RoomId");
            RenameColumn(table: "dbo.Reservations", name: "RoomNumber", newName: "RoomId");
            RenameColumn(table: "dbo.AlternatePrices", name: "RoomNumber", newName: "RoomId");
            AddForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AlternatePrices", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
    }
}
