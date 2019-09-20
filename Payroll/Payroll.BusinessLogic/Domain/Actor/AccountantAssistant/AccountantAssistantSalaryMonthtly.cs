using System;
namespace Payroll.BusinessLogic.Domain.Actor.AccountantAssistant
{
    public class AccountantAssistantSalaryMonthtly : IAccountantAssistantSalary
    {
        public decimal CalculateAnnualSalary(decimal salary)
        {
            return salary * 12;
        }
    }
}
