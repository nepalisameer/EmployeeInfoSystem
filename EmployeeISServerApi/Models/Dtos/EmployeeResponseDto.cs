using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeInformationSystemApi.Models.Dtos
{
    public class EmployeeResponseDto
    {
        public long employeeId { get; set; }
        public string empName { get; set; } = null!;
        public DateTime dob { get; set; }
        public string gender { get; set; } = null!;
        public decimal salary { get; set; }
        public string entryBy { get; set; } = null!;
        public DateTime entryDate { get; set; }

    }
}
