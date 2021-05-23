using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Permit
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string EmployeeName { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string LastNameEmployee { get; set; }
        [Required]
        [ForeignKey("PermitType")]
        public int IdPermitType { get; set; }
        [Required]
        public DateTime PermitDate { get; set; }
        [NotMapped]
        public string PermitDateFormat { get; set; }
        public PermitType PermitType { get; set; }

    }
}
