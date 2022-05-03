using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BL.Models.PositionBL.Dto;

namespace BL.Models.PositionBL.Fetchers
{
    public interface IPositionFetchers
    {
        Task<ICollection<ResponseGetPositionDtoBL>> GetAll(CancellationToken token = default);
    }
}