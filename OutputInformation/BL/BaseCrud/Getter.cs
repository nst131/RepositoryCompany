using AutoMapper;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using BL.Interfaces;
using DL.Interfaces;

namespace BL.BaseCrud
{
    public class Getter<Entity, DtoGetResponse> : IGetter<DtoGetResponse>
        where Entity : class, IEntity
        where DtoGetResponse : class
    {
        private readonly IDataContext context;
        private readonly IMapper mapper;

        public Getter(IDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<DtoGetResponse> Get(int id, CancellationToken token = default)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException($"Id {nameof(Entity)} is less 0");

            if (token.IsCancellationRequested)
                throw new TaskCanceledException();

            var element = await context.Set<Entity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, token);

            if (element is null)
                throw new NullReferenceException($"{nameof(Entity)} by Id not Found");

            return this.mapper.Map<DtoGetResponse>(element);
        }
    }
}
