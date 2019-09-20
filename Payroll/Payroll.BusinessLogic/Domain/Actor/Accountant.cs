using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Payroll.BusinessLogic.Domain.Actor.AccountantAssistant;
using Payroll.BusinessLogic.Domain.Model;
using Payroll.Infraestructure.Domain.Actor;

namespace Payroll.BusinessLogic.Domain.Actor
{
    public class Accountant
    {
        private readonly SecretaryDao _secretaryDao;
        private readonly IServiceProvider _serviceProvider;
        public static Employe employeTemp;

        public Accountant(SecretaryDao secretaryDao, IServiceProvider serviceProvider)
        {
            _secretaryDao = secretaryDao;
            _serviceProvider = serviceProvider;
        }

        public List<EmployeDTO> GetEmployeesWithAnnualSalary()
        {
            List<EmployeDTO> employeesDTO = new List<EmployeDTO>();
            var employees = _secretaryDao.GetEmployees();
            foreach (Employe employe in employees)
            {
                employeTemp = employe;
                AccountantAssistantMapping accountantAssistantMapping = _serviceProvider.GetService<AccountantAssistantMapping>();
                employeesDTO.Add(accountantAssistantMapping.MappingEmploye(employe));
            }
            return employeesDTO;
        }

        public EmployeDTO GetEmployeWithAnnualSalary(int id)
        {
            var employe = _secretaryDao.GetEmploye(id);
            employeTemp = employe;
            AccountantAssistantMapping accountantAssistantMapping = _serviceProvider.GetService<AccountantAssistantMapping>();
            return accountantAssistantMapping.MappingEmploye(employe);
        }
    }
}
