using TodoApi.Models;
using TodoApi.Repositories.Interface;
using TodoApi.Services.Interface;

namespace TodoApi.Services.Implemetation
{
    public class EmployeesExpenseServices : IEmployeesExpenseServices
    {
        private readonly IExpenseManagementApi _expenseManagementApi;
        public EmployeesExpenseServices(IExpenseManagementApi expenseManagementApi)
        {
            _expenseManagementApi = expenseManagementApi;
        }

       

        public async Task<IEnumerable<EmployeExpense>> GetEmployees()
        {
            return await _expenseManagementApi.GetEmployees();
        }

        public async Task<EmployeExpense?> GetEmployesbyId(int id)
        {

            return await _expenseManagementApi.GetEmployesbyId(id);
        }



        public async Task<bool> AddEmployee(EmployeExpense employeExpense)
        {
            return await _expenseManagementApi.AddEmployee(employeExpense);
             
        }

        public async Task<bool> EditEmployee(EmployeExpense employeExpense)
        {
            return await _expenseManagementApi.EditEmployee(employeExpense);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            return await _expenseManagementApi.DeleteEmployee(id);
        }

        

        public async Task<bool> patchEmployee(int id, UpdateEmployeeDto employee)
        {
            return await _expenseManagementApi.PatchEmployee(id, employee);
        }
    }
}
