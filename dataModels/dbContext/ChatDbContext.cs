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
            entity.HasKey(e => e.InductionuserGuid).HasName("PRIMARY");

            entity.ToTable("inductionusers");

            entity.Property(e => e.InductionuserGuid)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("inductionuserGUID");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Inductionuserid).HasColumnName("inductionuserid");
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
            entity.HasKey(e => e.InductionUserMsgGuid).HasName("PRIMARY");

            entity.ToTable("smsmsgtoinductionuser");

            entity.HasIndex(e => e.CreatorId, "FK1_CREATOR_INDUCTION");

            entity.HasIndex(e => e.ModificationId, "FK2_MODIFICATION_INDUCTION");

            entity.HasIndex(e => e.DeletorId, "FK3_DELETION_INDUCTION");

            entity.HasIndex(e => e.InductionUserId, "FK4_INDUCTION_USER");

            entity.Property(e => e.InductionUserMsgGuid)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("inductionUserMsgGUID");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.CreatorId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.DeletorId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.InductionUserId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.ModificationId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.ModificationTime).HasColumnType("timestamp");
            entity.Property(e => e.Sms).HasColumnType("text");

            entity.HasOne(d => d.Creator).WithMany(p => p.SmsmsgtoinductionuserCreators)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_CREATOR_INDUCTION");

            entity.HasOne(d => d.Deletor).WithMany(p => p.SmsmsgtoinductionuserDeletors)
                .HasForeignKey(d => d.DeletorId)
                .HasConstraintName("FK3_DELETION_INDUCTION");

            entity.HasOne(d => d.InductionUser).WithMany(p => p.Smsmsgtoinductionusers)
                .HasForeignKey(d => d.InductionUserId)
                .HasConstraintName("FK4_INDUCTION_USER");

            entity.HasOne(d => d.Modification).WithMany(p => p.SmsmsgtoinductionuserModifications)
                .HasForeignKey(d => d.ModificationId)
                .HasConstraintName("FK2_MODIFICATION_INDUCTION");
        });

        modelBuilder.Entity<Smsmsgtouser>(entity =>
        {
            entity.HasKey(e => e.UsermsgGuid).HasName("PRIMARY");

            entity.ToTable("smsmsgtousers");

            entity.HasIndex(e => e.CreatorId, "FK1_CREATOR");

            entity.HasIndex(e => e.ModificationId, "FK2_Modifier");

            entity.HasIndex(e => e.DeletorId, "FK3_DELETOR");

            entity.HasIndex(e => e.UserId, "FK4_USER_REF");

            entity.Property(e => e.UsermsgGuid)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("usermsgGUID");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.CreatorId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.DeletorId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.ModificationId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.ModificationTime).HasColumnType("timestamp");
            entity.Property(e => e.Sms).HasColumnType("text");
            entity.Property(e => e.UserId)
                .HasMaxLength(16)
                .IsFixedLength();

            entity.HasOne(d => d.Creator).WithMany(p => p.SmsmsgtouserCreators)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK1_CREATOR");

            entity.HasOne(d => d.Deletor).WithMany(p => p.SmsmsgtouserDeletors)
                .HasForeignKey(d => d.DeletorId)
                .HasConstraintName("FK3_DELETOR");

            entity.HasOne(d => d.Modification).WithMany(p => p.SmsmsgtouserModifications)
                .HasForeignKey(d => d.ModificationId)
                .HasConstraintName("FK2_Modifier");

            entity.HasOne(d => d.User).WithMany(p => p.SmsmsgtouserUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK4_USER_REF");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserGuid).HasName("PRIMARY");

            entity.ToTable("users");

            entity.Property(e => e.UserGuid)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("userGUID");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.CreatorId)
                .HasMaxLength(16)
                .IsFixedLength();
            entity.Property(e => e.DeletionTime).HasColumnType("timestamp");
            entity.Property(e => e.DeletorId)
                .HasMaxLength(16)
                .IsFixedLength();
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
            entity.Property(e => e.ModificationId)
                .HasMaxLength(16)
                .IsFixedLength();
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
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
