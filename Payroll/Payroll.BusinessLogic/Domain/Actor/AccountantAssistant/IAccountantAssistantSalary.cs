using System;
namespace Payroll.BusinessLogic.Domain.Actor.AccountantAssistant
{
    public interface IAccountantAssistantSalary
    {
        decimal CalculateAnnualSalary(decimal salary);
    }
}
