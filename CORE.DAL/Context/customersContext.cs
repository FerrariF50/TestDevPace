using CORE.DAL.Models;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CORE.DAL.Context
{
    public partial class customerContext : DbContext
    {
        public customerContext()
        {
        }

        public customerContext(DbContextOptions<customerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;port=5432;database=customer;Username=postgres;Password=Vania1988");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => new { e.Name, e.Phone, e.Email, e.Companyname }, "customer_index");

                entity.HasIndex(e => e.Name, "customers_name_key")
                    .IsUnique();

                entity.Property(e => e.Customerid).HasColumnName("customerid");

                entity.Property(e => e.Companyname).HasColumnName("companyname");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(30000)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
