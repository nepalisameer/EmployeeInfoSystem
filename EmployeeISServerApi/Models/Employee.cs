using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInformationSystemApi.Models;

[Table("Employee")]
public partial class Employee
{
    [Key]
    [Column("Employee_id")]
    public long EmployeeId { get; set; }

    [Column("Emp_Name")]
    [StringLength(100)]
    public string EmpName { get; set; } = null!;

    [Column("DOB", TypeName = "date")]
    public DateTime Dob { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Gender { get; set; } = null!;

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Salary { get; set; }

    [Column("Entry_by")]
    [StringLength(100)]
    public string EntryBy { get; set; } = null!;

    [Column("Entry_date", TypeName = "datetime")]
    public DateTime EntryDate { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<EmpQualification> EmpQualifications { get; } = new List<EmpQualification>();
}
