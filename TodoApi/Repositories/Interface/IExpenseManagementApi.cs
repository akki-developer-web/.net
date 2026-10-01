using TodoApi.Models;
using TodoApi.Repositories.Implementation;

namespace TodoApi.Repositories.Interface
{
    public interface IExpenseManagementApi 
    {
        Task<IEnumerable<EmployeExpense>> GetEmployees();
        Task<EmployeExpense?> GetEmployesbyId(int id);
        Task<bool> AddEmployee(EmployeExpense employeExpense);
        Task<bool> EditEmployee(EmployeExpense employeExpense );
        Task<bool> DeleteEmployee(int id);
        Task<bool> PatchEmployee(int id, UpdateEmployeeDto employee);








    }
}
