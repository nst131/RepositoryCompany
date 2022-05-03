using AutoMapper;
using BL.Models.PositionBL.Dto;
using DL.Context;
using DL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Models.PositionBL.Fetchers
{
    public class PositionFetchers : IPositionFetchers
    {
        private readonly IDataContext context;
        private readonly IMapper mapper;

        public PositionFetchers(IDataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ICollection<ResponseGetPositionDtoBL>> GetAll(CancellationToken token = default)
        {
            if (!await this.context.Set<Position>().AnyAsync(token))
                return new List<ResponseGetPositionDtoBL>();

            var allPositions = await this.context.Set<Position>().ToListAsync(token);

            return allPositions.Select(position => this.mapper.Map<ResponseGetPositionDtoBL>(position)).ToList();
        }
    }
}
