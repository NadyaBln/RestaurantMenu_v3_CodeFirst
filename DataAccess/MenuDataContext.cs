using Microsoft.EntityFrameworkCore;
using RestaurantMenu_v3_CodeFirst.Entities;

namespace RestaurantMenu_v3_CodeFirst
{
    //context = DataBase
    public class MenuDataContext : DbContext
    {
        //db set = table
        //specify data type we use in each table 
        //in table Category we use object Category
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Category> Categories { get; set; }

        //mapping is discribing connection btw category and product
        //set mapping for product and category
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping settings for category and product
            modelBuilder.Entity<Order>()
                .ToTable("Orders", "dbo");

            modelBuilder.Entity<Order>()
                .HasOne(i => i.OrderItem)
                .WithOne(i => i.Order)
                .HasForeignKey<Order>(b => b.OrderItemId);

            modelBuilder.Entity<Order>()
                    .HasOne(i => i.Guest)
                    .WithOne(i => i.Order)
                    .HasForeignKey<Order>(i => i.GuestId);


            modelBuilder.Entity<Product>()
                .ToTable("Products", "dbo");

            modelBuilder.Entity<Product>()
               .HasMany(i => i.OrderItems)
               .WithMany(i => i.Products);


            modelBuilder.Entity<OrderItem>()
               .ToTable("OrderItems", "dbo");

            //coplete many to many
            modelBuilder.Entity<OrderItem>()
                .HasMany(i => i.Products)
                .WithMany(i => i.OrderItems);


            modelBuilder.Entity<Guest>()
               .ToTable("Guests", "dbo");

            modelBuilder.Entity<Category>()
                .ToTable("Categories", "dbo");

            base.OnModelCreating(modelBuilder);
        }

        //use Sql server with this connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string to DB
            optionsBuilder.UseSqlServer(@"Server=.;Database=RestaurantMenu_DB_CodeFirst;Trusted_Connection=True;");
        }
    }
}
