using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CricBook.Models;

public partial class CricbookContext : DbContext
{
    public CricbookContext()
    {
    }

    public CricbookContext(DbContextOptions<CricbookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<Table> Tables { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cricbook;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC078483376C");

            entity.ToTable("Field");

            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.ClosingTime).HasColumnName("closing_time");
            entity.Property(e => e.HostId).HasColumnName("host_id");
            entity.Property(e => e.OpeningTime).HasColumnName("opening_time");
            entity.Property(e => e.OptionalImage1)
                .HasColumnType("image")
                .HasColumnName("optional_image_1");
            entity.Property(e => e.OptionalImage2)
                .HasColumnType("image")
                .HasColumnName("optional_image_2");
            entity.Property(e => e.PrimaryImage)
                .HasColumnType("image")
                .HasColumnName("primary_image");
        });

        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC07EFF3E8D0");

            entity.ToTable("Table");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.FieldId).HasColumnName("field_id");
            entity.Property(e => e.PlayerId).HasColumnName("player_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07E08613B0");

            entity.ToTable("User");

            entity.HasIndex(e => e.Password, "UQ__tmp_ms_x__6E2DBEDEF93BD9C5").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "UQ__tmp_ms_x__A1936A6B837F2226").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__tmp_ms_x__AB6E616489E42C6E").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__tmp_ms_x__F3DBC572676482EF").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
