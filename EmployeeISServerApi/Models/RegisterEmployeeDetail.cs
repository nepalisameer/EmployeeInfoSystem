using System.ComponentModel.DataAnnotations;

namespace EmployeeInformationSystemApi.Models
{
    public class RegisterEmployeeDetail
    {
        public Employee employee { get; set; }
        [Required]
        public decimal marks { get; set; }
        [Required]
        public long qualificationListId { get; set; }
    }
}
