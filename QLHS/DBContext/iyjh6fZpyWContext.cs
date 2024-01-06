using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QLHS.DBContext
{
    public partial class iyjh6fZpyWContext : DbContext
    {
        public iyjh6fZpyWContext()
        {
        }

        public iyjh6fZpyWContext(DbContextOptions<iyjh6fZpyWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClass> TbClasses { get; set; }
        public virtual DbSet<TbGroup> TbGroups { get; set; }
        public virtual DbSet<TbMenu> TbMenus { get; set; }
        public virtual DbSet<TbRegulation> TbRegulations { get; set; }
        public virtual DbSet<TbRole> TbRoles { get; set; }
        public virtual DbSet<TbSemester> TbSemesters { get; set; }
        public virtual DbSet<TbStudent> TbStudents { get; set; }
        public virtual DbSet<TbSubject> TbSubjects { get; set; }
        public virtual DbSet<TbTranScript> TbTranScripts { get; set; }
        public virtual DbSet<TbUser> TbUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySQL("server=localhost;user=root;password=;database=qlhs;Port=3306");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbClass>(entity =>
            {
                entity.ToTable("tb_Class");

                entity.HasIndex(e => e.GroupId, "FK_tb_Class_tb_Groups");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("GroupID");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Name).HasColumnType("longtext");

                entity.Property(e => e.Quantity).HasColumnType("int(11)");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TbClasses)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_tb_Class_tb_Groups");
            });

            modelBuilder.Entity<TbGroup>(entity =>
            {
                entity.ToTable("tb_Groups");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Name).HasColumnType("longtext");
            });

            modelBuilder.Entity<TbMenu>(entity =>
            {
                entity.ToTable("tb_Menu");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Name).HasColumnType("longtext");

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("RoleID");
            });

            modelBuilder.Entity<TbRegulation>(entity =>
            {
                entity.ToTable("tb_Regulations");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.ClassQuantity).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.MaxAge).HasColumnType("int(11)");

                entity.Property(e => e.MaxQuantity).HasColumnType("int(11)");

                entity.Property(e => e.MinAge).HasColumnType("int(11)");

                entity.Property(e => e.SubjectQuantity).HasColumnType("int(11)");
            });

            modelBuilder.Entity<TbRole>(entity =>
            {
                entity.ToTable("tb_Roles");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Name).HasColumnType("longtext");
            });

            modelBuilder.Entity<TbSemester>(entity =>
            {
                entity.ToTable("tb_Semesters");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Name).HasColumnType("longtext");
            });

            modelBuilder.Entity<TbStudent>(entity =>
            {
                entity.ToTable("tb_Students");

                entity.HasIndex(e => e.ClassId, "FK_tb_Students_tb_Class");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Address).HasColumnType("longtext");

                entity.Property(e => e.ClassId)
                    .HasColumnType("int(11)")
                    .HasColumnName("ClassID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Gender).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Name).HasColumnType("longtext");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.TbStudents)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_tb_Students_tb_Class");
            });

            modelBuilder.Entity<TbSubject>(entity =>
            {
                entity.ToTable("tb_Subjects");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Name).HasColumnType("longtext");
            });

            modelBuilder.Entity<TbTranScript>(entity =>
            {
                entity.ToTable("tb_TranScripts");

                entity.HasIndex(e => e.SemesterId, "FK_tb_TranScripts_tb_Semesters");

                entity.HasIndex(e => e.StudentId, "FK_tb_TranScripts_tb_Students");

                entity.HasIndex(e => e.SubjectId, "FK_tb_TranScripts_tb_Subjects");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.SemesterId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SemesterID");

                entity.Property(e => e.StudentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("StudentID");

                entity.Property(e => e.SubjectId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SubjectID");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.TbTranScripts)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK_tb_TranScripts_tb_Semesters");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.TbTranScripts)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_tb_TranScripts_tb_Students");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TbTranScripts)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_tb_TranScripts_tb_Subjects");
            });

            modelBuilder.Entity<TbUser>(entity =>
            {
                entity.ToTable("tb_Users");

                entity.HasIndex(e => e.RoleId, "FK_tb_Users_tb_Roles");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.IsDeleted).HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime(3)");

                entity.Property(e => e.Name).HasColumnType("longtext");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RoleId)
                    .HasColumnType("int(11)")
                    .HasColumnName("RoleID");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TbUsers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tb_Users_tb_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
