using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BL.Models.EmployeeBL.Dto;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.Models.EmployeeBL.Fetchers
{
    public class EmployeeFetchersBL : IEmployeeFetchersBL
    {
        private readonly IDataContext context;
        private readonly IMapper mapper;

        public EmployeeFetchersBL(IDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICollection<ResponseGetEmployeeDtoBL>> GetAll(CancellationToken token = default)
        {
            if (!await this.context.Set<Employee>().AnyAsync(token))
                return new List<ResponseGetEmployeeDtoBL>();

            var allEmployees = await this.context.Set<Employee>()
                .Include(x => x.Address)
                .Include(x => x.Department)
                .Include(x => x.Position)
                .Include(x => x.Companies)
                .ToListAsync(token);

            return allEmployees.Select(employee => this.mapper.Map<ResponseGetEmployeeDtoBL>(employee)).ToList();
        }

        public async Task<ICollection<ResponseGetEmployeeDtoBL>> GetEmployeeByCompanyAndDepartment(int companyId, int departmentId, CancellationToken token)
        {
            if (await Task.Factory.StartNew(() => !this.context.Set<Department>().AsNoTracking().ToList().Exists(x => x.Id == departmentId), token))
                throw new NullReferenceException($"{nameof(Department)} by Id not Found");

            if (await Task.Factory.StartNew(() => !this.context.Set<Companies>().AsNoTracking().ToList().Exists(x => x.Id == companyId), token))
                throw new NullReferenceException($"{nameof(Companies)} by Id not Found");

            var employes = await this.context.Set<Employee>().AsNoTracking()
                .Where(x => x.CompaniesId == companyId && x.DepartmentId == departmentId)
                .Include(x => x.Address)
                .Include(x => x.Department)
                .Include(x => x.Position)
                .Include(x => x.Companies)
                .ToListAsync(token);

            return employes.Select(employee => this.mapper.Map<ResponseGetEmployeeDtoBL>(employee)).ToList();
        }
    }
}
