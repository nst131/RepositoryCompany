using DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string tableName = nameof(Department);

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();

            builder.HasData(new Department[]
            {
                new Department(){ Id = 1, Name = "Научно-исследовательский отдел" },
                new Department(){ Id = 2, Name = "Отдел технического контроля"},
                new Department(){ Id = 3, Name = "Конструкторский отдел"},
                new Department(){ Id = 4, Name = "Отдел изобретательства и патентирования"},
                new Department(){ Id = 5, Name= "Отдел маркетинговых исследований"},
                new Department(){ Id = 6, Name= "Инструментальный отдел"},
                new Department(){ Id = 7, Name= "Отдел главного технолога"},
                new Department(){ Id = 8, Name= "Отдел автоматизации"}
            });
        }
    }
}
