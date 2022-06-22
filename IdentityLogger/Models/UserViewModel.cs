using Demo63Assignment.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace Demo63Assignment.Models.ViewModel
{
    public class UserViewModel
    {
        private string email = null!;

        [Display(Name = "User ID")]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; } = null!;
        [Display(Name = "Date Of Birth")]
        [AgeValidation(ErrorMessage = "Age Should be More Than 18")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Pan { get; set; } = null!;

        public string? Address { get; set; }
        public char Gender { get; set; }
        [Display(Name = "Mobile Number")]
        [Required]
        public string MobileNumber { get; set; } = null!;
        [Required]
        public string Email { get => email; set => email = value; }
        public string Comment { get; set; } = null!;
        [Required]
        public int DepartmentRefId { get; set; }

        [Display(Name = "Department")]
        public string? DepartmentName { get; set; }

    }
}
