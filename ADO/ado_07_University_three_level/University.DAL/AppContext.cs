namespace University.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using University.DAL.Entityes;

    public partial class AppContext : DbContext
    {
        public AppContext()
            : base("name=AplicationContext")
        {
        }

        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Groups>()
                .HasMany(e => e.Student)
                .WithOptional(e => e.Groups)
                .HasForeignKey(e => e.IdGroup)
                .WillCascadeOnDelete(); 
        }
    }
}
