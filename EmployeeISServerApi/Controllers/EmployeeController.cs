using EmployeeInformationSystemApi.Context;
using EmployeeInformationSystemApi.Models;
using EmployeeInformationSystemApi.Models.Dtos;
using EmployeeInformationSystemApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeInformationSystemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeContext _context;
        private readonly IMyConfiguration cong;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeContext employeeContext, IMyConfiguration cong)
        {
            _logger = logger;
            this._context = employeeContext;
            this.cong = cong;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _context.GetByID(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var employee = await _context.GetAll();
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost("Registration")]
        public async Task<IActionResult> Register(RegisterEmployeeDetail details)
        {
            try
            {

                Employee emplyee = details.employee;
                await _context.Register(emplyee, new EmpQualification { Marks = details.marks, QId = details.qualificationListId });
                EmployeeResponseDto employeeResponseDto = new EmployeeResponseDto
                {
                    dob = emplyee.Dob,
                    salary = emplyee.Salary,
                    employeeId = emplyee.EmployeeId,
                    empName = emplyee.EmpName,
                    entryBy = emplyee.EntryBy,
                    entryDate = emplyee.EntryDate,
                    gender = emplyee.Gender,
                };
                return Ok(employeeResponseDto);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpGet("QualificationList")]
        public async Task<IActionResult> GetQualificationList()
        {
            var a = await _context.GetQualifications();
            return Ok(a);
        }
    }


}