using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInformationSystemApi.Models;

[PrimaryKey("EmployeeId", "QId")]
[Table("EMP_QUALIFICATION")]
public partial class EmpQualification
{
    [Key]
    [Column("Employee_id")]
    public long EmployeeId { get; set; }

    [Key]
    [Column("Q_id")]
    public long QId { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Marks { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("EmpQualifications")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("QId")]
    [InverseProperty("EmpQualifications")]
    public virtual QualificationList QIdNavigation { get; set; } = null!;
}
