namespace SearchEmployeeExtended
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EmployeesListDB")]
    public partial class EmployeesListDB
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Adress { get; set; }

        [Required]
        [StringLength(255)]
        public string DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        public string Phone { get; set; }
    }
}
