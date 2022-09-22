using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Models
{
    public partial class IVRestaurantsContext : DbContext
    {
        public IVRestaurantsContext()
        {
        }

        public IVRestaurantsContext(DbContextOptions<IVRestaurantsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MenuItem> MenuItems { get; set; } = null!;
        public virtual DbSet<MenuPromo> MenuPromos { get; set; } = null!;
        public virtual DbSet<MenuPromoItem> MenuPromoItems { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderMenuItem> OrderMenuItems { get; set; } = null!;
        public virtual DbSet<OrderMenuPromo> OrderMenuPromos { get; set; } = null!;
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSqlLocalDb;Database=IVRestaurants;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("MenuItem");

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.MenuItemName).HasMaxLength(64);

                entity.Property(e => e.MenuItemPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItem_Restaurant");
            });

            modelBuilder.Entity<MenuPromo>(entity =>
            {
                entity.ToTable("MenuPromo");

                entity.Property(e => e.MenuPromoId).HasColumnName("MenuPromoID");

                entity.Property(e => e.MenuPromoDiscount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MenuPromoName).HasMaxLength(128);

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.MenuPromos)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuPromo_Restaurant");
            });

            modelBuilder.Entity<MenuPromoItem>(entity =>
            {
                entity.ToTable("MenuPromoItem");

                entity.Property(e => e.MenuPromoItemId).HasColumnName("MenuPromoItemID");

                entity.Property(e => e.MenuItemId).HasColumnName("MenuItemID");

                entity.Property(e => e.MenuPromoId).HasColumnName("MenuPromoID");

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.MenuPromoItems)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuPromoItem_MenuItem");

                entity.HasOne(d => d.MenuPromo)
                    .WithMany(p => p.MenuPromoItems)
                    .HasForeignKey(d => d.MenuPromoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuPromoItem_MenuPromo");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderMenuItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId);

                entity.ToTable("OrderMenuItem");

                entity.Property(e => e.MenuItemPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.MenuItem)
                    .WithMany(p => p.OrderMenuItems)
                    .HasForeignKey(d => d.MenuItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderMenuItem_MenuItem");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderMenuItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderMenuItem_Order");
            });

            modelBuilder.Entity<OrderMenuPromo>(entity =>
            {
                entity.HasKey(e => e.OrderPromoId);

                entity.ToTable("OrderMenuPromo");

                entity.Property(e => e.MenuPromoPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.MenuPromo)
                    .WithMany(p => p.OrderMenuPromos)
                    .HasForeignKey(d => d.MenuPromoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderMenuPromo_MenuPromo");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderMenuPromos)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderMenuPromo_Order");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.Property(e => e.RestaurantName).HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
