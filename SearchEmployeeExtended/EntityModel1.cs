namespace SearchEmployeeExtended
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel1 : DbContext
    {
        public EntityModel1()
            : base("name=EntityModel1")
        {
        }

        public virtual DbSet<EmployeesListDB> EmployeesListDB { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeesListDB>()
                .Property(e => e.EmployeeName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeesListDB>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeesListDB>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeesListDB>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeesListDB>()
                .Property(e => e.DateOfBirth)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeesListDB>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
