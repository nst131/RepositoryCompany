using DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        private const string tableName = nameof(Employee);

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();
            builder.Property(x => x.SerName).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Patronymic).HasMaxLength(256);
            builder.Property(x => x.Telephone).HasMaxLength(256).IsRequired();

            builder.HasOne(x => x.Address)
                .WithOne(x => x.Employee)
                .HasForeignKey<Address>(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Companies)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.CompaniesId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new Employee[]
            {
                new Employee(){Id = 1, Name = "Александр", SerName = "Моркович", Patronymic = "Генадьевич", Telephone = "29 134-56-89", CompaniesId = 1, DepartmentId = 1, PositionId = 1},
                new Employee(){Id = 2, Name = "Дмитрий", SerName = "Шишко", Patronymic = "Викторович", Telephone = "29 456-74-13", CompaniesId = 2, DepartmentId = 3, PositionId = 5},
                new Employee(){Id = 3, Name = "Анатолий", SerName = "Гаврилов", Patronymic = "Витальевич", Telephone = "29 117-36-78", CompaniesId = 2, DepartmentId = 5, PositionId = 6},
            });
        }
    }
}
