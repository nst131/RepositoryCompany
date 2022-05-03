using DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Configuration
{
    public class CompaniesConfiguration : IEntityTypeConfiguration<Companies>
    {
        private const string tableName = nameof(Companies);

        public void Configure(EntityTypeBuilder<Companies> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();

            builder.HasData(new Companies[]
            {
                new Companies(){Id = 1, Name = "Apple"},
                new Companies(){Id = 2, Name = "Microdoft"},
                new Companies(){Id= 3, Name = "Amazon"},
                new Companies(){Id = 4, Name = "Tesla"},
                new Companies(){Id = 5, Name = "NVIDIA"}
            });
        }
    }
}
