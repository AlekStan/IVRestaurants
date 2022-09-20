using Microsoft.EntityFrameworkCore;

namespace Domain.Models
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
        public virtual DbSet<Restaurant> Restaurants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=(localdb)\\MSSqlLocalDb;Database=IVRestaurants;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.ToTable("MenuItem");

                entity.Property(e => e.MenuItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuItemID");

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

                entity.Property(e => e.MenuPromoId)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuPromoID");

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

                entity.Property(e => e.MenuPromoItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("MenuPromoItemID");

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

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.RestaurantId)
                    .ValueGeneratedNever()
                    .HasColumnName("RestaurantID");

                entity.Property(e => e.RestaurantName).HasMaxLength(64);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
