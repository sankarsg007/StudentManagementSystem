﻿using Dapper;
using StudentManagementSystem.Models;
using System.Data.SqlClient;

namespace StudentManagementSystem.Repository
{
    public class StudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository(string connectionString)
        { 
            _connectionString = connectionString; 
        }

        public async Task RegisterStudentAsync(Student student)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO RegisterStudent (FirstName, LastName, PhoneNumber, Email, Password, BloodGroup, Location) VALUES (@FirstName, @LastName, @PhoneNumber, @Email, @Password, @BloodGroup, @Location);";
                await connection.ExecuteAsync(query, student);
            }
        }

        public async Task<Login> LoginStudentAsync(Login login)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM RegisterStudent WHERE EMAIL = @Email AND PASSWORD = @Password;";

                var result = await connection.QuerySingleOrDefaultAsync<Login>(query, new { login.Email, login.Password });

                return result;
            }
        }

    }
}
