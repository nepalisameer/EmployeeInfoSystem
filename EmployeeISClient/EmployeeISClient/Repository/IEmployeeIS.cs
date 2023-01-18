using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using EmployeeISBlazer.Models;

namespace EmployeeISBlazer.Repository
{
    public interface IEmployeeIS
    {
        Task<List<Employee>> GetAll();
        Task<List<QualiList>> GetAllQualiList();
        Task<Employee> Register(RegisterEmployeeDetail employeeDetail);

    }

    public class EmployeeIS : IEmployeeIS
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options;

        public EmployeeIS(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<List<Employee>> GetAll()
        {
            try
            {
                var response = await _client.GetAsync("employee/all");
                var content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException(content);
                }

                List<Employee> employees = JsonSerializer.Deserialize<List<Employee>>(content, _options);
                var a = "";
                return employees;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<List<QualiList>> GetAllQualiList()
        {
            var response = await _client.GetAsync("employee/QualificationList");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var list = JsonSerializer.Deserialize<List<QualiList>>(content, _options);
            return list;
        }

        public async Task<Employee> Register(RegisterEmployeeDetail employeeDetail)
        {

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(employeeDetail), System.Text.Encoding.UTF8, "Application/Json");
                var response = await _client.PostAsync("employee/Registration", content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApplicationException("Failed to Register");

                }
                var employee = JsonSerializer.Deserialize<Employee>(await response.Content.ReadAsStringAsync());
                return employee;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
