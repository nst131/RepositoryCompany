using AutoMapper;
using BL.Models.CompaniesBL.Dto;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Models.CompaniesBL.Fetchers
{
    public class CompaniesFetchers : ICompaniesFetchers
    {
        private readonly IDataContext context;
        private readonly IMapper mapper;

        public CompaniesFetchers(IDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICollection<ResponseGetCompaniesDtoBL>> GetAll(CancellationToken token = default)
        {
            if (!await this.context.Set<Companies>().AnyAsync(token))
                return new List<ResponseGetCompaniesDtoBL>();

            var allCompanies = await this.context.Set<Companies>().ToListAsync(token);

            return allCompanies.Select(company => this.mapper.Map<ResponseGetCompaniesDtoBL>(company)).ToList();
        }
    }
}
