using Microsoft.Data.SqlClient;

namespace EmployeeInformationSystemApi.Repository
{
    public interface IMyConfiguration
    {
        string GetConnectionString();
    }
    public class MyConfiguration : IMyConfiguration
    {
        public MyConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string GetConnectionString()
        {
            var conStrBuilder = new SqlConnectionStringBuilder(
        Configuration.GetConnectionString("DefaultConnection"));
            conStrBuilder.Password = Configuration["DbPassword"];
            return conStrBuilder.ConnectionString;
        }
    }
}
