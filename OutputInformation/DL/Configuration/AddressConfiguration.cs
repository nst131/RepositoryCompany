using DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        private const string tableName = nameof(Address);

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Street).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Flat).HasMaxLength(256).IsRequired();
            builder.Property(x => x.House).HasMaxLength(256).IsRequired();

            builder.HasData(new Address[]
            {
                new Address(){Id = 1, EmployeeId = 1, Street = "Толстого", Flat = 20, House = 31},
                new Address(){Id = 2, EmployeeId = 2, Street = "Аэродромная", Flat = 30, House = 20},
                new Address(){Id = 3, EmployeeId = 3, Street = "Воронянского", Flat = 100, House = 13}
            });
        }
    }
}
