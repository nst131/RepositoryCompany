using System;
using System.Threading;
using System.Threading.Tasks;
using BL.Interfaces;
using DL.Context;
using DL.Interfaces;
using DL.Models;
using Microsoft.EntityFrameworkCore;

namespace BL.BaseCrud
{
    public class Remover<Entity, AcceptDto> : IRemover<AcceptDto>
        where Entity : class, IEntity
        where AcceptDto : class, IRemoverDto
    {
        private readonly IDataContext context;

        public Remover(IDataContext context)
        {
            this.context = context;
        }

        public async Task<int> Remove(AcceptDto dto, CancellationToken token = default)
        {
            if (dto.Id < 0)
                throw new ArgumentOutOfRangeException($"Id {nameof(Entity)} is less 0");

            var entity = await context.Set<Entity>().FirstOrDefaultAsync(x => x.Id == dto.Id, token);

            if (entity is null)
                throw new NullReferenceException($"{nameof(Entity)} by Id not Found");

            await Task.Factory.StartNew(() => token.IsCancellationRequested ? throw new TaskCanceledException() : context.Set<Entity>().Remove(entity), token);
            await context.SaveChangesAsync(token);

            return dto.Id;
        }
    }
}
