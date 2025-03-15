namespace Library.DualGlobe.ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ERP : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendance",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(),
                        EmployeeName = c.String(),
                        IsPresent = c.String(),
                        AttendanceDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Designation = c.String(),
                        DateOfBirth = c.String(),
                        Age = c.Int(),
                        Address = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        EmailId = c.String(),
                        BasicSalary = c.String(),
                        WorkPermitNumber = c.String(),
                        CPF = c.Int(),
                        OT = c.Int(),
                        Status = c.String(),
                        Category = c.String(),
                        Experience = c.String(),
                        PhoneNumber = c.String(),
                        BloodGroup = c.String(),
                        PassportNumber = c.String(),
                        NRICNumber = c.String(),
                        Attachment1Path = c.String(),
                        Attachment2Path = c.String(),
                        PhotoImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalaryDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(),
                        EmployeeName = c.String(),
                        PresentDays = c.Int(),
                        LeaveDays = c.Int(),
                        BasicSalary = c.String(),
                        DetectSalary = c.String(),
                        Additions = c.String(),
                        GrossSalary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Timesheet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProjectName = c.String(),
                        EmployeeId = c.String(),
                        EmployeeName = c.String(),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        RegularHours = c.Int(),
                        OTHours = c.Int(),
                        TotalHours = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Timesheet");
            DropTable("dbo.SalaryDetail");
            DropTable("dbo.Employee");
            DropTable("dbo.Attendance");
        }
    }
}
