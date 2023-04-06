using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentCRUD.Domain.Data;

public class Student
{
    public long Id { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; } = null!;
    [MaxLength(50)]
    public string LastName { get; set; } = null!;
    [MaxLength(50)]
    public string Email { get; set; } = null!;
    [MaxLength(10)]
    public string Gender { get; set; } = null!;
    public string? Address { get; set; }
}

