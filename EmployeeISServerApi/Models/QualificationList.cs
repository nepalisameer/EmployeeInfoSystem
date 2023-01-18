using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInformationSystemApi.Models;

[Table("QualificationList")]
public partial class QualificationList
{
    [Key]
    [Column("Q_id")]
    public long QId { get; set; }

    [Column("Q_Name")]
    [StringLength(15)]
    public string QName { get; set; } = null!;

    [InverseProperty("QIdNavigation")]
    public virtual ICollection<EmpQualification> EmpQualifications { get; } = new List<EmpQualification>();
}
