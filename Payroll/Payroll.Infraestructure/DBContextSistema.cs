using Microsoft.EntityFrameworkCore;
using Payroll.BusinessLogic.Domain.Model;
using Payroll.Infraestructure.Domain.Model;

namespace Payroll.Infraestructure
{
    public class DbContextSistema : DbContext
    {
        public DbSet<Employe> Employees { get; set; }

        public DbContextSistema(DbContextOptions<DbContextSistema> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeMap());
        }

    }
}
