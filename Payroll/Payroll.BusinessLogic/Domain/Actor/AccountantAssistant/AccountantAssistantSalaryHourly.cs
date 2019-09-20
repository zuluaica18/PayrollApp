using System;
namespace Payroll.BusinessLogic.Domain.Actor.AccountantAssistant
{
    public class AccountantAssistantSalaryHourly : IAccountantAssistantSalary
    {
        public decimal CalculateAnnualSalary(decimal salary)
        {
            return 120 * salary * 12;
        }
    }
}