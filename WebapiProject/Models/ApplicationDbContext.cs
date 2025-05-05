using Microsoft.EntityFrameworkCore;

namespace WebapiProject.Models
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<StockDto> ProductDtos { get; set; }

        public DbSet<StockLevelReport> StockLevelReport { get; set; }

        public DbSet<LowStockReport> LowStockReport { get; set; }

        public DbSet<SalesReport> SalesReport { get; set; }

        public DbSet<UserOrderReport> UserOrderReport { get; set; }

        public DbSet<UserOrderDetails> UserOrderDetails { get; set; }

        public DbSet<SupplierPerformanceReport> SupplierPerformanceReport { get; set; }

        public DbSet<OrderHistoryReport> OrderHistoryReport { get; set; }

        public DbSet<ProductDemandReport> ProductDemandReport { get; set; }

       

        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Report> Reports { get; set; }

        public DbSet<GetOrderedProductDetails> GetOrderedProductDetails { get; set; }


        public DbSet<UpdateUserDetail> UpdateUserDetail { get; set; }

        public DbSet<PasswordReset> PasswordReset { get; set; }


        
        public DbSet<SalesReport> SalesReports { get; set; }
        public DbSet<ProductDemandReport> ProductDemandReports { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StockDto>().HasNoKey();
            modelBuilder.Entity<StockLevelReport>().HasNoKey();
            modelBuilder.Entity<SalesReport>().HasNoKey();
            modelBuilder.Entity<LowStockReport>().HasNoKey();
            modelBuilder.Entity<UserOrderReport>().HasNoKey();
            modelBuilder.Entity<UserOrderDetails>().HasNoKey();
            modelBuilder.Entity<SupplierPerformanceReport>().HasNoKey();
            modelBuilder.Entity<ProductDemandReport>().HasNoKey();
            modelBuilder.Entity<OrderHistoryReport>().HasNoKey();
            
            modelBuilder.Entity<GetOrderedProductDetails>().HasNoKey();
            modelBuilder.Entity<UpdateUserDetail>().HasNoKey();
            modelBuilder.Entity<PasswordReset>().HasNoKey();
        }

    }
}
