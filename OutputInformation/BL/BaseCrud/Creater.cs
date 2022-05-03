using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BL.Interfaces;
using DL.Context;
using DL.Interfaces;
using DL.Models;

namespace BL.BaseCrud
{
    public class Creater<Entity, CreateDto> : ICreater<CreateDto>
        where Entity : class, IEntity
        where CreateDto : class
    {
        private readonly IDataContext context;
        private readonly IValidator<CreateDto> validator;
        private readonly IMapper mapper;

        public Creater(IDataContext context,
            IValidator<CreateDto> validator,
            IMapper mapper)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
        }

        public async Task<int> Create(CreateDto createDto, CancellationToken token = default)
        {
            await validator.Validate(createDto);

            var entity = this.mapper.Map<Entity>(createDto);

            await context.Set<Entity>().AddAsync(entity, token);

            await context.SaveChangesAsync(token);

            return entity.Id;
        }
    }
}
