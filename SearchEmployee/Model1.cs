namespace SearchEmployee
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
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
        }
    }
}
