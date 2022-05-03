using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DL.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server =.\\SQLEXPRESS; Database = CompanyDatabase; Trusted_Connection = True; MultipleActiveResultSets = True");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
