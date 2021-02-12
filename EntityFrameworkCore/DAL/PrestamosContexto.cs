using EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.DAL
{
    public class PrestamosContexto : DbContext
    {
        public PrestamosContexto()
        {
        }

        public PrestamosContexto(DbContextOptions<PrestamosContexto> options) : base(options)
        {
        }

        public virtual DbSet<Prestamos> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlite("@” Data Source = Prestamos.db”;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Prestamos>(entity =>
            {
                entity.Property(p => p.Nombres)
                   .IsRequired()
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.ToTable("Prestamos");

                 entity.Property(p => p.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(p => p.Cedula)
                    .HasMaxLength(15)
                    .IsUnicode(false);


                entity.Property(p => p.FechaNacimiento).HasColumnType("date");             
            });

                     
        }
        
    }
}
