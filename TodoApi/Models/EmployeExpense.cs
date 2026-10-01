using Dapper.Contrib.Extensions;
namespace TodoApi.Models
{
    [Table("EmployeExpense")]
    public class EmployeExpense
    {
        [Key]
        public int EmployeeId { get; set; }
        public string? Name { get; set; }

        public string?  department { get; set; }
        public  decimal?  salary { get; set; }

    }
}
