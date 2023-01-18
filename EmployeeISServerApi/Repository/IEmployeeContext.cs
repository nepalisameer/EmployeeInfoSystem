using EmployeeInformationSystemApi.Context;
using EmployeeInformationSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeInformationSystemApi.Repository
{
    public interface IEmployeeContext
    {
        Task Create(Employee employee);
        Task<Employee> GetByID(int id);
        Task<List<Employee>> GetAll();
        Task Register(Employee employee, EmpQualification qualification);
        Task<List<QualificationList>> GetQualifications();
    }
    public class EmployeeContext : IEmployeeContext
    {
        public EmployeeContext(EmployeeISContext context)
        {
            Context = context;
        }

        public EmployeeISContext Context { get; }

        public async Task Create(Employee employee)
        {
            await Context.Employees.AddAsync(employee);
            await Context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAll()
        {
            try
            {
                return await Context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                //Handle
                return null;
            }
        }

        public async Task<Employee> GetByID(int id)
        {
            return await Context.Employees.Where(emp => emp.EmployeeId == id).FirstOrDefaultAsync();
        }

        public async Task<List<QualificationList>> GetQualifications()
        {
            try
            {
                return await Context.QualificationLists.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Register(Employee employee, EmpQualification qualification)
        {
            try
            {
                //await Create(employee);
                qualification.Employee = employee;
                await Context.EmpQualifications.AddAsync(qualification);
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
