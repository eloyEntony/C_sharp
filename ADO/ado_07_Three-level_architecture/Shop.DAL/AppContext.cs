namespace University.DAL
{
    
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("name=AppContext")
        {
        }

        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<TeachersGroups> TeachersGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Groups)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.Id_Department);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Subject)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.Id_Department);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Teacher)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.Id_Department);

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Student)
                .WithOptional(e => e.Groups)
                .HasForeignKey(e => e.IdGroup)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Groups>()
                .HasMany(e => e.TeachersGroups)
                .WithOptional(e => e.Groups)
                .HasForeignKey(e => e.IdGroup);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Achievement)
                .WithOptional(e => e.Student)
                .HasForeignKey(e => e.IdStudent);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Achievement)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.IdSubject);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.TeachersGroups)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.IdSubject);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.TeachersGroups)
                .WithOptional(e => e.Teacher)
                .HasForeignKey(e => e.IdTeacher)
                .WillCascadeOnDelete();
        }
    }
}
