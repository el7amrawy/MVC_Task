using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTask.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }
    [Required(ErrorMessage ="Username can't be empty")]
    public string Username { get; set; } = null!;
    [Required(ErrorMessage = "Password can't be empty")]
    public string Password { get; set; } = null!;
    [NotMapped]
    public bool Remember {  get; set; }
}
