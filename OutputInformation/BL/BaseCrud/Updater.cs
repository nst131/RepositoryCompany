using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BL.Interfaces;
using DL.Context;
using DL.Interfaces;
using DL.Models;

namespace BL.BaseCrud
{
    public class Updater<Entity, UpdateDto> : IUpdater<UpdateDto>
        where Entity : class, IEntity
        where UpdateDto : class
    {
        private readonly IDataContext context;
        private readonly IValidator<UpdateDto> validator;
        private readonly IMapper mapper;

        public Updater(IDataContext context,
            IValidator<UpdateDto> validator, 
            IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task Update(UpdateDto updateDto, CancellationToken token = default)
        {
            await validator.Validate(updateDto);

            var entity = this.mapper.Map<Entity>(updateDto);

            var entry = await Task.Factory.StartNew(() => context.Set<Entity>().Update(entity), token);

            await context.SaveChangesAsync(token);
        }
    }
}
