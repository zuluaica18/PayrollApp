using System;
using Payroll.BusinessLogic.Domain.Model;

namespace Payroll.BusinessLogic.Domain.Actor.AccountantAssistant
{
    public class AccountantAssistantMapping
    {
        private readonly IAccountantAssistantSalary _accountantAssistantSalary;

        public AccountantAssistantMapping(IAccountantAssistantSalary accountantAssistantSalary)
        {
            _accountantAssistantSalary = accountantAssistantSalary;
        }

        public EmployeDTO MappingEmploye (Employe employe)
        {
            return new EmployeDTO
            {
                id = employe.id,
                name = employe.name,
                typeContract = employe.typeContract == 1 ? "Hourly":"Monthtly",
                annualSalary = _accountantAssistantSalary.CalculateAnnualSalary(employe.salary)
            };
        }
    }
}
