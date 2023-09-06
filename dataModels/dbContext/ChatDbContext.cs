using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using dataModels.Entities;

namespace dataModels.dbContext;

public partial class ChatDbContext : DbContext
{
    public ChatDbContext()
    {
    }

    public ChatDbContext(DbContextOptions<ChatDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inductionuser> Inductionusers { get; set; }

    public virtual DbSet<Smsmsgtoinductionuser> Smsmsgtoinductionusers { get; set; }

    public virtual DbSet<Smsmsgtouser> Smsmsgtousers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=chatbot;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Inductionuser>(entity =>
        {
            entity.HasKey(e => e.Inductionuserid).HasName("PRIMARY");

            entity.ToTable("inductionusers");

            entity.Property(e => e.Inductionuserid).HasColumnName("inductionuserid");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("'0'");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.ModificationTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
        });

        modelBuilder.Entity<Smsmsgtoinductionuser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("smsmsgtoinductionuser");

            entity.HasIndex(e => e.CreatorId, "CreatorId");

            entity.HasIndex(e => e.DeletorId, "DeletorId");

            entity.HasIndex(e => e.InductionUserId, "FK_smsmsgtoinductionuser_inductionusers");

            entity.HasIndex(e => e.ModificationId, "ModificationId");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.ModificationTime).HasColumnType("timestamp");
            entity.Property(e => e.Sms).HasColumnType("text");

            entity.HasOne(d => d.Creator).WithMany(p => p.SmsmsgtoinductionuserCreators)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("smsmsgtoinductionuser_ibfk_2");

            entity.HasOne(d => d.Deletor).WithMany(p => p.SmsmsgtoinductionuserDeletors)
                .HasForeignKey(d => d.DeletorId)
                .HasConstraintName("smsmsgtoinductionuser_ibfk_4");

            entity.HasOne(d => d.InductionUser).WithMany(p => p.Smsmsgtoinductionusers)
                .HasForeignKey(d => d.InductionUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_smsmsgtoinductionuser_inductionusers");

            entity.HasOne(d => d.Modification).WithMany(p => p.SmsmsgtoinductionuserModifications)
                .HasForeignKey(d => d.ModificationId)
                .HasConstraintName("smsmsgtoinductionuser_ibfk_3");
        });

        modelBuilder.Entity<Smsmsgtouser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("smsmsgtousers");

            entity.HasIndex(e => e.CreatorId, "CreatorId");

            entity.HasIndex(e => e.DeletorId, "DeletorId");

            entity.HasIndex(e => e.ModificationId, "ModificationId");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.ModificationTime).HasColumnType("timestamp");
            entity.Property(e => e.Sms).HasColumnType("text");

            entity.HasOne(d => d.Creator).WithMany(p => p.SmsmsgtouserCreators)
                .HasForeignKey(d => d.CreatorId)
                .HasConstraintName("smsmsgtousers_ibfk_2");

            entity.HasOne(d => d.Deletor).WithMany(p => p.SmsmsgtouserDeletors)
                .HasForeignKey(d => d.DeletorId)
                .HasConstraintName("smsmsgtousers_ibfk_4");

            entity.HasOne(d => d.Modification).WithMany(p => p.SmsmsgtouserModifications)
                .HasForeignKey(d => d.ModificationId)
                .HasConstraintName("smsmsgtousers_ibfk_3");

            entity.HasOne(d => d.User).WithMany(p => p.SmsmsgtouserUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("smsmsgtousers_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.DeletionTime).HasColumnType("timestamp");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.IsActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("'0'");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.ModificationTime)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
