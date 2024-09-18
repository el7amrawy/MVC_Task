using System.ComponentModel.DataAnnotations;

namespace MVCTask.Models;

public partial class Department
{
    [Key]
    public int DepartmentId { get; set; }
    [Required]
    [Display(Name ="Department")]
    public string DepartmentName { get; set; } = null!;
    [Display(Name = "Manager")]
    public string? DepartmnetManager { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
