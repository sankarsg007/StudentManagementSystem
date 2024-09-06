using System.Data;
using System.Data.SqlClient;

namespace StudentManagementSystem.Repository
{
    public class StudentDBContext 
    {
        private readonly string _connectionString;
        public StudentDBContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
