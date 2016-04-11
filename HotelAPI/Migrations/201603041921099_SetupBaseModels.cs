namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupBaseModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Street = c.String(nullable: false),
                        Number = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        City = c.String(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Confirmations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationId = c.Int(nullable: false),
                        TotalPrice = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        BankNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Reservations", t => t.ReservationId)
                .Index(t => t.ReservationId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Rooms", t => t.RoomNumber)
                .Index(t => t.AddressId)
                .Index(t => t.RoomNumber);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                        Reservation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Reservation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Confirmations", "ReservationId", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "RoomNumber", "dbo.Rooms");
            DropForeignKey("dbo.People", "Reservation_Id", "dbo.Reservations");
            DropForeignKey("dbo.People", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reservations", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Confirmations", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.People", new[] { "Reservation_Id" });
            DropIndex("dbo.People", new[] { "User_Id" });
            DropIndex("dbo.Reservations", new[] { "RoomNumber" });
            DropIndex("dbo.Reservations", new[] { "AddressId" });
            DropIndex("dbo.Confirmations", new[] { "AddressId" });
            DropIndex("dbo.Confirmations", new[] { "ReservationId" });
            DropIndex("dbo.Addresses", new[] { "User_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Reservations");
            DropTable("dbo.Confirmations");
            DropTable("dbo.Addresses");
        }
    }
}
