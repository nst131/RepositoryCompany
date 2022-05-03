using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models.CompaniesBL.Dto;
using BL.Models.DepartmentBL.Dto;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Models.DepartmentBL.Fetchers
{
    public class DepartmentFetchers : IDepartmentFetchers
    {
        private readonly IDataContext context;
        private readonly IMapper mapper;

        public DepartmentFetchers(IDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICollection<ResponseGetDepartmentDtoBL>> GetAll(CancellationToken token = default)
        {
            if (!await this.context.Set<Department>().AnyAsync(token))
                return new List<ResponseGetDepartmentDtoBL>();

            var allDepartments = await this.context.Set<Department>().ToListAsync(token);

            return allDepartments.Select(department => this.mapper.Map<ResponseGetDepartmentDtoBL>(department)).ToList();
        }
    }
}
