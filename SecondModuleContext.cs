using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using sweet_shop.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace sweet_shop
{
    public partial class SecondModuleContext : DbContext
    {
        public SecondModuleContext()
        {
        }

        public SecondModuleContext(DbContextOptions<SecondModuleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Budget> Budget { get; set; }
        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Measurement> Measurement { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductionOfProduct> ProductionOfProduct { get; set; }
        public virtual DbSet<PurchaseOfSupply> PurchaseOfSupply { get; set; }
        public virtual DbSet<SaleOfProduct> SaleOfProduct { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<Category> Сategory { get; set; }
        public virtual DbSet<Expence> Expence { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AJ76KB7\\SQLEXPRESS;Initial Catalog=DMS4;Persist Security Info=True;User Id = nurai;Password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Budget>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SumOfBudget)
                    .HasColumnName("sum_of_budget")
                    .HasColumnType("money");
               
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                       .HasColumnName("name")
                       .HasMaxLength(50)
                       .IsUnicode(false);

                entity.Property(e => e.Pass)
                   .HasColumnName("password")
                   .HasMaxLength(50)
                   .IsUnicode(false);
                entity.Property(e => e.Role)
              .HasColumnName("role")
              .HasMaxLength(50)
              .IsUnicode(false);
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Ingredient_Product");

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK_Ingredient_Supply");
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.MeasurementId).HasColumnName("measurement_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("money");

              

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.MeasurementId)
                    .HasConstraintName("FK_Product_Measurement");

            });

            modelBuilder.Entity<ProductionOfProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Prize)
                  .HasColumnName("prize")
                  .HasColumnType("money");

                entity.Property(e => e.ProductId).HasColumnName("product_id");


                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductionOfProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductionOfProduct_Product");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.ProductionOfProduct)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_ProductionOfProduct_Staff");
            });

            modelBuilder.Entity<PurchaseOfSupply>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("money");

                entity.Property(e => e.SupplyId).HasColumnName("supply_id");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.PurchaseOfSupply)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_PurchaseOfSupply_Staff");

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.PurchaseOfSupply)
                    .HasForeignKey(d => d.SupplyId)
                    .HasConstraintName("FK_PurchaseOfSupply_Supply");
            });
            modelBuilder.Entity<Expence>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("category");

                entity.Property(e => e.Summ)
                    .HasColumnName("sum")
                    .HasColumnType("money");

                entity.Property(e => e.Comment)
                   .HasColumnName("comment")
                   .IsUnicode(false);

                entity.Property(e => e.Date)
                 .HasColumnName("date")
                 .HasColumnType("datetime");


                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Expence)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Expence_Category");
            });
            modelBuilder.Entity<SaleOfProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.Sum)
                    .HasColumnName("sum")
                    .HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleOfProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_SaleOfProduct_Product");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.SaleOfProduct)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_SaleOfProduct_Staff");
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .IsUnicode(false);

                entity.Property(e => e.Fio)
                    .HasColumnName("fio")
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("money");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Staff)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Staff_Position");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.Amount_Supp)
                    .HasColumnName("amount_supp")
                    .HasColumnType("money");
                entity.Property(e => e.Diff)
                   .HasColumnName("diff")
                   .HasColumnType("money");
                entity.Property(e => e.Date)
                  .HasColumnName("date")
                  .HasColumnType("datetime");
                entity.Property(e => e.Measurement_id).HasColumnName("measurement_id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Staff_id).HasColumnName("staff_id");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Measurement_id)
                    .HasConstraintName("FK_Inventory_Measurement");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Staff_id)
                    .HasConstraintName("FK_Inventory_Staff");

                entity.HasOne(d => d.Supply)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.Name)
                    .HasConstraintName("FK_Inventory_Supply");
            });

            modelBuilder.Entity<Supply>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("money");

                entity.Property(e => e.MeasurementId).HasColumnName("measurement_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);



                entity.Property(e => e.SupplierID).HasColumnName("SupplierId");

                entity.HasOne(d => d.Measurement)
                    .WithMany(p => p.Supply)
                    .HasForeignKey(d => d.MeasurementId)
                    .HasConstraintName("FK_Supply_Measurement");
                entity.HasOne(e => e.Supplier)
                     .WithMany(s => s.Supplies)
                     .HasForeignKey(e => e.SupplierID)
                     .HasConstraintName("FK_Supply_Supplier");

            });
            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.organization)
                    .HasColumnName("organization")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.number)
                   .HasColumnName("number")
                   .HasMaxLength(50)
                   .IsUnicode(false);

            });

            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
