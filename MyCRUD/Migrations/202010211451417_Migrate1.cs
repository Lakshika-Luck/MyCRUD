namespace MyCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrate1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branch_tbl",
                c => new
                    {
                        BranchNo = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.BranchNo);
            
            CreateTable(
                "dbo.Rent_tbl",
                c => new
                    {
                        PropertyNo = c.String(nullable: false, maxLength: 128),
                        Street = c.String(),
                        City = c.String(),
                        Ptype = c.String(),
                        Rooms = c.Int(nullable: false),
                        OwnerNoRef = c.String(maxLength: 128),
                        StaffNoRef = c.String(maxLength: 128),
                        BranchNoRef = c.String(maxLength: 128),
                        rent1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyNo)
                .ForeignKey("dbo.Branch_tbl", t => t.BranchNoRef)
                .ForeignKey("dbo.Owner_tbl", t => t.OwnerNoRef)
                .ForeignKey("dbo.Staff_tbl", t => t.StaffNoRef)
                .Index(t => t.OwnerNoRef)
                .Index(t => t.StaffNoRef)
                .Index(t => t.BranchNoRef);
            
            CreateTable(
                "dbo.Owner_tbl",
                c => new
                    {
                        OwnerNo = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        Address = c.String(),
                        TelNo = c.String(),
                    })
                .PrimaryKey(t => t.OwnerNo);
            
            CreateTable(
                "dbo.Staff_tbl",
                c => new
                    {
                        StaffNo = c.String(nullable: false, maxLength: 128),
                        Fname = c.String(),
                        Lname = c.String(),
                        Position = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Salary = c.Int(nullable: false),
                        BranchNoRef = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StaffNo)
                .ForeignKey("dbo.Branch_tbl", t => t.BranchNoRef)
                .Index(t => t.BranchNoRef);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rent_tbl", "StaffNoRef", "dbo.Staff_tbl");
            DropForeignKey("dbo.Staff_tbl", "BranchNoRef", "dbo.Branch_tbl");
            DropForeignKey("dbo.Rent_tbl", "OwnerNoRef", "dbo.Owner_tbl");
            DropForeignKey("dbo.Rent_tbl", "BranchNoRef", "dbo.Branch_tbl");
            DropIndex("dbo.Staff_tbl", new[] { "BranchNoRef" });
            DropIndex("dbo.Rent_tbl", new[] { "BranchNoRef" });
            DropIndex("dbo.Rent_tbl", new[] { "StaffNoRef" });
            DropIndex("dbo.Rent_tbl", new[] { "OwnerNoRef" });
            DropTable("dbo.Staff_tbl");
            DropTable("dbo.Owner_tbl");
            DropTable("dbo.Rent_tbl");
            DropTable("dbo.Branch_tbl");
        }
    }
}
