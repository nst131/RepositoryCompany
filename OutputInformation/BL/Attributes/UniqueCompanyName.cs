using DL.Context;
using DL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BL.Attributes
{
    public class UniqueCompanyName : IUniqueCompanyName
    {
        private readonly IDataContext context;

        public UniqueCompanyName(IDataContext context)
        {
            this.context = context;
        }

        public async Task<bool> IsUniqueAtCreate<T>(string name) where T : class, IName
        {
            return await this.context.Set<T>().AnyAsync(x => x.Name == name);
        }

        public async Task<bool> IsUniqueAtUpdate<T>(string name, int exceptId) where T : class, IEntity, IName
        {
            var allElements = await this.context.Set<T>().AsNoTracking().Where(x => x.Name == name && x.Id != exceptId).ToListAsync();

            return !allElements.Any();
        }
    }
}
