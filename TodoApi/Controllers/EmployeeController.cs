using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories.Interface;
using TodoApi.Services.Interface;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesExpenseServices _employeesExpenseServices;
        public EmployeeController(IEmployeesExpenseServices employeesExpenseServices)
        {
            _employeesExpenseServices = employeesExpenseServices;
        }


        [HttpGet("ALL")]
        public async Task<IActionResult> GetEmployees()

        {
            var employesss = await _employeesExpenseServices.GetEmployees();
            if (employesss == null)
            {
                return NotFound();
            }

            return Ok(employesss);





        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees(int id)
        {
            var employee =
                await _employeesExpenseServices.GetEmployesbyId(id);

            return Ok(employee);
        }




        [HttpPost("create")]
        public async Task<IActionResult> AddEmployee(EmployeExpense employeExpense)

        {
            var  res = await _employeesExpenseServices.AddEmployee(employeExpense);
            if (!res)
            {
                return BadRequest("employee not found");
                
            }
            return Ok("employee inserted sucessfully");





        }





        [HttpPost("update")]
        public async Task<IActionResult> UpdateEmployee(EmployeExpense employeExpense)

        {
            var res = await _employeesExpenseServices.EditEmployee(employeExpense);
            if (!res)
            {
                return BadRequest("employee not found");

            }
            return Ok("employee  updated sucessfully");





        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEmployee(
      int id,
      [FromBody] UpdateEmployeeDto employee)
        {
            var result = await _employeesExpenseServices.patchEmployee(id, employee);

            if (!result)
            {
                return NotFound("Employee not found");
            }

            return Ok("Employee updated successfully");
        }







        [HttpPost("delete")]
        public async Task<IActionResult> DeleteEmployee(int id)

        {
            var res = await _employeesExpenseServices.DeleteEmployee(id);
            if (!res)
            {
                return BadRequest("employee not found");

            }
            return Ok("employee deleted sucessfully");





        }
    }
}
