using AutoMapper;
using BL.Interfaces;
using BL.Models.EmployeeBL.Dto;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Models.EmployeeBL.Crud
{
    public class EmployeeCrudBL : IEmployeeCrudBL
    {
        private readonly IDataContext context;
        private readonly IMapper mapper;
        private readonly ICreater<AcceptCreateEmployeeDtoBL> creater;
        private readonly IUpdater<AcceptUpdateEmployeeDtoBL> updater;
        private readonly IRemover<AcceptDeleteEmployeeDtoBL> remover;

        public EmployeeCrudBL(
            IDataContext context,
            IMapper mapper,
            ICreater<AcceptCreateEmployeeDtoBL> creater,
            IUpdater<AcceptUpdateEmployeeDtoBL> updater,
            IRemover<AcceptDeleteEmployeeDtoBL> remover)
        {
            this.context = context;
            this.creater = creater;
            this.updater = updater;
            this.remover = remover;
            this.mapper = mapper;
        }

        public async Task<ResponseGetEmployeeDtoBL> Get(int id, CancellationToken token = default)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException($"Id {nameof(Employee)} is less 0");

            if (token.IsCancellationRequested)
                throw new TaskCanceledException();

            var element = await context.Set<Employee>()
                .AsNoTracking()
                .Include(x => x.Address)
                .Include(x => x.Department)
                .Include(x => x.Position)
                .Include(x => x.Companies)
                .FirstOrDefaultAsync(x => x.Id == id, token);

            if (element is null)
                throw new NullReferenceException($"{nameof(Employee)} by Id not Found");

            return this.mapper.Map<ResponseGetEmployeeDtoBL>(element);
        }

        public async Task<int> Create(AcceptCreateEmployeeDtoBL dto, CancellationToken token = default)
            => await this.creater.Create(dto, token);

        public async Task Update(AcceptUpdateEmployeeDtoBL dto, CancellationToken token = default)
            => await this.updater.Update(dto, token);

        public async Task Delete(AcceptDeleteEmployeeDtoBL dto, CancellationToken token = default)
            => await this.remover.Remove(dto, token);
    }
}
