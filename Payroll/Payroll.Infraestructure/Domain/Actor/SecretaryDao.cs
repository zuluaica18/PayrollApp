using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payroll.BusinessLogic.Domain.Model;

namespace Payroll.Infraestructure.Domain.Actor
{
    public class SecretaryDao
    {
        private readonly DbContextSistema _context;

        public SecretaryDao(DbContextSistema context)
        {
            _context = context;
        }

        public List<Employe> GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return employees;
        }

        public Employe GetEmploye(int id)
        {
            var employe = _context.Employees.Find(id);
            return employe;
        }
    }
}
