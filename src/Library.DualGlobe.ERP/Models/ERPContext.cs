namespace Library.DualGlobe.ERP.Models
{
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class ERPContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Library.DualGlobe.ERP.Models.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        //public ERPContext()
        //    : base("name=ERPConnection")
        //{
        //}

        protected static string _connectionstring { get { return ConfigurationManager.ConnectionStrings["ERPConnection"].ConnectionString; } }

        public ERPContext()
            : base(_connectionstring)
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Employee> Employees { get; set; }       
        public virtual DbSet<Timesheet> Timesheets { get; set; }
        public virtual DbSet<SalaryDetail> SalaryDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleMenu> RoleMenus { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<Allowance> Allowances { get; set; }
        public virtual DbSet<LoanAndAdvance> LoanAndAdvances { get; set; }
        public virtual DbSet<LoanAndAdvanceDetails> LoanAndAdvanceDetails { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<QuotationItems> QuotationItems { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<PublicHoliday> PublicHolidays { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoicePhase> InvoicePhases { get; set; }       
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<OtherIncome> OtherIncomes { get; set; }
        public virtual DbSet<OperationExpense> OperationExpenses { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }

        public virtual DbSet<CPF> CPFs { get; set; }
        //mks
        public virtual DbSet<CPFLookup> CPFLookups { get; set; }
        public virtual DbSet<Overtime> Overtimes { get; set; }
        public virtual DbSet<RestDay> RestDays { get; set; }
        public virtual DbSet<RestDate> RestDates { get; set; }
        public virtual DbSet<RestDayPay> RestDayPays { get; set; }
        public virtual DbSet<PublicHolidayPay> PublicHolidayPays { get; set; }
        public virtual DbSet<WorkingHour> WorkingHours { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<WorkPermitAddress> WorkPermitAddresses { get; set; }
        public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<LevyLookup> LevyLookups { get; set; }
        
        //mks
        public virtual DbSet<ExpenseCategory> ExpenseCategorys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Quotation>().Property(x => x.QuotationValue).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<Quotation>().Property(x => x.GST).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<Quotation>().Property(x => x.DiscountValue).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<QuotationItems>().Property(x => x.UnitPrice).HasColumnType("Decimal").HasPrecision(16, 4);
           // modelBuilder.Entity<QuotationItems>().Property(x => x.GST).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<QuotationItems>().Property(x => x.Amount).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<Invoice>().Property(x => x.TotalAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<Invoice>().Property(x => x.InvoiceAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<Invoice>().Property(x => x.TotalGSTAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            //modelBuilder.Entity<Invoice>().Property(x => x.TotalDiscountedGST).HasColumnType("Decimal").HasPrecision(16, 4);
            //modelBuilder.Entity<Invoice>().Property(x => x.TotalDiscountedPhaseInvoice).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<Invoice>().Property(x => x.DiscountValue).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<Invoice>().Property(x => x.TotalPhaseAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<InvoicePhase>().Property(x => x.UnitPrice).HasColumnType("Decimal").HasPrecision(16, 4);
            //modelBuilder.Entity<InvoicePhase>().Property(x => x.GST).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<InvoicePhase>().Property(x => x.QuotationAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<InvoicePhase>().Property(x => x.PhaseAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            //modelBuilder.Entity<InvoicePhase>().Property(x => x.GSTAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            modelBuilder.Entity<InvoicePhase>().Property(x => x.PhaseInvoiceAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            //modelBuilder.Entity<InvoicePhase>().Property(x => x.DiscountedGSTAmount).HasColumnType("Decimal").HasPrecision(16, 4);
            //modelBuilder.Entity<InvoicePhase>().Property(x => x.DiscountedPhaseInvoiceAmount).HasColumnType("Decimal").HasPrecision(16, 4);

        }
    }

    
}
