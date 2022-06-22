using Demo63Assignment.Models.DataModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo63Assignment.Models
{
    [Table("Departments")]
    public class Department
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Department Name should not blank")]
        [StringLength(50, ErrorMessage = "Length Shuold Not Be more than 50")]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        [Unicode(false)]
        public string? Description { get; set; }

        [InverseProperty("DepartmentRef")]
        public virtual ICollection<Employee>? Users { get; set; }

    }
}
