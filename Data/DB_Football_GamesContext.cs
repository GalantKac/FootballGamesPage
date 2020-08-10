using System;
using Football.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Football.Data
{
    public partial class DB_Football_GamesContext : DbContext
    {
        public DB_Football_GamesContext()
        {
        }

        public DB_Football_GamesContext(DbContextOptions<DB_Football_GamesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Player> Player { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DB_Football_Games;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.AwayPlayer)
                    .WithMany(p => p.GameAwayPlayer)
                    .HasForeignKey(d => d.AwayPlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Game__AwayPlayer__2C3393D0");

                entity.HasOne(d => d.HomePlayer)
                    .WithMany(p => p.GameHomePlayer)
                    .HasForeignKey(d => d.HomePlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Game__HomePlayer__2B3F6F97");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
