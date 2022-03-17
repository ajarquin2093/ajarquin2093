using System;
using System.Collections.Generic;
using System.Text;
using Ex.DAL.DO.Objetos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace Ex.DAL.EF
{
    public partial class NDbContext : DbContext
    {
        public NDbContext()
        {

        }

        public NDbContext(DbContextOptions<NDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libros>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.Property(e => e.id).HasColumnName("AutorId");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.AutorId).HasColumnType("ntext");

                entity.Property(e => e.Creacion).HasColumnType("Creacion");

                entity.Property(e => e.Activo).HasColumnType("Activo");

                entity.Property(e => e.Desactivacion).HasColumnType("Desactivacion");

                entity.Property(e => e.DesactivadoPor).HasColumnType("DesactivadoPor");

                entity.Property(e => e.CreadoPor).HasColumnType("CreadoPor");
            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
