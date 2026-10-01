using Dapper.Contrib.Extensions;
 
using Microsoft.Data.SqlClient;
using TodoApi.Models;
using TodoApi.Repositories.Interface;

namespace TodoApi.Repositories.Implementation
{
    public class ExpenseManagementApi : IExpenseManagementApi
    {
        private readonly string _connectionString;
        public ExpenseManagementApi(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }



        public async Task<IEnumerable<EmployeExpense>> GetEmployees()

        {
            using var connection = new SqlConnection(_connectionString);

            var employees = await connection.GetAllAsync<EmployeExpense>();

            return employees;

        }

        public async Task<EmployeExpense?> GetEmployesbyId(int id)
        {
            using var connection = new SqlConnection(_connectionString);

            var employeebyid =
                await connection.GetAsync<EmployeExpense>(id);

            return employeebyid;
        }




        public async Task<bool> AddEmployee(EmployeExpense employeExpense)
        {
            using var connection = new SqlConnection(_connectionString);
            var employeres = await connection.InsertAsync(employeExpense);
            return employeres > 0;

        }

        public async Task<bool> EditEmployee(EmployeExpense employeExpense)
        {
            using var connection = new SqlConnection(_connectionString);
            var res = await connection.UpdateAsync(employeExpense);
            return res;

        }

        public async Task<bool> DeleteEmployee(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var employee =
                await connection.GetAsync<EmployeExpense>(id);
            if (employee == null)
            {
                return false;
            }



            var res = await connection.DeleteAsync(employee);
            return res;

        }

        




        public async Task<bool> PatchEmployee(int id, UpdateEmployeeDto employee)
        {
            using var connection = new SqlConnection(_connectionString);

            var existingEmployee = await connection.GetAsync<EmployeExpense>(id);

            if (existingEmployee == null)
            {
                return false;
            }

            if (employee.Name != null)
            {
                existingEmployee.Name = employee.Name;
            }

            if (employee.Department != null)
            {
                existingEmployee.department = employee.Department;
            }

            if (employee.Salary.HasValue)
            {
                existingEmployee.salary = employee.Salary.Value;
            }

            return await connection.UpdateAsync(existingEmployee);
        }
    }

}
