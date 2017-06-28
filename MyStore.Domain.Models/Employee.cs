using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Models
{
    [Table("Employee")]
    public class Employee : EntityBase
    {
        [Key()]
        public override int ID { get; set; }

        [Required()]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required()]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required()]
        [MaxLength(100)]
        public string MiddleName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}
