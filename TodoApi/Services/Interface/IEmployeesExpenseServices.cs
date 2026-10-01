using TodoApi.Models;

namespace TodoApi.Services.Interface
{
    public interface IEmployeesExpenseServices 
    {
        Task<IEnumerable<EmployeExpense>> GetEmployees();
        Task<EmployeExpense?>GetEmployesbyId(int id);
        Task<bool> AddEmployee(EmployeExpense employeExpense);
        Task<bool> EditEmployee(EmployeExpense employeExpense);
        Task<bool> DeleteEmployee(int id);
        Task<bool> patchEmployee(int id, UpdateEmployeeDto employee);

    }
}
