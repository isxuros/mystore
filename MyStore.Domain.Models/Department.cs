using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Models
{
    [Table("Department")]
    public class Department
        : EntityBase
    {
        [Key]
        public override int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string DepartmentName { get; set; }

        [JsonIgnore] 
        public List<Employee> Employees { get; set; }
    }
}
