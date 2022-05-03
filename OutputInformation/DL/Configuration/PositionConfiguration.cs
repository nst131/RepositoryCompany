using DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DL.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        private const string tableName = nameof(Position);
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable(tableName).HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(256).IsRequired();

            builder.HasData(new Position[]
            {
                new Position(){Id = 1, Name = "Главный конструктор"},
                new Position(){Id = 2, Name = "Заведующий лабораторией"},
                new Position(){Id = 3, Name = "Конструктор"},
                new Position(){Id = 4, Name = "Лаборант"},
                new Position(){Id = 5, Name = "Начальник отдела ИТ"},
                new Position(){Id = 6, Name = "Системный администратор"},
                new Position(){Id = 7, Name = "Старший программист"},
                new Position(){Id = 8, Name = "Программист"}
            });
        }
    }
}
