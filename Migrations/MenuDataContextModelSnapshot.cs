// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantMenu_v3_CodeFirst;

namespace RestaurantMenu_v3_CodeFirst.Migrations
{
    [DbContext(typeof(MenuDataContext))]
    partial class MenuDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderItemProduct", b =>
                {
                    b.Property<int>("OrderItemsOrderItemId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.HasKey("OrderItemsOrderItemId", "ProductsProductId");

                    b.HasIndex("ProductsProductId");

                    b.ToTable("OrderItemProduct");
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories", "dbo");
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.Guest", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GuestEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.HasKey("GuestId");

                    b.ToTable("Guests", "dbo");
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("GuestId")
                        .HasColumnType("int");

                    b.Property<int>("OrderItemId")
                        .HasColumnType("int");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("GuestId")
                        .IsUnique();

                    b.HasIndex("OrderItemId")
                        .IsUnique();

                    b.ToTable("Orders", "dbo");
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("OrderItemId");

                    b.ToTable("OrderItems", "dbo");
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AllergenId")
                        .HasColumnType("int");

                    b.Property<int>("Calories")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAlcohol")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSeason")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", "dbo");
                });

            modelBuilder.Entity("OrderItemProduct", b =>
                {
                    b.HasOne("RestaurantMenu_v3_CodeFirst.Entities.OrderItem", null)
                        .WithMany()
                        .HasForeignKey("OrderItemsOrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantMenu_v3_CodeFirst.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.Order", b =>
                {
                    b.HasOne("RestaurantMenu_v3_CodeFirst.Entities.Guest", "Guest")
                        .WithOne("Order")
                        .HasForeignKey("RestaurantMenu_v3_CodeFirst.Entities.Order", "GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantMenu_v3_CodeFirst.Entities.OrderItem", "OrderItem")
                        .WithOne("Order")
                        .HasForeignKey("RestaurantMenu_v3_CodeFirst.Entities.Order", "OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.Product", b =>
                {
                    b.HasOne("RestaurantMenu_v3_CodeFirst.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.Guest", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantMenu_v3_CodeFirst.Entities.OrderItem", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
