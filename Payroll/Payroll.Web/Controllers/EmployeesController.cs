using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Payroll.BusinessLogic.Domain.Actor;
using Payroll.BusinessLogic.Domain.Model;
using Payroll.Infraestructure;

namespace Payroll.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly Accountant _accountant;

        public EmployeesController(Accountant accountant)
        {
            _accountant = accountant;
        }

        // GET: api/Employees/
        [HttpGet("")]
        public IEnumerable<EmployeDTO> List()
        {
            var employees = _accountant.GetEmployeesWithAnnualSalary();
            return employees;
        }

        // GET: api/Employees/1
        [HttpGet("{id}")]
        public EmployeDTO ById([FromRoute] int id)
        {
            var employe = _accountant.GetEmployeWithAnnualSalary(id);
            return employe;
        }
    }
}