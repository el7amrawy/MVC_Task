using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask.Models;

public partial class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    [Required]
    [Display(Name ="Full Name")]
    public string EmployeeName { get; set; } = null!;
    [Required]
    public string Job { get; set; } = null!;
    [Required]
    public decimal Salary { get; set; }
    public string? Address { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [ForeignKey(nameof(Depart))]
    public int? DepartId { get; set; }
    [Display(Name ="Department")]
   
    public virtual Department? Depart { get; set; }
}
