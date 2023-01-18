namespace EmployeeISBlazer.Models
{
    public class Employee
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
