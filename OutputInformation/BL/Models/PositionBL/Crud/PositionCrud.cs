using System.Threading;
using System.Threading.Tasks;
using BL.Interfaces;
using BL.Models.PositionBL.Dto;

namespace BL.Models.PositionBL.Crud
{
    public class PositionCrud : IPositionCrud
    {
        private readonly IGetter<ResponseGetPositionDtoBL> getter;

        public PositionCrud(IGetter<ResponseGetPositionDtoBL> getter)
        {
            this.getter = getter;
        }

        public async Task<ResponseGetPositionDtoBL> Get(int id, CancellationToken token = default)
            => await this.getter.Get(id, token);
    }
}
