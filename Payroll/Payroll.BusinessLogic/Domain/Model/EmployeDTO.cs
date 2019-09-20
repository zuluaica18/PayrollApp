using System;
namespace Payroll.BusinessLogic.Domain.Model
{
    public class EmployeDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string typeContract { get; set; }
        public decimal annualSalary { get; set; }
    }
}