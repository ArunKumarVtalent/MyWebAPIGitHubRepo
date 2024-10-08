using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPIPro.CustomDataAnnotations;

namespace WebAPIPro.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "Please enter ename...!")]
        [StringLength(20, ErrorMessage = "Please enter only 20 chars...!")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name accepts only chars...!")]
        public string Ename { get; set; }

        [Required(ErrorMessage = "Please enter password...!")]
        [PasswordCheck(ErrorMessage = "Please enter valid password.\nMust be 8 Chars and Max 16 Chars.")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Please enter confirm password...!")]
        //[Compare("Password", ErrorMessage ="Password mismatched...!")]
        //public string CnfPassword { get; set; }

        [Required(ErrorMessage = "Please enter gender...!")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter phone...!")]
        [StringLength(10, ErrorMessage = "Phone number must me 10 digits...!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter email...!")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter email format only...!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter salary...!")]
        [Range(5000, 50000, ErrorMessage = "Salary should be between 5000 to 50000 only...!")]
        [SalCheck(ErrorMessage = "Salary should be accepted divisible by 10 only...!")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Salary accepts only digits...!")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please enter address...!")]
        public string Address { get; set; }

        [ForeignKey("Department")]
        [DeptNoCheck(ErrorMessage = "Department no should not be zero or negitive values...!")]
        public int DeptNo { get; set; }

        public Department? Department { get; set; }
    }
}
