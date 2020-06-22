using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using spoons.Data.Entities;

namespace spoons.Data
{
    public partial class CoreContext : DbContext
    {
        public CoreContext () { }

        public CoreContext (DbContextOptions<CoreContext> options) : base (options) { }

        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Measurement> Measurement { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql ("Host=ec2-50-17-90-177.compute-1.amazonaws.com;Port=5432;Username=pptbbdmoftfveb;Password=098edfb330b93bdf2081ccc9fc87e015682877d607a595f55de674c7997501eb;Database=dcn0vi1lliqkkb; Pooling=true; SSL Mode=Require;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient> (entity =>
            {
                entity.ToTable ("ingredient");

                entity.Property (e => e.Id).HasColumnName ("id");

                entity.Property (e => e.Ingredient1)
                    .HasColumnName ("ingredient")
                    .HasColumnType ("character varying");

                entity.Property (e => e.MeasurementId).HasColumnName ("measurementId");

                entity.Property (e => e.Quantity)
                    .HasColumnName ("quantity")
                    .HasColumnType ("character varying");

                entity.Property (e => e.RecipeId).HasColumnName ("recipeId");

                entity.Property (e => e.UserId).HasColumnName ("userId");

                entity.HasOne (d => d.Measurement)
                    .WithMany (p => p.Ingredient)
                    .HasForeignKey (d => d.MeasurementId)
                    .HasConstraintName ("measurementId");

                entity.HasOne (d => d.Recipe)
                    .WithMany (p => p.Ingredient)
                    .HasForeignKey (d => d.RecipeId)
                    .HasConstraintName ("recipeId");

                entity.HasOne (d => d.User)
                    .WithMany (p => p.Ingredient)
                    .HasForeignKey (d => d.UserId)
                    .HasConstraintName ("userId");
            });

            modelBuilder.Entity<Measurement> (entity =>
            {
                entity.ToTable ("measurement");

                entity.Property (e => e.Id)
                    .HasColumnName ("id")
                    .HasDefaultValueSql ("nextval('measurements_id_seq'::regclass)");

                entity.Property (e => e.Measurments)
                    .HasColumnName ("measurments")
                    .HasColumnType ("character varying");
            });

            modelBuilder.Entity<Recipe> (entity =>
            {
                entity.ToTable ("recipe");

                entity.Property (e => e.Id).HasColumnName ("id");

                entity.Property (e => e.Instruction)
                    .HasColumnName ("instruction")
                    .HasColumnType ("character varying");

                entity.Property (e => e.Servings)
                    .HasColumnName ("servings")
                    .HasColumnType ("character varying");

                entity.Property (e => e.Title)
                    .HasColumnName ("title")
                    .HasColumnType ("character varying");

                entity.Property (e => e.UserId).HasColumnName ("userId");

                entity.HasOne (d => d.User)
                    .WithMany (p => p.Recipe)
                    .HasForeignKey (d => d.UserId)
                    .HasConstraintName ("userId");
            });

            modelBuilder.Entity<User> (entity =>
            {
                entity.ToTable ("user");

                entity.Property (e => e.Id).HasColumnName ("id");

                entity.Property (e => e.Email)
                    .HasColumnName ("email")
                    .HasColumnType ("character varying");

                entity.Property (e => e.Password)
                    .HasColumnName ("password")
                    .HasColumnType ("character varying");

                entity.Property (e => e.Username)
                    .HasColumnName ("username")
                    .HasColumnType ("character varying");
            });

            OnModelCreatingPartial (modelBuilder);
        }

        partial void OnModelCreatingPartial (ModelBuilder modelBuilder);
    }
}