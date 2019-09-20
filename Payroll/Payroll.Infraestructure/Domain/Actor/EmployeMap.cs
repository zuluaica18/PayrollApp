using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Payroll.BusinessLogic.Domain.Model;

namespace Payroll.Infraestructure.Domain.Model
{
    public class EmployeMap : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {
            builder.ToTable("Employe")
               .HasKey(c => c.id);
        }
    }
}