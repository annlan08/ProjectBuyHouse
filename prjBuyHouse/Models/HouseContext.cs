using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjBuyHouse.Models;

public partial class HouseContext : DbContext
{
    //public HouseContext()
    //{
    //}

    public HouseContext(DbContextOptions<HouseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HouseObject> HouseObjects { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-DPAPVD0;Initial Catalog=House;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HouseObject>(entity =>
        {
            entity.HasKey(e => e.FId);

            entity.ToTable("HouseObject");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FDescription)
                .HasMaxLength(100)
                .HasColumnName("fDescription");
            entity.Property(e => e.FGuid).HasColumnName("fGuid");
            entity.Property(e => e.FName)
                .HasMaxLength(50)
                .HasColumnName("fName");
            entity.Property(e => e.FPrice)
                .HasColumnType("money")
                .HasColumnName("fPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
